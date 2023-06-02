using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueFormulization : MonoBehaviour
{
    public TMP_InputField text;
    float xformula;
    public void sliderchanged()
    {
  
        if (!this.GetComponent<Slider>().wholeNumbers)
        {
            text.text = this.GetComponent<Slider>().value.ToString("0.0");
        }
        else
        {
          
            xformula = this.GetComponent<Slider>().value - (this.GetComponent<Slider>().maxValue / 2);
            text.text = xformula.ToString("0.0");
        }
          
    }

}
