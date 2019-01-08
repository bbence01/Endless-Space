using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores
{
    public float score;
    public string name;

}

public class Score_manager : MonoBehaviour
 {

    public Text scoretext;    
    public Text highscoretext;
   

    public float scorecount;    
    public float highscorecount;

    public float pointPS;

    public bool scoreincreaseing;        

    public bool shoulddouble;
 

	void Start () {
        if ( (PlayerPrefs.HasKey("Bestscore") ))   
        {
            highscorecount = PlayerPrefs.GetFloat("Bestscore");
            }
            

		
	}
	
	void Update () {

        if (scoreincreaseing)
        {
            if (shoulddouble)
            {
                scorecount += (pointPS * 2) * Time.deltaTime;
            }
            else
            {
                scorecount += pointPS * Time.deltaTime;
            }
        }

       if(scorecount>highscorecount)
        {
            highscorecount = scorecount;

            PlayerPrefs.SetFloat("Bestscore", highscorecount);         

        }

        scoretext.text = "Score: " + Mathf.Round(scorecount);
        highscoretext.text = " High Score: " + Mathf.Round(highscorecount);
	}
    

    public void Addscore(int pointstoadd)          
    {
     

        if(shoulddouble)
        {
            scorecount += pointstoadd*2;
       
            
        }
        else
        {
            scorecount += pointstoadd;
        }


    }



    



}

