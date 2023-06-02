using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockControls : MonoBehaviour
{
    // Start is called before the first frame update
 


    public void UnlockSlider(Slider slidercontrol)
        
    {
        slidercontrol.interactable = true;
    }
    public void UnlockButton(Button  buttoncontrol)

    {
        buttoncontrol.interactable = true;
    }
}
