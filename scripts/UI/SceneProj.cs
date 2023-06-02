using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProj : MonoBehaviour
{
    private Scene SceneProjector;
    public PhysicsScene PS;

    [SerializeField] private Transform ObjectsInProjection;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxPhysicsFrameIterations = 500;
 
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
            ghostobj.GetComponent<Renderer>().enabled = false;
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
        ghostObj.name = "Simulation";
        //ghostObj.initpush(velocity);
        ghostObj.rb.AddForce(velocity);
        
        _line.positionCount = _maxPhysicsFrameIterations;

        for (var i = 0; i < _maxPhysicsFrameIterations; i++)
        {
            _line.SetPosition(i, ghostObj.transform.position);
           
            
            if (player.AimAssistExtend)
            {
                PS.Simulate(Time.fixedDeltaTime);
                PS.Simulate(Time.fixedDeltaTime);
                PS.Simulate(Time.fixedDeltaTime);
                PS.Simulate(Time.fixedDeltaTime);
                PS.Simulate(Time.fixedDeltaTime);
            }
            else
            {
                PS.Simulate(Time.fixedDeltaTime);
            }
           

        }

        Destroy(ghostObj.gameObject);
    }
   

}
