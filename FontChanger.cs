using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontChanger : MonoBehaviour
{
    public int selecetedfont;
    
    public TMP_Text[] Alltext;
    public TMP_FontAsset[] allFont;
    void Start()
    {

        selecetedfont = DataSaver.GetSetFont();
        setAlltextFont();
    }
    public void setAlltextFont() 
    {
        foreach (TMP_Text txt in Alltext)
        {
            txt.font = allFont[selecetedfont];
        }
    }
    // Update is called once per frame
   
}
