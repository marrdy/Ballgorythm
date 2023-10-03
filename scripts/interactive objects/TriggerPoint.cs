using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using playerscript;
public class TriggerPoint : MonoBehaviour
{
     
public GameObject triggerobj;
void OnTriggerEnter(Collider other)
{
    if(other.name == "Player")
            {
                FindAnyObjectByType<SMScript>().playtrack("TPclick");
               triggerobj.SetActive(false);
            }
}
void Start()
{
    GetComponent<LineRenderer>().positionCount = 2;
    GetComponent<LineRenderer>().SetPosition(0,transform.position);
    GetComponent<LineRenderer>().SetPosition(1,triggerobj.transform.position);
}
}






