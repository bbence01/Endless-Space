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

    public Text scoretext;  //a kiírt értékek
    public Text highscoretext;
   

    public float scorecount; // számolák a pontokat
    public float highscorecount;

    public float pointPS;

    public bool scoreincreaseing; // ha nem vagyunk halottak nő az érték

    public bool shoulddouble;
 

	// Use this for initialization
	void Start () {
        if ( (PlayerPrefs.HasKey("Bestscore") )) // ha létezik
        {
            highscorecount = PlayerPrefs.GetFloat("Bestscore");
            }
            

		
	}
	
	// Update is called once per frame
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

            PlayerPrefs.SetFloat("Bestscore", highscorecount); // egyszerű mentési modszer ( mit ment és hove)

        }

        scoretext.text = "Score: " + Mathf.Round(scorecount);
        highscoretext.text = " High Score: " + Mathf.Round(highscorecount);
	}
    

    public void Addscore(int pointstoadd) // bárhonnan hívható metódus ami ponot add a jelenlegi pontszámhoz
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

    /*public void AddScore( string name , int score)
    {
        int newScore;
        string newName;

        int oldScore;
        string oldName;

        newScore = score;
        newName = name;

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + " HScore"))
            {
                if (PlayerPrefs.GetInt(i + " HScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i + " HScore");
                    oldName = PlayerPrefs.GetString(i + " HScoreName");
                    PlayerPrefs.SetInt(i + " HScore", newScore);
                    PlayerPrefs.SetString(i + " HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + " HScore ", newScore);
                PlayerPrefs.SetString(i + " HScoreName ", newName);
                newScore = 0;
                newName = "";
            }
        }
    }*/



    



}

