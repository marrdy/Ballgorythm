using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
namespace playerscript
{
public class SecondForce : MonoBehaviour
{
    
    public CinemachineFreeLook thirdCam;
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
    public Button looktooglebutton;
    Collider ballcol;
    public Canvas mainhub;
    public Vector3 forectoapply;
    public SceneProj ProjectFP;
    public GameObject previewsProjPF;
    public bool ImProjection;
    public Transform arrow;
    [HideInInspector]
     private Vector3 previousSimulationForce;
    [HideInInspector]
    public bool used;
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
    private void Update()
    {
       
        Vector3 currentSimulationForce = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
    if (PMVM.notyetpushed && currentSimulationForce !=  previousSimulationForce&&  PMVM.AimAssistExtend)
    {
       
        PMVM._projection.SimulateTrajectory(PMVM, PMVM.startpos, PMVM.APforce);
        previousSimulationForce = currentSimulationForce;
        
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
        
        if(!used)
        {
            
        
            ballcol.GetComponent<Rigidbody>().AddForce(forectoapply);
           
            if(other.name == "Player")
            {
                FindAnyObjectByType<SMScript>().playtrack("FPbell");
                used  = true;
            }
          Debug.Log("Triggered");
        
        }

    }
  
    
    public void ProjectionSlider()
    {
        forectoapply = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
        updateStatProjection();
        

    }
    public void ClickButtonFP()
    {   
        
        if(FindAnyObjectByType<SCScript>().mainhud.gameObject.activeSelf)
        {
        looktooglebutton.gameObject.SetActive(true);
        Panel.SetActive(true);
        thirdCam.LookAt = this.transform;
        thirdCam.Follow = this.transform;
        animator.Play("ViewOtherEnt");
        mainhub.gameObject.SetActive(false);
        try
        {
              GetComponent<TriggerPoint>().triggerobj.SetActive(false);
        }
        catch
        {

        }
        }
      
        //hidePlats.GetComponent<UImanager>().ActivateControl(false);
    }
    public void SetFpValue()
    {
     
        Panel.SetActive(false);
        looktooglebutton.gameObject.SetActive(false);
        animator.Play("PlayerCam");
         mainhub.gameObject.SetActive(true);
        forectoapply = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
        FindAnyObjectByType<UImanager>().ActivateControl(true);
        try
        {
              GetComponent<TriggerPoint>().triggerobj.SetActive(true);
        }
        catch
        {

        }
      
    }
    public void VectorReset()
    {
        Xslider.value = 0;
        Yslider.value = 0;
        Zslider.value = 0;
    }
   
   
     public void sliderchanged(string Axis)
    {

         XtextValue.text = Xslider.value.ToString("0.0");
        YtextValue.text = Yslider.value.ToString("0.0");
        ZtextValue.text = Zslider.value.ToString("0.0");
        Vector3 force = new Vector3(Xslider.value, Yslider.value, Zslider.value);
        if(force == Vector3.zero)
        {
            arrow.gameObject.SetActive(false);
        }
        else
        {
            arrow.gameObject.SetActive(true);
        }

        float angleArrow = Mathf.Acos(Vector3.Dot(new Vector3(0, 1, 0), force) / force.magnitude);
        Vector3 axisArrowRot = Vector3.Cross(new Vector3(0, 1, 0), force);
       // arrow.transform.rotation = Quaternion.identity * Quaternion.LookRotation(axisArrowRot * angleArrow); 
            arrow.transform.rotation = Quaternion.identity * Quaternion.LookRotation(force, axisArrowRot * angleArrow);
    }

    public void updateStatProjection()
    {
        
       previewsProjPF= ProjectFP.SimulateFP(this,this.transform.position,forectoapply,previewsProjPF);
    }
  void start()
  {
   
    ProjectionSlider();
    
  }
}


}
