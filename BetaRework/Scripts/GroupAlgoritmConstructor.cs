using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupAlgoritmConstructor : MonoBehaviour
{
   public GameObject Algobutton;
  
   public GAC[] ContructGAC;
   public Ball player;
  
   [HideInInspector]
   public ForceController ForceCon;

   void Start()
{
    
    for(int x = 0; x < ContructGAC.Length; x++)
    {
        int index = x;
        GameObject algobutton =Instantiate(Algobutton,transform.parent); 
        algobutton.transform.SetParent(this.transform);
        ContructGAC[x].FA = algobutton.GetComponent<ForceAlgorithm>();
        ContructGAC[x].FA.index.text = x.ToString();
        ContructGAC[x].FA.AlgorithmIndex = x;
        algobutton.AddComponent<Button>().onClick.AddListener(delegate{BUttonClickHandler(index);});
        ContructGAC[x].FA.transform.localScale = new Vector3(1,1,1);
       
    }

}
public void startpushing()
    {
        if(!player.rolling)
        {

            ForceData[] fd = new ForceData[ContructGAC.Length];
        for (int x = 0; x < ContructGAC.Length; x++)
        {
            fd[x] = ContructGAC[x].FD;
        }
            player.forcesData= fd;
            player.StartApplyingForces();
            ForceCon.PushButton.GetComponentInChildren<TMP_Text>().text = "Retry";
            player.rolling= true;
        }
        else
        {
         player.ResetBall();
         ForceCon.PushButton.GetComponentInChildren<TMP_Text>().text = "Push";
          player.rolling= false;
        }
       
    }

public void BUttonClickHandler(int index)
{
    ForceCon.index = index;
    ForceCon.CurrentAlgoIndex.text = "Algorithm: "+index;
    ForceCon.LoadForceAlgo();
    ForceCon.gameObject.SetActive(true);
    transform.parent.gameObject.SetActive(false);
}
}


[System.Serializable]
public class GAC
{
    public ForceAlgorithm FA;
    public ForceData FD;
}




