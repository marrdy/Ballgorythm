using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewMiniCam : MonoBehaviour
{
    public Transform playerpos;
    public Transform goalpos;
    public float distanceToOrthSize;
    public int camdistance = 100;
    public SpriteRenderer gridlines;
    public string anglestate;
    
    void Start()
    {
     
         distanceToOrthSize = Vector3.Distance(playerpos.position, goalpos.position) + 80;
        this.GetComponent<Camera>().orthographicSize = distanceToOrthSize;
        if((playerpos.position.x -goalpos.position.x)>(playerpos.position.z -goalpos.position.z))
        {
            anglestate ="Z";
            this.transform.position = new Vector3(playerpos.position.x-camdistance, playerpos.position.y, playerpos.position.z);
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
