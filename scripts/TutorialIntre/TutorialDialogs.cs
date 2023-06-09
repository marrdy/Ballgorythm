using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogs : MonoBehaviour
{
    // Start is called before the first frame update
    
    public SetOfDialogs[] sod;
    int IndexDialog =0;
    void Start()
    {
       StartCoroutine("FirstMessage");
    }

    IEnumerator FirstMessage()
    {
        yield return new WaitForSeconds(4);
        ShowDialog(IndexDialog);
    }
    
    public void ShowDialog(int index)
    {   
      sod[index].dcc.gameObject.SetActive(true);
      sod[index].dcc.dclass.dialogtext.text = sod[index].text;
      foreach(GameObject go in sod[index].controlToenable)
     {
        go.SetActive(true);
    
     }
     //check if its a local trigger
      if( sod[index].LocalTrigger)
      {
        sod[index].dcc.dclass.DialogLocalTrigger.SetActive(true);
     sod[index].dcc.dclass.DialogLocalTrigger.AddComponent<Button>().onClick.AddListener(delegate{nexdialog( sod[index].dcc.dclass.DialogLocalTrigger.GetComponent<Button>(),index);});

      
    }
      else
      {
        sod[index].dcc.dclass.DialogLocalTrigger.SetActive(false);
          //check if theres already a button component
        if(sod[index].NextDialogTrigger.GetComponent<Button>() != null)
        {
            //it ha a button component 
            sod[index].NextDialogTrigger.GetComponent<Button>().onClick.AddListener(delegate{nexdialog(sod[index].NextDialogTrigger.GetComponent<Button>(),index);});
        
        }
        else
        {
            // check if its a slider
            if(sod[index].NextDialogTrigger.GetComponent<Slider>() != null)
            {
                //it has a slider component
                sod[index].NextDialogTrigger.GetComponent<Slider>().onValueChanged.AddListener(delegate {SliderSingleCall( sod[index].NextDialogTrigger.GetComponent<Slider>(),sod[index].SliderValueTrigger,index); });
            }
            else
            {
                //it doesnt have button component
            
             sod[index].NextDialogTrigger.AddComponent<Button>().onClick.AddListener(delegate{nexdialog(sod[index].NextDialogTrigger.GetComponent<Button>(),index);});
            }
        }
      }
  
     
    }
    
    public void nexdialog(Button listrem, int index)
    {
      if(IndexDialog == index)
      {
        sod[IndexDialog].dcc.gameObject.SetActive(false);
        IndexDialog++;
        listrem.onClick.RemoveListener(delegate{nexdialog(sod[index].NextDialogTrigger.GetComponent<Button>(),index);});
        ShowDialog(IndexDialog);
      }
        
    }

  public void SliderSingleCall(Slider slider, float triggerpoint, int index)
    {
      
        if(slider.value-(slider.maxValue/2) ==triggerpoint&& IndexDialog == index)
        {
        sod[IndexDialog].dcc.gameObject.SetActive(false);
        IndexDialog++;
        ShowDialog(IndexDialog);

        }
    }
}
  [System.Serializable]
    public class SetOfDialogs
    {
      [SerializeField] public DialogContentClass dcc;
      [TextArea(3, 10)]   public string text;
        
         public GameObject[] controlToenable;
          public bool LocalTrigger = true;
        public GameObject NextDialogTrigger;
        public float SliderValueTrigger;
    }
  
