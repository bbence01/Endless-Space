using System.Collections.Generic;
using UnityEngine;

public class Score_Leaderboard : MonoBehaviour {

     


     string name = "";
     string score = "";

    private Score_save scoresave;
    private Audio_manager sound;




    List<Scores> highscore;

    void Start()
    {
        highscore = new List<Scores>();
        scoresave = FindObjectOfType<Score_save>();
        sound = FindObjectOfType<Audio_manager>();

    
        sound.LBMusic();
    
    }




    void Update()
    {

    }

    void OnGUI()
    {
        highscore = Score_save._instance.GetHighScore();
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
    }

    public void clearleaderboard()
    {
        sound.ButtonSound();
        Score_save._instance.ClearLeaderBoard();
        highscore = Score_save._instance.GetHighScore();
    }

    public void QuitToMain()
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
