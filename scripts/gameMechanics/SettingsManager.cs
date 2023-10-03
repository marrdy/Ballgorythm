using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
public Slider MusicVslider;
public Slider sfxVslider;
public Slider SensitivityX;
public Slider SensitivityY;
void Start()
{
    SMScript Sms = FindAnyObjectByType<SMScript>();
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
}
