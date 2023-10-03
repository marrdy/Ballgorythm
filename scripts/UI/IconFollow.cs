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
    public bool sideviewOn = false;
    public SideViewMiniCam svm;
    void Start()
    {
       if(sideviewOn)
       {
         if(svm.anglestate =="X")
         {
              
               this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 100);
               Debug.Log("facing X");
         }
         else
         {

             Debug.Log("facing y");
               this.transform.eulerAngles = new Vector3(90,90,-180);
               this.transform.position = new Vector3(this.transform.position.x- 100,this.transform.position.y,this.transform.position.z );
        
         }
      }
       else
       {
         this.transform.eulerAngles = new Vector3(90,0,-90);
       }
       

    }

    // Update is called once per frame
    void Update()
    {
      if(sideviewOn)
      {
          if(svm.anglestate =="X")
         {
             this.transform.eulerAngles = new Vector3(0,0,0);
               this.transform.position = new Vector3(FollowObject.transform.position.x,FollowObject.transform.position.y,svm.transform.position.z  + 50);
               Debug.Log("facing X");
         }
         else
         {

             Debug.Log("facing y");
            this.transform.eulerAngles = new Vector3(0,90,0);
               this.transform.position = new Vector3(svm.transform.position.x+ 50,FollowObject.transform.position.y,FollowObject.transform.position.z  );
        
         }
      }
      else
      {
         transform.position = new Vector3(FollowObject.transform.position.x, FollowObject.transform.position.y+10 , FollowObject.transform.position.z);
        this.transform.eulerAngles = new Vector3(90,90,0);

      }
      
        
       transform.localScale = new Vector3(mmspp.distanceToOrthSize, mmspp.distanceToOrthSize, mmspp.distanceToOrthSize) * sizeDivider; 
     }
}
