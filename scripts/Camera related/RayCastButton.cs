using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class RayCastButton : MonoBehaviour
{
      public UnityEvent Onclick = new UnityEvent();
    public Color onclickColor;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
                if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject)
                {
                 Onclick.Invoke();
                 this.GetComponent<TextMeshPro>().color =onclickColor;
                }
        }
    }
}
