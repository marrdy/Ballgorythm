using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
   public float SecondsPassed;
    public bool start;
    public float timefinished;
    TMP_Text displaytime;
    void Start()
    {
        displaytime =GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start) 
        {
            SecondsPassed = SecondsPassed + (1 * Time.deltaTime);
            displaytime.text = "Time : "+SecondsPassed.ToString("0.0");
        }
    }
    public void resettimer()
    {

        SecondsPassed = 0;
        start = false;
    }
    public void finished()
    {
        timefinished = SecondsPassed;
        start = false;
    }
}
