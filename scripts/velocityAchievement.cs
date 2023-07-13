using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityAchievement : MonoBehaviour
{
    
   public int indexOfAchievement;
    public GameObject dialog; 
    bool highspeed;
    public void pushed()
    {
        StartCoroutine(ReadVelocity());
    }
    
   IEnumerator ReadVelocity()
    {
        Debug.Log("Lift off");
     yield return new WaitForSeconds(1);
        float combinevelos =this.GetComponent<Rigidbody>().velocity.x+this.GetComponent<Rigidbody>().velocity.y+this.GetComponent<Rigidbody>().velocity.z;
        if( combinevelos>= 10000000000 && !highspeed )
        {
            triggerach();
            Debug.Log("Traveling at speed of light");
            highspeed = true;
        }
    }
    public void triggerach()
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
