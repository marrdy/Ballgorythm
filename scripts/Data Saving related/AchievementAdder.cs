using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AchievementAdder
{

    public achiveclass[] achivecache;


    public AchievementAdder(AchievementsLoader data)
    {
        achivecache = data.adder;
       
    }
}
[System.Serializable]
public class achiveclass
{
    [TextArea(1, 7)] public string AchivementName;
    [TextArea(3, 10)] public string AchivementDescription;
    public bool Achived;
}
