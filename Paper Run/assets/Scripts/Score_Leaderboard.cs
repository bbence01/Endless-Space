using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Leaderboard : MonoBehaviour {

     


     string name = "";
     string score = "";

    private Score_save scoresave;
    private Audio_manager sound;




    List<Scores> highscore;

    // Use this for initialization
    void Start()
    {
        //EventSystem._instance._buttonClick += ButtonClicked;

        highscore = new List<Scores>();
        scoresave = FindObjectOfType<Score_save>();
        sound = FindObjectOfType<Audio_manager>();

    
        sound.LBMusic();
    
    }




    /*void ButtonClicked(GameObject _obj)
    {
        print("Clicked button:" + _obj.name);
    }*/

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        highscore = Score_save._instance.GetHighScore();
        /*  GUILayout.BeginHorizontal();
          GUILayout.Label("Name :");
          name = GUILayout.TextField(name);
          GUILayout.EndHorizontal();

          GUILayout.BeginHorizontal();
          GUILayout.Label("Score :");
          score = GUILayout.TextField(score);
          GUILayout.EndHorizontal();*/

        /*if (GUILayout.Button("Add Score"))
        {
            Score_manager._instance.SaveHighScore(name, System.Int32.Parse(score));
            highscore = Score_manager._instance.GetHighScore();
        }*/

        /* if (GUILayout.Button("Get LeaderBoard"))
         {
             highscore = Score_manager._instance.GetHighScore();
         }

         if (GUILayout.Button("Clear Leaderboard"))
         {
             Score_manager._instance.ClearLeaderBoard();
         }*/

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", GUILayout.Width(Screen.width / 2));
        GUILayout.Label("Scores", GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        foreach (Scores _score in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, GUILayout.Width(Screen.width / 2));
            GUILayout.Label("" + _score.score, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }
    }

   public  void getleaderboard()
    {
        sound.ButtonSound();
        highscore = Score_save._instance.GetHighScore();
        //scoresave.GetHighScore();
    }

    public void clearleaderboard()
    {
        sound.ButtonSound();
        Score_save._instance.ClearLeaderBoard();
        highscore = Score_save._instance.GetHighScore();
        /*scoresave.ClearLeaderBoard();
        scoresave.GetHighScore();*/
    }

    public void backtomain()
    {
        sound.ButtonSound();
        Application.LoadLevel("main menu");
    }

    public void SoundONOFF()
    {
        sound.ButtonSound();
        sound.SoundToggle();
    }



}
