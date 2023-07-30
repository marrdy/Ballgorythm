using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class DialogContentClass : MonoBehaviour
{   
 
  public dialogclass dclass;
  public bool FollowObject;
  public GameObject PointAt;
   void Update()
{
  if(FollowObject)
  {
      transform.position = PointAt.transform.position;
  }
 

}
}
[System.Serializable]
public class dialogclass
{
  
    public TMP_Text dialogtext;
     public GameObject DialogLocalTrigger;
     

}

