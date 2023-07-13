using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class SecondForce : MonoBehaviour
{
    public GameObject[] DissappearOnTrigger;
    public CinemachineFreeLook thirdCam;
    public Vector3 ApplyVelocity;
    public float ExecutionDelay;
    public GameObject Panel;
    public Slider Xslider;
    public Slider Yslider;
    public Slider Zslider;
    public TMP_InputField XtextValue;
    public TMP_InputField YtextValue;
    public TMP_InputField ZtextValue;
    public bool toggleLookGoal;
    public Animator animator;
    public Button hideButton;
    public PlayerMovement PMVM;
    public SceneProj SFprojector;
    public bool SimTrig;
    public bool BlueForcePoint = false;
    public Button looktooglebutton;
    Collider ballcol;
    float xformula;
    float yformula;
    float zformula;
    public Canvas mainhub;
    public Vector3 forectoapply;
    public SceneProj ProjectFP;
    public GameObject previewsProjPF;

    public bool ImProjection;
    
    public void toggleview(bool toggleOnPlayer)
    {
        if (toggleOnPlayer)
        {

            animator.Play("ViewOtherEnt");
        }
        else
        {

            animator.Play("GoalCam");
        }
    }

    public void toggleButton()
    {
        toggleview(toggleLookGoal);
        toggleLookGoal = !toggleLookGoal;
    }

    void OnTriggerEnter(Collider other)
    {
        ballcol = other;


        if (BlueForcePoint)
        {
            ballcol.GetComponent<Rigidbody>().isKinematic = true;
            ballcol.GetComponent<Rigidbody>().isKinematic = false;
            if (other.name == "Player")
            {
                TriggerBFP(false);
            }

        }
      
            ballcol.GetComponent<Rigidbody>().AddForce(forectoapply*2);
        
        
    }
    public void ProjectionSlider()
    {
        forectoapply = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
        updateStatProjection();

    }
    public void ClickButtonFP()
    {
        hideButton.GetComponent<UImanager>().ActivateControl(false);
        looktooglebutton.gameObject.SetActive(true);
        Panel.SetActive(true);
        thirdCam.LookAt = this.transform;
        thirdCam.Follow = this.transform;
        animator.Play("ViewOtherEnt");
        mainhub.gameObject.SetActive(false);
        //hidePlats.GetComponent<UImanager>().ActivateControl(false);
    }
    public void SetFpValue()
    {
        Panel.SetActive(false);
        looktooglebutton.gameObject.SetActive(false);
        animator.Play("PlayerCam");
         mainhub.gameObject.SetActive(true);
        forectoapply = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
        hideButton.GetComponent<UImanager>().ActivateControl(true);

    }
    public void VectorReset()
    {
        Xslider.value = 1000;
        Yslider.value = 1000;
        Zslider.value = 1000;
    }
    public void TriggerBFP(bool TrigStat)
    {
       foreach(GameObject i in DissappearOnTrigger)
        {
            i.SetActive(TrigStat);
        }
    }
     public void sliderchanged(string Axis)
    {

       
        if (Axis == "x")
        {
            xformula = Xslider.value - (Xslider.maxValue / 2);
            XtextValue.text = xformula.ToString("0.0");
        }
        else if (Axis == "y")
        {
            yformula = Yslider.value - (Yslider.maxValue / 2);
            YtextValue.text = yformula.ToString("0.0");
        }
        else if (Axis == "z")
        {
            zformula = Zslider.value - (Zslider.maxValue / 2);
            ZtextValue.text = zformula.ToString("0.0");
        }
         
    }

    public void updateStatProjection()
    {
        Debug.Log("FP updated");
       previewsProjPF= ProjectFP.SimulateFP(this,this.transform.position,forectoapply,previewsProjPF);
    }
    void Update()
    {
       
    }
}

