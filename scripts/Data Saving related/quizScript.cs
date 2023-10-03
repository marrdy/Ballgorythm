using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using playerscript;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
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
    [SerializeField][Range(1f,0f)] private float tolerance = 0.01f;
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
   public void quizSaver(bool correct,string description)
   {
      AchievementsLoader loader = new AchievementsLoader();
    if(correct)
        {
            achiveclass []VarLoaded;
            AchievementAdder LoadedData = DataSaver.LoadAchievements(loader.adder);
            VarLoaded = LoadedData.achivecache;
            VarLoaded[quizNo].Achived = true;
            VarLoaded[quizNo].AchivementDescription =description;
            loader.adder = VarLoaded;
            DataSaver.AchivementDataSave(loader);
        }
   }
   public void showInfo(bool set)
   {
      InfoPannel.gameObject.SetActive(set);
   }
public bool CheckAnswerIdent()
{
    string inputText = AnswerSlot.text;
    
    if (float.TryParse(inputText, out float userInput) && float.TryParse(answer, out float correctAnswer))
    {
        float difference = Mathf.Abs(Mathf.Abs(userInput) - Mathf.Abs(correctAnswer));
        
        if (difference <= tolerance)
        {
            FindAnyObjectByType<SMScript>().playtrack("CorrectAnsounds");
            QuizPannel.gameObject.SetActive(false);
            this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.green;
            this.gameObject.GetComponentInChildren<TMP_Text>().text = "Quiz Done";
            return true;
        }
        else
        {
            FindAnyObjectByType<SMScript>().playtrack("Chalkcrack"); 
            AnswerSlot.image.color = Color.red;
        }
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
        string desc =  answer+"m/s = "+ distant.ToString("0.00")+"m / "+time.ToString("0.00")+"s";
        quizSaver(correct,desc);
    }
    public void calculateNetforce()
    {
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000); 
        float kg = PMM.GetComponent<Rigidbody>().mass;
        float totalNetForce= (float)Math.Sqrt(x*x + y*y + z*z);
        answer = totalNetForce.ToString("0.00");
         AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc =answer+"Fn = ²√("+x.ToString("0.00")+"N²"+" + "+z.ToString("0.00")+"N²"+")";
        quizSaver(correct,desc);
      
    }
    public void calculateWeight()
    {   
        float mass = PMM.GetComponent<Rigidbody>().mass;
        float weight = mass * 9.81f;
        answer = weight.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc =answer+"kg = "+ mass.ToString("0.00") +"kg x 9.81(Force due to gravity)";
        quizSaver(correct,desc);
    }
    public void calculateVelocityOneSecDeftime()
    {
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000); 
        float mass = PMM.GetComponent<Rigidbody>().mass;
        float fnet= (float)Math.Sqrt(x*x + y*y + z*z);
        float v = fnet/mass;
        v = v*v;
        answer = v.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc =answer+"m/s = "+fnet.ToString("0.00")+"N / "+mass.ToString("0.00")+"kg";
        quizSaver(correct,desc);
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
        string desc=answer+"kg·m/s  = "+v.ToString("0.00")+"m/s x "+mass+"kg";
        quizSaver(correct,desc);
       
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
        string desc=answer+"m/s² ="+"0(initial Velocity) +" +a+"m/s² x "+time+"s";
        quizSaver(correct,desc);
       
    }
    public void calculateDisplace(int time)
    {
        float mass = PMM.rb.mass;
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
        float f = (float)Math.Sqrt(x*x + y*y + z*z);
        float a = f/mass;
        float v = 0 + a*time;
        float s= (float)0.5*(v+0)*time;
        answer = s.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc=s.ToString("0.00")+"m = ½ x ("+v.ToString("0.00")+"m/s² + 0m/s²) x "+time.ToString("0.00")+"s";
        quizSaver(correct,desc);
       
    }
    public void calculateDecelerate(int time)
    {
        float mass = PMM.rb.mass;
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
        float f = (float)Math.Sqrt(x*x + y*y + z*z);
        float a = f/mass;
        float v = 0 + a*time;
        float s= (float)0.5*(v+0)*time;
        float _a =(v*v-0)/(s-time);
        answer = _a.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc=s.ToString("0.00")+"m = ½ x ("+v.ToString("0.00")+"m/s² + 0m/s²) x "+time.ToString("0.00")+"s";
        quizSaver(correct,desc);
    }
    public void calculateKE(int time)
    {
        float mass = PMM.rb.mass;
        float x = Math.Abs(float.Parse(PMM.xvalue.text)/1000);
        float y = Math.Abs(float.Parse(PMM.yvalue.text)/1000);
        float z = Math.Abs(float.Parse(PMM.zvalue.text)/1000);
        float f = (float)Math.Sqrt(x*x + y*y + z*z);
        float a = f/mass;
        float v = 0 + a*time;
        double KE = 0.5 * mass * Math.Pow(v, 2);
        answer= KE.ToString("0.00");
        AchievementsLoader loader = new AchievementsLoader();
        bool correct = CheckAnswerIdent();
        string desc=answer+"j ="+"½ x " +mass+"kg x "+v+"m/s²";
        quizSaver(correct,desc);
       
    }
}
