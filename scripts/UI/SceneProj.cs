using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using playerscript;
using System;

public class SceneProj : MonoBehaviour
{
    public Scene SceneProjector;
    public PhysicsScene PS;

    [SerializeField] private Transform ObjectsInProjection;
   
    [SerializeField] private LineRenderer _line;
  
    [SerializeField] public int _maxPhysicsFrameIterations = 50;
    
 
    private readonly Dictionary<Transform, Transform> _spawnedObjects = new Dictionary<Transform, Transform>();
    void Start()
    {
       
        CreateProjection();
       
    }
    
    void CreateProjection()
    {
        SceneProjector = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        PS = SceneProjector.GetPhysicsScene();

        foreach (Transform obj in ObjectsInProjection)
        {
            var ghostobj = Instantiate(obj.gameObject,obj.position,obj.rotation);
            try
            {
                ghostobj.GetComponent<Renderer>().enabled = false;
            }
            catch
            {
            }
            try
            {
                ghostobj.GetComponent<Terrain>().enabled = false;
            }
            catch
            {
            }
           
            SceneManager.MoveGameObjectToScene(ghostobj,SceneProjector);
            if (!ghostobj.isStatic) _spawnedObjects.Add(obj, ghostobj.transform);
        }
       
    }
    private void Update()
        {
            foreach (var item in _spawnedObjects)
            {
                item.Value.position = item.Key.position;
                item.Value.rotation = item.Key.rotation;
            }
        }
    public void SimulateTrajectory(PlayerMovement player, Vector3 pos, Vector3 velocity)
    {
        var ghostObj = Instantiate(player, pos, Quaternion.identity) ;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, SceneProjector);
        ghostObj.name = "SimulationBall";
        //ghostObj.initpush(velocity);
        ghostObj.rb.AddForce(velocity);
        Vector3[] lineforms = new Vector3[_maxPhysicsFrameIterations];
        _line.positionCount = _maxPhysicsFrameIterations;
        _line.gameObject.layer = 7;
        _line.enabled =false;
        for (var i = 0; i < _maxPhysicsFrameIterations; i++)
        {       
            lineforms[i] = ghostObj.transform.position;
       
                int linegap = 0;
                while(linegap <= 10)
                {
                    PS.Simulate(Time.fixedDeltaTime);
                    linegap++;
                }
         
        }
        _line.enabled =true;
             _line.SetPositions(lineforms);
        Destroy(ghostObj.gameObject);
    }
   
public GameObject SimulateFP(SecondForce FP, Vector3 pos, Vector3 FPvalue,GameObject previewsProj)
    {
        try
        {
            Destroy(previewsProj);
        }
        catch
        {
        }
        var ghostObj = Instantiate(FP, pos, Quaternion.identity) ;
        ghostObj.used = false;
        ghostObj.forectoapply = FPvalue;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, SceneProjector);
        ghostObj.name = "FPprojection";
        ghostObj.ImProjection =true;
      
        return ghostObj.gameObject;
    }
}
