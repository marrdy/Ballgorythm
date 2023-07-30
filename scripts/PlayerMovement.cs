
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
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
    [SerializeField] public SceneProj _projection;



    float SlowExecution;
    private void Update()
    {
       
        Vector3 currentSimulationForce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
    if (notyetpushed && currentSimulationForce != APforce && AimAssistExtend)
    {
        _projection.SimulateTrajectory(this, startpos, currentSimulationForce * 2);
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


        if (Axis == "x")
        {
            xformula = xslider.value - (xslider.maxValue / 2);
            xvalue.text = xformula.ToString("0.0");
        }
        else if (Axis == "y")
        {
            yformula = yslider.value - (yslider.maxValue / 2);
            yvalue.text = yformula.ToString("0.0");
        }
        else if (Axis == "z")
        {
            zformula = zslider.value - (zslider.maxValue / 2);
            zvalue.text = zformula.ToString("0.0");
        }



    }

    public void initpush(Vector3 force)
    {
        rb.AddForce(force);
    }
    public void Push()
    {
        timercounter.counting = true;
        if (notyetpushed) {

            xformula = xslider.value - (xslider.maxValue / 2);
            yformula = yslider.value - (yslider.maxValue / 2);
            zformula = zslider.value - (zslider.maxValue / 2);
            ActiveSinceFirstPlace = ShowEntToggle.activeSelf;
            ShowEntToggle.SetActive(false);
            uimanager.ActivateControl(false);
            APforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
            FindAnyObjectByType<SMScript>().playtrack("Push");
            initpush(APforce * 2);
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
        _projection.SimulateTrajectory(this, startpos, simulationforce * 2);
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
          SecondForce[] secondForceScripts = FindObjectsOfType<SecondForce>();
            foreach (SecondForce secondForce in secondForceScripts)
            {
                // Call TriggerBFP(false) on each object with the "SecondForce" script
                secondForce.TriggerBFP(true);
            }
    }


    public void VectorReset()
    {
        xslider.value = 1000;
        yslider.value = 1000;
        zslider.value = 1000;
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
