using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFollow : MonoBehaviour
{
   public Transform FollowObject;
    public Camera minicam;
    [SerializeField]
    private float sizeDivider = 40;
    public MiniMapSetPosToPlayer mmspp;
   
    void Start()
    {
       
       transform.Rotate(0, minicam.transform.rotation.eulerAngles.y*-1, 0, Space.Self);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(FollowObject.transform.position.x, FollowObject.transform.position.y+10 , FollowObject.transform.position.z);
        transform.localScale = new Vector3(mmspp.distanceToOrthSize, mmspp.distanceToOrthSize, mmspp.distanceToOrthSize) / sizeDivider; 
     }
}
