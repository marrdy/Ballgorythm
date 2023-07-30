using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Controls;
    
   private static WaypointerIcon[] icons;
    public TMP_Text StateText;
    bool ShowOrHide = true;
    void Start()
    {
        icons = (WaypointerIcon[]) GameObject.FindObjectsOfType (typeof(WaypointerIcon));
        ActivateControl(false);
    }
    public void ActivateControl(bool state)
    {
        try
        {
            foreach (WaypointerIcon i in icons)
            {
                if(i.gameObject.name == "Framefp")
                {
                i.gameObject.SetActive(state);
                }
               
            }
        }
       
        catch (Exception)
        {

        }
    }

    public void ToggleButton()
    {
        ActivateControl(ShowOrHide);
        
        if (ShowOrHide)
        {
            StateText.text = "Hide platforms";
        }
        else
        {
            StateText.text = "Show platforms";
        }
        ShowOrHide = !ShowOrHide;
    }
}
