using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Veloreader : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rbSecondImpact;
    public RectTransform Xhand;
    public RectTransform Zhand;
    public TMP_Text Yvelo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
                Xhand.transform.localScale = new Vector2((rbSecondImpact.velocity.x / 5) + 1, 1);
                Zhand.transform.localScale = new Vector2(1, (rbSecondImpact.velocity.z / 5) + 1);
                Yvelo.text =rbSecondImpact.velocity.y.ToString("0.0");
            
           
        }
        catch (Exception)
        {
          
        }
    }
}
