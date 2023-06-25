using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timerPush : MonoBehaviour
{
    // Start is called before the first frame update

    public float SecondsPassed;
    public bool counting;
    public float timeEnd;
    TMP_Text displaytime;
    
    void Start()
    {
        displaytime = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            SecondsPassed = SecondsPassed + (1 * Time.deltaTime);
            displaytime.text = "Time : " + SecondsPassed.ToString("0.0");
        }
    }
    public void resettimer()
    {
        counting = false;
        SecondsPassed = 0;
        displaytime.text ="";
    }
    public void finishtime()
    {
        counting = false; 
        timeEnd = SecondsPassed;


    }
   
}
