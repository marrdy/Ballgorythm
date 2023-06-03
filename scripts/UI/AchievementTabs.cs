using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementTabs : MonoBehaviour
{
    public TMP_Text Title;
    public TMP_Text Description;
    public Toggle AchievedCheck;
    public Animator animator;

    public void fadein()
    {
        animator.Play("AchievementAnimation");
    }
    public void fadeout()
    {
        animator.Play("FadeOutachievement");
    }



}
