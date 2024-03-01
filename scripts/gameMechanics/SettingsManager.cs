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
    public volumeSettings vs;
    void Start()
    {

      
    callLoadSettings();
   
    }
    public void setUIvalues()
    {
        MusicVslider.value = vs.musicVolume;
        Debug.Log(vs.musicVolume);
        sfxVslider.value = vs.sfxVolume;
        Debug.Log(vs.sfxVolume);
        SensitivityX.value = vs.SensitivityX;
        SensitivityY.value = vs.SensitivityY;
        fontSelection.value = vs.selectedFont;
    }
    public void SliderMusicSet()
    {
        FindAnyObjectByType<SMScript>().MusicVolume(MusicVslider.value);
        vs.musicVolume = MusicVslider.value;
    }
    public void SliderSFXset()
    {
        FindAnyObjectByType<SMScript>().SFXVolume(sfxVslider.value);
        FindAnyObjectByType<SMScript>().playtrack("FPbell");
        vs.sfxVolume = sfxVslider.value;
    }
   
    public void SliderSenssetX()
    {
     vs.SensitivityX = SensitivityX.value;
    }
    public void SliderSenssetY()
    {
    vs.SensitivityY= SensitivityY.value;
        
    }
    public void VLVolume()
    {
        vs.vlvolume = voiceline.value;
    }
    public void SetFont()
    {
        vs.selectedFont = fontSelection.value;
        FontChanger fc = FindAnyObjectByType<FontChanger>();
        fc.selecetedfont = vs.selectedFont;
        fc.setAlltextFont();
    }
    public void callSaveSettings() 
    {
        DataSaver.SaveVolSetValue(vs);
        FindAnyObjectByType<SMScript>().loadSettings();
    }
    public void callLoadSettings()
    {
        vs = DataSaver.GetVolSetValue(vs);
        setUIvalues();
    
    }
}
