using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using playerscript;
public class quizScript : MonoBehaviour
{
    public int quizNo;
    [TextArea(3, 10)]
   public string question;
   public string answer;
   public TMP_InputField AnswerSlot;
   public TMP_Text Question;
   public TMP_Text mass;
   public TMP_Text Dist;
   public TMP_Text Xval;
   public TMP_Text Yval;
   public TMP_Text Zval;
   public TMP_Text Duration;

   public Image QuizPannel;
   public Image InfoPannel;
   public PlayerMovement PMM;
   public Goalscript GS;
   float dur;
   bool done= false;
   
   
   void Start()
   {
    AchievementsLoader loader = new AchievementsLoader();
    achiveclass []VarLoaded;
    AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
    VarLoaded = LoadedData.achivecache;
    if(VarLoaded[quizNo].Achived)
    {
        this.GetComponent<Button>().onClick.RemoveAllListeners();
        this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.green;
        this.gameObject.GetComponentInChildren<TMP_Text>().text= "Quiz Done";
        done= true;
        return;
    }

    Question.text = question;
    mass.text = "Mass:"+PMM.GetComponent<Rigidbody>().mass.ToString()+" KG";
    Dist.text = "Distances:"+Vector3.Distance(PMM.transform.position , GS.transform.position).ToString("0");
    Xval.text = "X/1000 = "+Math.Abs(float.Parse(PMM.xvalue.text)/1000).ToString()+" Newton";
    Yval.text = "Y/1000 = "+Math.Abs(float.Parse(PMM.yvalue.text)/1000).ToString()+" Newton";
    Zval.text = "Z/1000 = "+Math.Abs(float.Parse(PMM.zvalue.text)/1000).ToString()+" Newton";
    dur = PMM.timercounter.LimitedTime-PMM.timercounter.TimeRemains;
    Duration.text = "Time:"+dur.ToString("0.00");
    
   }
   
   public void showQuizBoard(bool set)
   {
      if(!done)
      {
        QuizPannel.gameObject.SetActive(set);
      }  
   }

   public void showInfo(bool set)
   {
      InfoPannel.gameObject.SetActive(set);
   }
   public bool CheckAnswerIdent()
    {
        string inputText = AnswerSlot.text;
        if (string.Equals(inputText, answer, StringComparison.OrdinalIgnoreCase))
        {
            FindAnyObjectByType<SMScript>().playtrack("CorrectAnsounds");
            QuizPannel.gameObject.SetActive(false);
            this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.green;
            this.gameObject.GetComponentInChildren<TMP_Text>().text= "Quiz Done";
            return true;
        }
        else
        {
                FindAnyObjectByType<SMScript>().playtrack("Chalkcrack"); 
                AnswerSlot.image.color = Color.red;
        }
        Debug.Log("Answer:" + answer);
        return false;
    }
    public void calculateVelo()
    {
        float distant = Vector3.Distance(PMM.startpos , GS.transform.position);
        float time = dur;
        float velo = distant / time;
        answer = velo.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription = answer+"m/s = "+ distant.ToString("0.00")+"m / "+time.ToString("0.00")+"s";
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
    }
    public void calculateNetforce()
    {
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000); 
        float kg = PMM.GetComponent<Rigidbody>().mass;
        float totalNetForce= (float)Math.Sqrt(x * x + z * z);
        answer = totalNetForce.ToString("0.00");
         AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        if(correct)
        {
        achiveclass []VarLoaded;
        AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
        VarLoaded = LoadedData.achivecache;
        VarLoaded[quizNo].Achived = true;
        VarLoaded[quizNo].AchivementDescription =answer+"Fn = ²√("+x.ToString("0.00")+"N²"+" + "+z.ToString("0.00")+"N²"+")";
        loader.adder = VarLoaded;
        DataSaver.AchivementDataSave(loader);
        }
    }
    public void calculateWeight()
    {   
        float mass = PMM.GetComponent<Rigidbody>().mass;
        float weight = mass * 9.81f;
        answer = weight.ToString("0.00");
         AchievementsLoader loader = new AchievementsLoader();
          bool correct = CheckAnswerIdent();
        if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription =answer+"kg = "+ mass.ToString("0.00") +"kg x 9.81(Force due to gravity)";
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
    }
    public void calculateMagVel()
    {
        float forceX = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float forceY = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float forceZ = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
        float mass = PMM.GetComponent<Rigidbody>().mass;
        float accelerationX = forceX / mass;
        float accelerationY = forceY / mass;
        float accelerationZ = forceZ / mass;
        float velocityMagnitude = Mathf.Sqrt((accelerationX * accelerationX) + (accelerationY * accelerationY) + (accelerationZ * accelerationZ));

        answer = velocityMagnitude.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription =answer+"Vm = ²√("+accelerationX.ToString("0.00")+"m/s²"+" + "+accelerationY.ToString("0.00")+"m/s²"+" + "+forceZ.ToString("0.00")+"m/s²"+")";
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
    }
    public void calculateMomentum()
    {
            float forceX = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
            float forceY = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
            float forceZ = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
            float mass = PMM.GetComponent<Rigidbody>().mass;
            float accelerationX = forceX / mass;
            float accelerationY = forceY / mass;
            float accelerationZ = forceZ / mass;
            float v = Mathf.Sqrt((accelerationX * accelerationX) + (accelerationY * accelerationY) + (accelerationZ * accelerationZ));
            float p = v*mass;
            answer = p.ToString("0.00");
             AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription ="p"+answer+" = "+v.ToString("0.00")+"m/s x "+mass+"kg";
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
    }
    public void calculateFvelo(int time)
    {
        float mass = PMM.rb.mass;
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
        float f = (float)Math.Sqrt(x*x + y*y + z*z);
        float a = f/mass;
        float v = 0 + a*time;
        answer= v.ToString("0.00");
         AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription =answer+"m/s² ="+"0(initial Velocity) +" +a+"m/s² x "+time+"s";
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
    }
}
