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
    public AchivementDatasHolder quizHolder;
    public int quizNo;
    [TextArea(3, 10)]
    public string question;
    public string answer;
    public string formula;
    public TMP_InputField AnswerSlot;
    public TMP_Text Question;
    public TMP_Text formulaDisplay;
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
    public float distance;
    public AchivementDatas quizfromachievement;
    float dur;
    bool done= false;
    [SerializeField][Range(1f,0f)] private float tolerance =0.05f;
    void Start()
    {
        quizfromachievement.achivementInfo = quizHolder.data.achivementInfo;
        quizInitiate();
    }
    public void quizInitiate() 
    {

        quizfromachievement = DataSaver.loadAchivementDatas(quizfromachievement);
        if (quizfromachievement.achivementInfo[quizNo].Achived)
        {
           
            this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.green;
            this.gameObject.GetComponentInChildren<TMP_Text>().text = "Quiz";
            done = true;
            
        }

        Question.text = question;
        formulaDisplay.text = formula;
        mass.text = "Mass(m):" + PMM.GetComponent<Rigidbody>().mass.ToString() + " g";
        distance = Vector3.Distance(PMM.transform.position, GS.transform.position);
        Dist.text = "Distances(d):" + distance.ToString("0.00") + "m(meters)";
        Xval.text = "X/1000 = " + Math.Abs(float.Parse(PMM.APforce.x.ToString()) / 1000).ToString() + " Newton";
        Yval.text = "Y/1000 = " + Math.Abs(float.Parse(PMM.APforce.y.ToString()) / 1000).ToString() + " Newton";
        Zval.text = "Z/1000 = " + Math.Abs(float.Parse(PMM.APforce.z.ToString()) / 1000).ToString() + " Newton";
        dur = PMM.timercounter.LimitedTime - PMM.timercounter.TimeRemains;
        Duration.text = "Time(t):" + dur.ToString("0.00")+" (sec)";

    }
    public void showQuizBoard(bool set)
   {
      
        QuizPannel.gameObject.SetActive(set);
      
   }
   public void quizSaver(bool correct,string description)
   {
      AchievementsLoader loader = new AchievementsLoader();
    if(correct)
        {
            
            
            quizfromachievement.achivementInfo[quizNo].Achived = true;
            quizfromachievement.achivementInfo[quizNo].AchivementDescription = quizfromachievement.achivementInfo[quizNo].AchivementDescription + "Your answer: " + description;

            DataSaver.SavingAchievement(quizfromachievement);
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
           
            QuizPannel.gameObject.SetActive(false);
            this.gameObject.GetComponentInChildren<TMP_Text>().color = Color.green;
            this.gameObject.GetComponentInChildren<TMP_Text>().text = "Quiz Done";
            GS.starsEarned++;
            GS.star3.color = Color.yellow;
            //if (GS.data.starsInlevels[GS.CurrentLevel - 1] < GS.starsEarned)
            //{
            //   GS.data.starsInlevels[GS.CurrentLevel - 1] = GS.starsEarned;
            //}
            //LevelLocker datatosave = new LevelLocker();
            //datatosave.starsperlevel = GS.data.starsInlevels;
            //datatosave.CurrentLevel = GS.data.CurrentLevel;
            //DataSaver.ProgressData(datatosave);
                FindAnyObjectByType<SMScript>().playtrack("CorrectAnsounds");
                return true;
        }
        else
        {
           
            AnswerSlot.image.color = Color.red;
            FindAnyObjectByType<SMScript>().playtrack("Chalkcrack");
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000); 
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000); 
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000);
        float mass = PMM.GetComponent<Rigidbody>().mass;
        float f = (float)Math.Sqrt(x * x + y * y + z * z);
        float v = f / mass;
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000);
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000);
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000);
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
        float x = Math.Abs(float.Parse(PMM.APforce.x.ToString())/1000);
        float y = Math.Abs(float.Parse(PMM.APforce.y.ToString())/1000);
        float z = Math.Abs(float.Parse(PMM.APforce.z.ToString())/1000);
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
