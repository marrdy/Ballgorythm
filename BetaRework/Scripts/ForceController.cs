using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ForceController : MonoBehaviour
{
  public GroupAlgoritmConstructor GAC;

  public int index;
  public Slider Xslider;
  public Slider Yslider;
  public Slider Zslider;
  public Slider interSlider;
  public Button PushButton;
  public TMP_InputField XinputField;
  public TMP_InputField YinputField;
  public TMP_InputField ZinputField;
  public TMP_Text intertext;  
  public TMP_Text CurrentAlgoIndex;
  
  
  public void SetForceAlgo()
  {
    GAC.ContructGAC[index].FA.AlgorithmForce.force = new Vector3(float.Parse(XinputField.text),float.Parse(YinputField.text),float.Parse(ZinputField.text));
     GAC.ContructGAC[index].FA.AlgorithmForce.intervalBetweenForces = interSlider.value;
    GAC.ContructGAC[index].FD.force = new Vector3(float.Parse(XinputField.text),float.Parse(YinputField.text),float.Parse(ZinputField.text));
    GAC.ContructGAC[index].FD.intervalBetweenForces = interSlider.value;
  }
  public void LoadForceAlgo()
  {
    Xslider.value = GAC.ContructGAC[index].FD.force.x;
    Yslider.value = GAC.ContructGAC[index].FD.force.y;
    Zslider.value =GAC.ContructGAC[index].FD.force.z;
    interSlider.value = GAC.ContructGAC[index].FD.intervalBetweenForces;

  }

    public void sliderchanged()
    {
        XinputField.text = Xslider.value.ToString();
        YinputField.text =Yslider.value.ToString();
        ZinputField.text = Zslider.value.ToString();
        intertext.text = interSlider.value.ToString();
        
    }
    public void InputFieldChanged()
    {
        if(float.Parse(XinputField.text)>0)
        {
            Xslider.maxValue = float.Parse(XinputField.text);
          
        }
        else
        {
             Xslider.minValue = float.Parse(XinputField.text);
            
        }

         if(float.Parse(YinputField.text)>0)
        {
            Yslider.maxValue = float.Parse(YinputField.text);
           
        }
        else
        {
             Yslider.minValue = float.Parse(YinputField.text);
           
        }


         if(float.Parse(ZinputField.text)>0)
        {
            Zslider.maxValue = float.Parse(ZinputField.text);
            
        }
        else
        {
             Zslider.minValue = float.Parse(ZinputField.text);
        
        }
    }
    public void reselectAlgonum()
    {
        gameObject.SetActive(false);
        GAC.transform.parent.gameObject.SetActive(true);
    }
}
