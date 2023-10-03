using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    static string PathForLevel;
    static string PathForAchievement;
    public GameObject confirmationDialogPrefab;

    private MessageBox confirmationDialogInstance;

    void Start()
    {
        PathForLevel = Application.persistentDataPath + "/Progress.Lvlpg";
        PathForAchievement = Application.persistentDataPath + "/AchievementData.Lvlpg";
    }

    public void ResetProgress()
    {
        // Instantiate the confirmation dialog prefab if not already instantiated
        if (confirmationDialogInstance == null)
        {
            confirmationDialogInstance = Instantiate(confirmationDialogPrefab, transform).GetComponent<MessageBox>();
           
        }

        // Show confirmation dialog
        confirmationDialogInstance.SetDialogText("Are you sure you want to reset the progress files? (Doing so will quit the game automatically)");
        confirmationDialogInstance.SetButton1Text("Reset");
        confirmationDialogInstance.SetButton2Text("Cancel");
        confirmationDialogInstance.button1.onClick.AddListener(ConfirmResetProgress);
        confirmationDialogInstance.button2.onClick.AddListener(CancelResetProgress);
        confirmationDialogInstance.ShowDialog();
    }

    public void ConfirmResetProgress()
    {
       if(DataSaver.resetprogress())
       {
         Application.Quit();
       }

    }

    public void CancelResetProgress()
    {
        if (confirmationDialogInstance != null)
        {
            confirmationDialogInstance.HideDialog();
        }
    }
}
