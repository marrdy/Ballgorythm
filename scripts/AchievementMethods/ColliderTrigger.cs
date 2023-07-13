using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderTrigger : MonoBehaviour
{
    public GameObject dialog;
    public int indexOfAchievement;
    private void OnTriggerEnter(Collider other)
    {
        string title;
        string descrip;
         AchievementsLoader datatosave = new AchievementsLoader();
        AchievementAdder LoadedData = DataSaver.LoadAchievements(datatosave.adder);
        AchievementTriggerScripts.AchievementTriggered(indexOfAchievement);
         if(!LoadedData.achivecache[indexOfAchievement].Achived)
        {
        GameObject spawnDialog = Instantiate(dialog);
       
        spawnDialog.GetComponent<AchievementTabs>().fadein();
        title = LoadedData.achivecache[indexOfAchievement].AchivementName;
        descrip = LoadedData.achivecache[indexOfAchievement].AchivementDescription;
        spawnDialog.GetComponent<AchievementTabs>().Title.text = title;
        spawnDialog.GetComponent<AchievementTabs>().Description.text = descrip;
           StartCoroutine(closedelay(spawnDialog));
        }
        
    }
    IEnumerator closedelay(GameObject close)
    {
        
        yield return new WaitForSeconds(2);
        close.GetComponent<AchievementTabs>().fadeout();
        yield return new WaitForSeconds(3);
        Destroy(close);
    }

}
