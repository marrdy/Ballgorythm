using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
public Slider MusicVslider;
public Slider sfxVslider;
public Slider voiceline;
public Slider SensitivityX;
public Slider SensitivityY;
public TMP_Dropdown fontSelection;
    SMScript Sms;
    void Start()
    {
        while (Sms == null) 
        {
            Sms = FindAnyObjectByType<SMScript>();
        }
    
    MusicVslider.value = Sms.musicVolume;
    sfxVslider.value = Sms.sfxVolume;
    SensitivityX.value = Sms.SensitivityX;
    SensitivityY.value = Sms.SensitivityY;
    }
    public void SliderMusicSet()
    {
    FindAnyObjectByType<SMScript>().MusicVolume(MusicVslider.value);
    }
    public void SliderSFXset()
    {
    FindAnyObjectByType<SMScript>().SFXVolume(sfxVslider.value);
    }
    public void SliderSenssetX()
    {
     FindAnyObjectByType<SMScript>().SensitivityX = SensitivityX.value;
    }
    public void SliderSenssetY()
    {
     FindAnyObjectByType<SMScript>().SensitivityY= SensitivityY.value;
    }
    public void VLVolume()
    {
        FindAnyObjectByType<SMScript>().vlvolume = voiceline.value;
    }
    public void SetFont()
    {
        FindAnyObjectByType<SMScript>().selectedFont = fontSelection.value;
        FindAnyObjectByType<FontChanger>().setAlltextFont();
    }

}
