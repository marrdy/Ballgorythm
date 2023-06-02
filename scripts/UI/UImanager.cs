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
    public TMP_Text StateText;
    bool ShowOrHide = true;
    public void ActivateControl(bool state)
    {
        try
        {
            foreach (GameObject i in Controls)
            {
                i.SetActive(state);

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
