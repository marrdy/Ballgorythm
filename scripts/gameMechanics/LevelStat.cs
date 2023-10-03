using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class LevelStat : MonoBehaviour
{
    public TMP_Text LevelNumText;
    public Image LockOrCheck;
    public Sprite locker;
     public Sprite Complete;
     public levelclass lc;
     public Image Star1;
       public Image Star2;
       public Image Star3;

       public void starslighter(int amountstars)
       {
        if(amountstars >=1)
        {
            Star1.color = Color.yellow;
             if(amountstars >=2)
                {
              Star2.color = Color.yellow;
                     if(amountstars >=3)
                        {
                        Star3.color = Color.yellow;
                        }

                }


        }
       }
}

[System.Serializable]
public class levelclass
{
public int levelnumber;
public int amountStars;
public bool done;
}
