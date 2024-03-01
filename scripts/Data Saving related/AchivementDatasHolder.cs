using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchivementDatasHolder", menuName = "AchivementDatasHolder", order = 1)]
[System.Serializable]
public class AchivementDatasHolder : ScriptableObject
{
    public AchivementDatas data;
}
[System.Serializable]
public class AchivementDatas
{
    public achiveclass[] achivementInfo;
}
[System.Serializable]
public class achiveclass
{
    [TextArea(1, 7)] public string AchivementName;
    [TextArea(3, 10)] public string AchivementDescription;
    public bool Achived;
}