using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SideViewMiniCam : MonoBehaviour
{
    public Transform playerpos;
    public Transform goalpos;
    public float distanceToOrthSize;
    public int camdistance = 100;
    public SpriteRenderer gridlines;
    [HideInInspector]
    public string anglestate;
    public float margin = 10;
    void Start()
    {
          float xd = Math.Abs(playerpos.position.x -goalpos.position.x);
          float yd =Math.Abs(playerpos.position.z -goalpos.position.z);
         
         distanceToOrthSize = Vector3.Distance(playerpos.position, goalpos.position) + margin;
        this.GetComponent<Camera>().orthographicSize = distanceToOrthSize;
        Debug.Log("x distant: "+xd.ToString());
        Debug.Log("z distant: "+yd.ToString());
        if(xd<yd)
        {
            anglestate ="Z";
            this.transform.position = new Vector3(playerpos.position.x+camdistance, playerpos.position.y, playerpos.position.z);
             this.transform.eulerAngles = new Vector3(0,90,0);
            gridlines.transform.eulerAngles = new Vector3(0,90,0);
                 gridlines.transform.position = new Vector3(playerpos.position.x+200, playerpos.position.y, playerpos.position.z);
        }
        else
        {
           anglestate ="X";
                this.transform.position = new Vector3(playerpos.position.x, playerpos.position.y, playerpos.position.z-camdistance);
                this.transform.eulerAngles = new Vector3(0,0,0);
                gridlines.transform.eulerAngles = new Vector3(0,0,0);
                 gridlines.transform.position = new Vector3(playerpos.position.x, playerpos.position.y, playerpos.position.z+200);
        }
        
         gridlines.transform.localScale = new Vector3(distanceToOrthSize, distanceToOrthSize, distanceToOrthSize);   
    }

  
    
}
