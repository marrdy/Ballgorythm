
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;
using Cinemachine;
namespace playerscript{
public class PlayerMovement : MonoBehaviour
{
    public bool freePlayMode;
   [Header("Variables")]
   [Space(10)]
    public Vector3 APforce;
    public Vector3 startpos;
    public UImanager uimanager;
    public bool OnSecondForce = false;
    public bool AimAssistExtend;
    public bool notyetpushed = true;
    bool ActiveSinceFirstPlace;
    public Vector3 initvelo;
    Vector3 currentSimulationForce;
    [Header("Components")]
    [Space(10)]
    public Transform playerpos;
    public Goalscript gs;
    public timerPush timercounter;
    public Rigidbody rb;
    public Collider cldplayer;
    public TrailRenderer trail;
    [Header("Sliders")]
    [Space(10)]
    public Slider xslider;
    public Slider yslider;
    public Slider zslider;
    public Button push;
    [Header("Text Intputs")]
    [Space(10)]
    public TMP_InputField xvalue;
    public TMP_InputField yvalue;
    public TMP_InputField zvalue;
    [Header("Game Objects")]
    [Space(10)]
    public Image panel;
    public TMP_Text ptext;
    public GameObject ShowEntToggle;
    public Image star;
    public GameObject AAEbutton;
    [SerializeField] public SceneProj _projection;
   
    private void Update()
    {
       
        currentSimulationForce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
        if (notyetpushed && currentSimulationForce != APforce)
        {
            _projection.SimulateTrajectory(this, transform.position, currentSimulationForce);
            APforce = currentSimulationForce;
        }
           
    }
    void Start()
    {
      startpos = playerpos.position;
    }
        IEnumerator linesimulate()
    {
        yield return new WaitForSeconds(0.2f);
        yield return null;
    }
    private static SecondForce[] FT;

   
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
            if (!freePlayMode)
            {
                transform.position = startpos;
            }
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

    
    public void hidepann()
    {
    panel.gameObject.SetActive(false);
    }
    public void ShowPan()
    {
    panel.gameObject.SetActive(true);
    }


    public void sliderchanged()
    {
            xvalue.text = xslider.value.ToString("0.0");
            yvalue.text = yslider.value.ToString("0.0");
            zvalue.text = zslider.value.ToString("0.0");
    }
    public void xTextChange()
    {
            xslider.maxValue = float.Parse(xvalue.text);  
            xslider.minValue = float.Parse(xvalue.text)* -1; 
            xslider.value = float.Parse(xvalue.text);    
    }
    public void yTextChangey()
    {
        yslider.maxValue = float.Parse(yvalue.text);
        yslider.minValue = float.Parse(yvalue.text) * -1;
        yslider.value = float.Parse(yvalue.text);
    }
    public void zTextChange()
    {
        zslider.maxValue = float.Parse(zvalue.text);
        zslider.value = float.Parse(zvalue.text);
        zslider.minValue = float.Parse(zvalue.text) * -1;
    }
        public void initpush(Vector3 force)
    {
        rb.AddForce(force);
    }
    public void Push()
    { 
        timercounter.counting = true;
        if (notyetpushed){
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
 
}
}
