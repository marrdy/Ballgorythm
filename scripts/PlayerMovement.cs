
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
    bool ActiveSinceFirstPlace;
    float xformula;
    float yformula;
    float zformula;
    public GameObject AAEbutton;
  
    [SerializeField] private SceneProj _projection;


    float SlowExecution;
    private void Update()
    {
        if (SlowExecution <= 1)
        {
            SlowExecution = SlowExecution + 1 * Time.deltaTime;
        }
        else
        {
            if (notyetpushed)
            {
                Vector3 simulationforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
                _projection.SimulateTrajectory(this, startpos, simulationforce * 2);
            }
            SlowExecution = 0;
        }


    }
    void Start()
    {
        startpos = playerpos.position;


    }



    public void sliderchanged(string Axis)
    {


        if (Axis == "x")
        {
            xformula = xslider.value - (xslider.maxValue / 2);
            xvalue.text = xformula.ToString();
        }
        else if (Axis == "y")
        {
            yformula = yslider.value - (yslider.maxValue / 2);
            yvalue.text = yformula.ToString();
        }
        else if (Axis == "z")
        {
            zformula = zslider.value - (zslider.maxValue / 2);
            zvalue.text = zformula.ToString();
        }



    }

    public void initpush(Vector3 force)
    {
        rb.AddForce(force);
    }
    public void Push()
    {

        if (notyetpushed) {

            xformula = xslider.value - (xslider.maxValue / 2);
            yformula = yslider.value - (yslider.maxValue / 2);
            zformula = zslider.value - (zslider.maxValue / 2);
            ActiveSinceFirstPlace = ShowEntToggle.activeSelf;
            ShowEntToggle.SetActive(false);
            uimanager.ActivateControl(false);



            APforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
            initpush(APforce * 2);
            ptext.text = "Retry";
            notyetpushed = false;
            this.GetComponent<LineRenderer>().enabled = false;

        }
        else
        {
            ShowEntToggle.SetActive(true);
            uimanager.ActivateControl(true);
            if (ActiveSinceFirstPlace) { ShowEntToggle.SetActive(true); }
            Vector3 simulationforce = new Vector3(float.Parse(xvalue.text), float.Parse(yvalue.text), float.Parse(zvalue.text));
            this.GetComponent<LineRenderer>().enabled = true;
            _projection.SimulateTrajectory(this, startpos, simulationforce * 2);
            again();
            ptext.text = "Push";
            notyetpushed = true;
        }
    }
    public void again()
    {
        rb.isKinematic = !rb.isKinematic;
        rb.isKinematic = !rb.isKinematic;
        transform.position = startpos;
        panel.enabled = true;
        notyetpushed = true;
        cldplayer.isTrigger = false;
        ptext.text = "Push";
        trail.Clear();
    }


    public void VectorReset()
    {
        xslider.value = 1000;
        yslider.value = 1000;
        zslider.value = 1000;
    }

    public void ExtendAimAssist()
{
        AimAssistExtend = true;
        AAEbutton.SetActive(false);
}

}
