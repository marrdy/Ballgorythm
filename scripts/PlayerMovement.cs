
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
using Cinemachine;
namespace playerscript{
public class PlayerMovement : MonoBehaviour
{
    public Vector3 APforce;
    public Vector3 startpos;
    public UImanager uimanager;
    public bool OnSecondForce = false;
    public bool AimAssistExtend;
    public Rigidbody rb;
    public Collider cldplayer;
    public Slider xslider;
    public Slider yslider;
    public Slider zslider;
    public Button push;
    public TMP_InputField xvalue;
    public TMP_InputField yvalue;
    public TMP_InputField zvalue;
    public Image panel;
    public TMP_Text ptext;
    public TrailRenderer trail;
    public GameObject ShowEntToggle;
    public bool notyetpushed = true;
    public Transform playerpos;
    public Image star;
    bool ActiveSinceFirstPlace;
    float xformula;
    float yformula;
    float zformula;
    public GameObject AAEbutton;
    public timerPush timercounter;
    public Goalscript gs;
    Vector3 currentSimulationForce;
    [SerializeField] public SceneProj _projection;



    float SlowExecution;
    private void Update()
    {
       
         currentSimulationForce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
    if (notyetpushed && currentSimulationForce != APforce && AimAssistExtend)
    {
        _projection.SimulateTrajectory(this, startpos, currentSimulationForce);
        APforce = currentSimulationForce;
    }

    }

    IEnumerator linesimulate()
{
    yield return new WaitForSeconds(0.2f);

     
    yield return null;
}
    private static SecondForce[] FT;

    void Start()
    {
        startpos = playerpos.position;

        
    }

    
       

    


    public void sliderchanged(string Axis)
    {


            xvalue.text = xslider.value.ToString("0.0");
            yvalue.text = yslider.value.ToString("0.0");
            zvalue.text = zslider.value.ToString("0.0");
        



    }

    public void initpush(Vector3 force)
    {
        rb.AddForce(force);
    }
    public void Push()
    {
         
        timercounter.counting = true;
        if (notyetpushed) {

                xformula = xslider.value;
                yformula = yslider.value;
                zformula = zslider.value;
            ActiveSinceFirstPlace = ShowEntToggle.activeSelf;
            ShowEntToggle.SetActive(false);
            uimanager.ActivateControl(false);
            APforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
            FindAnyObjectByType<SMScript>().playtrack("Push");
            initpush(APforce);
            ptext.text = "Retry";
            notyetpushed = false;
            this.GetComponent<LineRenderer>().enabled = false;

        }
        else
        {
            
               again();
        }
    }
    public void again()
    {
         
        ShowEntToggle.SetActive(true);
        uimanager.ActivateControl(true);
        if (ActiveSinceFirstPlace) { ShowEntToggle.SetActive(true); }
        Vector3 simulationforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
        this.GetComponent<LineRenderer>().enabled = true;
        _projection.SimulateTrajectory(this, startpos, simulationforce);
         ptext.text = "Push";
        notyetpushed = true;
        this.GetComponent<LineRenderer>().enabled = true;
        timercounter.resettimer();
        rb.isKinematic = !rb.isKinematic;
        rb.isKinematic = !rb.isKinematic;
        transform.position = startpos;
        panel.enabled = true;
        notyetpushed = true;
        cldplayer.isTrigger = false;
        ptext.text = "Push";
        trail.Clear();
          TriggerPoint[] TP = FindObjectsOfType<TriggerPoint>();
            foreach (TriggerPoint TrigPoint in TP)
            {
                TrigPoint.triggerobj.SetActive(true);
            }
            SecondForce[] SP = FindObjectsOfType<SecondForce>();
            foreach (SecondForce Secpoint in SP)
            {
                
                Secpoint.used = false;
            }
    }


    public void VectorReset()
    {
        xslider.value = 0;
        yslider.value = 0;
        zslider.value = 0;
        xvalue.text = 0.ToString();
        yvalue.text = 0.ToString();
        zvalue.text = 0.ToString();

    }

    public void ExtendAimAssist()
{       
        AimAssistExtend = true;
        AAEbutton.SetActive(false);
        gs.NoAimAssist = false;
        star.color = Color.gray;
}
public void hidepann()
{
    panel.gameObject.SetActive(false);
}
public void ShowPan()
{
    panel.gameObject.SetActive(true);
}

}

}
