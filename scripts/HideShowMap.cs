using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMap : MonoBehaviour
{
    
    public void hidemap()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }
    
}
