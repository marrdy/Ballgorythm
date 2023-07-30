using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;
namespace playerscript
{
public class SecondForce : MonoBehaviour
{
    public GameObject DissappearOnTrigger;
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
    public bool BlueForcePoint;
    public Button looktooglebutton;
    Collider ballcol;
    float xformula;
    float yformula;
    float zformula;
    public Canvas mainhub;
    public Vector3 forectoapply;
    public SceneProj ProjectFP;
    public GameObject previewsProjPF;
    public LineRenderer TPobjpointer;
    public bool ImProjection;

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
       
        Vector3 currentSimulationForce = new Vector3(float.Parse(XtextValue.text), float.Parse(XtextValue.text), float.Parse(XtextValue.text));
    if (PMVM.notyetpushed && currentSimulationForce !=  previousSimulationForce&&  PMVM.AimAssistExtend)
    {
       
        PMVM._projection.SimulateTrajectory(PMVM, PMVM.startpos, PMVM.APforce * 2);
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
            Vector3 lastvelo = ballcol.GetComponent<Rigidbody>().velocity;
            ballcol.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        if (BlueForcePoint)
        {
            
            if (other.name == "Player")
            {
                 FindAnyObjectByType<SMScript>().playtrack("triggered");
              
               TriggerBFP(false);
            }
        }
        else
        {
             ballcol.GetComponent<Rigidbody>().velocity = lastvelo;
        }
            ballcol.GetComponent<Rigidbody>().AddForce(forectoapply*2);
            if(other.name == "Player")
            {
                FindAnyObjectByType<SMScript>().playtrack("FPbell");
                StartCoroutine("enableAgain");
            }
          
        
        }

    }
   IEnumerator enableAgain()
   {
   
     used=true;
  
    yield return new WaitForSecondsRealtime(0.05f);
      
    used=false;
    
   }
    
    public void ProjectionSlider()
    {
        forectoapply = new Vector3(float.Parse(XtextValue.text), float.Parse(YtextValue.text), float.Parse(ZtextValue.text));
        updateStatProjection();
        FindAnyObjectByType<PlayerMovement>().sliderchanged("");

    }
    public void ClickButtonFP()
    {   if(BlueForcePoint)
    {
        TriggerBFP(false);
    }
        
        if(FindAnyObjectByType<SCScript>().mainhud.gameObject.activeSelf)
        {
        looktooglebutton.gameObject.SetActive(true);
        Panel.SetActive(true);
        thirdCam.LookAt = this.transform;
        thirdCam.Follow = this.transform;
        animator.Play("ViewOtherEnt");
        mainhub.gameObject.SetActive(false);
        }
       
        //hidePlats.GetComponent<UImanager>().ActivateControl(false);
    }
    public void SetFpValue()
    {
        if(BlueForcePoint)
    {
        TriggerBFP(true);
    }
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
       
          DissappearOnTrigger.SetActive(TrigStat);
       
    }
    public void DOTcollide()
    {
        DissappearOnTrigger.SetActive(!DissappearOnTrigger.activeSelf);
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
        
       previewsProjPF= ProjectFP.SimulateFP(this,this.transform.position,forectoapply,previewsProjPF);
    }
  void start()
  {
    if(BlueForcePoint)
    {
        TPobjpointer.enabled =true;
        TPobjpointer.positionCount = 2;
        TPobjpointer.SetPosition(0,transform.position);
        TPobjpointer.SetPosition(1,DissappearOnTrigger.transform.position);
        Debug.Log("asdas");
    }
    else
    {
        TPobjpointer.enabled =false;
    }
    ProjectionSlider();
    
  }
}


}
