using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthAdjustor : MonoBehaviour
{
   public MiniMapSetPosToPlayer mmsp;
    public LineRenderer lineref;
    LineRenderer thisline;
    public PlayerMovement player;
    
    void Start()
    {
       

        thisline = this.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        this.GetComponent<LineRenderer>().startWidth = mmsp.distanceToOrthSize / 10;
        this.GetComponent<LineRenderer>().endWidth = mmsp.distanceToOrthSize / 10;
        thisline.positionCount = lineref.positionCount; 
        Vector3[] newPos = new Vector3[lineref.positionCount];
        lineref.GetPositions(newPos);
        thisline.SetPositions(newPos);
    }
}
