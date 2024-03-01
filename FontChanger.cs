using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontChanger : MonoBehaviour
{
    SMScript sms;
    
    public TMP_Text[] Alltext;
    void Start()
    {
        while(sms == null)
        {
            
            sms = FindAnyObjectByType<SMScript>();
           
        }
        setAlltextFont();
    }
    public void setAlltextFont() 
    {
        foreach (TMP_Text txt in Alltext)
        {
            txt.font = sms.Font[sms.selectedFont];
        }
    }
    // Update is called once per frame
   
}
