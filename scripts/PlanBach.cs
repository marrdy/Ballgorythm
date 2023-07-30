using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerscript;
public class PlanBach : MonoBehaviour
{
   public GameObject dialog;
   public int indexOfAchievement;
   bool achieved;

   public void Push()
   {
    if(GetComponent<PlayerMovement>().APforce.x ==5 &&GetComponent<PlayerMovement>().APforce.y == 10 && GetComponent<PlayerMovement>().APforce.z == 2023)
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
}
