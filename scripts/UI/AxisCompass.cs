
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxisCompass : MonoBehaviour
{
  public Transform playerCam;
   
    Vector3 Xdirection;
    // Update is called once per frameb 
   public RectTransform CompassUI;


    
    void Update()
    {
        XaxisChanged();
    }


    public void XaxisChanged()
    {
        Xdirection.z = playerCam.eulerAngles.y;
        CompassUI.localEulerAngles = Xdirection;
    }
}
