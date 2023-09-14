using System.Collections;
using playerscript;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class timerPush : MonoBehaviour
{
    // Start is called before the first frame update

    public float TimeRemains;
    
    public bool counting;
    public float timeEnd;
    float timeforstar;
    public float starlimitedtime;
    public Goalscript gs;
    TMP_Text displaytime;
    public TMP_Text starTimeLabel;
    public float LimitedTime = 10;
    public Image star;
    public PlayerMovement playerstat;
 
    
    void Start()
    {
        displaytime = GetComponent<TMP_Text>();
         resettimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
           
            TimeRemains = TimeRemains - (1 * Time.deltaTime);
            timeforstar = timeforstar - (1 * Time.deltaTime);
            displaytime.text = "Time : " + TimeRemains.ToString("0.0");
            starTimeLabel.text = " : "+timeforstar.ToString("0.0");
        }
        if(TimeRemains <= 0)
        {
            playerstat.again();
            resettimer();
        }
        if(timeforstar<=0)
        {
            gs.Intime= false;
            starTimeLabel.color = Color.red;
            star.color = Color.grey;
        }
        else
        {
            starTimeLabel.color = Color.yellow;
             star.color = Color.yellow;
        }
    }
    public void resettimer()
    {
       
        counting = false;
        star.color = Color.yellow;
        TimeRemains = LimitedTime;
        timeforstar = starlimitedtime;
        gs.Intime= true;
         displaytime.text = "Time : " + TimeRemains.ToString("0.0");
            starTimeLabel.text = " : "+timeforstar.ToString("0.0");
    }
    public void finishtime()
    {
        counting = false; 
        timeEnd = TimeRemains;
    }
   
}
