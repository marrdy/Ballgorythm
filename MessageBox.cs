using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageBox : MonoBehaviour
{
    public TMP_Text dialogText;
    public Button button1;
    public Button button2;

    private bool dialogResult;

    public void SetDialogText(string text)
    {
        dialogText.text = text;
    }

    public void SetButton1Text(string text)
    {
        button1.GetComponentInChildren<TMP_Text>().text = text;
    }

    public void SetButton2Text(string text)
    {
        button2.GetComponentInChildren<TMP_Text>().text = text;
    }

    public void ShowDialog()
    {
        gameObject.SetActive(true);
    }

    public void HideDialog()
    {
        gameObject.SetActive(false);
    }

    public void Button1Clicked()
    {
        dialogResult = true;
        HideDialog();
    }

    public void Button2Clicked()
    {
        dialogResult = false;
        HideDialog();
    }

    public bool GetDialogResult()
    {
        return dialogResult;
    }
}