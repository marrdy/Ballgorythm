using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderTrigger : MonoBehaviour
{
    public GameObject dialog;
    int indexOfAchievement;
    private void OnTriggerEnter(Collider other)
    {
        string title;
        string descrip;
        AchievementTriggerScripts.AchievementTriggered(indexOfAchievement);
        GameObject spawnDialog = Instantiate(dialog);
        AchievementAdder LoadedData = DataSaver.LoadAchievements();
        spawnDialog.GetComponent<AchievementTabs>().fadein();
        title = LoadedData.achivecache[indexOfAchievement].AchivementName;
        descrip = LoadedData.achivecache[indexOfAchievement].AchivementDescription;
        spawnDialog.GetComponent<AchievementTabs>().Title.text = title;
        spawnDialog.GetComponent<AchievementTabs>().Description.text = descrip;
        StartCoroutine(closedelay(spawnDialog));
    }
    IEnumerator closedelay(GameObject close)
    {
        Debug.Log("closing");
        yield return new WaitForSeconds(2);
        close.GetComponent<AchievementTabs>().fadeout();
        yield return new WaitForSeconds(3);
        Destroy(close);
    }

}
