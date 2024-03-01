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
    Coroutine projectCoroute;
    PlayerMovement ghostObj;
   [SerializeField] private Transform ObjectsInProjection;
   
    [SerializeField] private LineRenderer _line;
  
    [SerializeField] public int _maxPhysicsFrameIterations = 500;
    
 
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
    private void Ulpdate()
        {
            foreach (var item in _spawnedObjects)
            {
                item.Value.position = item.Key.position;
                item.Value.rotation = item.Key.rotation;
            }
        }
    IEnumerator projectdelay(PlayerMovement player, Vector3 pos, Vector3 velocity) 
    {
        if (ghostObj != null)
        {
            Destroy(ghostObj.gameObject);
        }

        ghostObj = null;
        _line.positionCount = 0;
        ghostObj = Instantiate(player, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, SceneProjector);
        ghostObj.name = "SimulationBall";
        //ghostObj.initpush(velocity);
        ghostObj.rb.AddForce(velocity);
        ghostObj.GetComponent<MeshRenderer>().enabled = false;
        ghostObj.GetComponent<TrailRenderer>().enabled = false;
        
        
        _line.gameObject.layer = 7;
       
        for (var i = 0; i < _maxPhysicsFrameIterations; i++)
        {
            _line.positionCount = i + 1;
            _line.SetPosition(i, ghostObj.transform.position);


                PS.Simulate(Time.fixedDeltaTime);
            yield return new WaitForSeconds(1f/1000000);
        }
        

        Destroy(ghostObj.gameObject);
        yield return null;
    }
    public void SimulateTrajectory(PlayerMovement player, Vector3 pos, Vector3 velocity)
    {
        StopAllCoroutines();
          projectCoroute = StartCoroutine(projectdelay(player, pos, velocity));
    }
   
   
public GameObject SimulateFP(SecondForce FP, Vector3 pos, Vector3 FPvalue,GameObject previewsProj)
    {
        Destroy(previewsProj);
        var ghostObj = Instantiate(FP, pos, Quaternion.identity) ;
        ghostObj.used = false;
        ghostObj.forectoapply = FPvalue;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, SceneProjector);
        ghostObj.name = "FPprojection";
        ghostObj.ImProjection =true;
        return ghostObj.gameObject;
    }

   

}
