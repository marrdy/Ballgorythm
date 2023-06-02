
using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPannels : MonoBehaviour
{
    public GameObject[] GuidePannels;
    public Collider Goal;
    public GameObject gamefinish;

    public void NextButtonPressed(int ButtonNumber)
    {


        try
        {
            if (GuidePannels.Length != 0)
            {
                GuidePannels[ButtonNumber].SetActive(true);
                if (ButtonNumber != 0)
                {

                    GuidePannels[ButtonNumber - 1].SetActive(false);
                }
            }
        }
            catch (Exception)
        {

        }
        

    }

    public void EndofTutorial(int ButtonNumber)
    {
        GuidePannels[ButtonNumber].SetActive(false);
        gamefinish.SetActive(true);
        Debug.Log(GuidePannels[ButtonNumber].name);
    }

    public void closepanel(GameObject selfclose)
    {
        selfclose.SetActive(false);
    }

    public void TutorialFinalPanel(int pannelNumber)
    {
        GuidePannels[pannelNumber].SetActive(true);

    }

}
