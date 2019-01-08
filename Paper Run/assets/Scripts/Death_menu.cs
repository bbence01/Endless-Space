using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death_menu : MonoBehaviour {

    public string mainmenulevel;

    


    private Score_save scoresave;
    private Score_manager score;


  
    public Text playername;
    public Button savebutton;

    private Audio_manager sound;

    // Use this for initialization
    void Start() {
        sound = FindObjectOfType<Audio_manager>();
        scoresave = FindObjectOfType<Score_save>();
        score = FindObjectOfType<Score_manager>();
      

        //sound.whatmuisic = "deathMusic";
      


    }

    // Update is called once per frame
    void Update() {

    }

    public void SaveScore()
    {
        sound.ButtonSound();
        if (playername != "" && playername != null)


        {
            Score_save._instance.SaveHighScore(playername.text, score.scorecount);
            // scoresave.SaveHighScore(playername.text, scoresave.scorecount);
            playername = "";
            score.scorecount = 0;
            playername.gameObject.SetActive(false);
            savebutton.gameObject.SetActive(false);
           
        }
    }

    public void Restartgame()
    {
        savebutton.gameObject.SetActive(true);
        playername.gameObject.SetActive(true);
        sound.ButtonSound();
        sound.MainTheme();
        FindObjectOfType<Game_manager>().Resetgame();
        
    }

    public void Quittomain()
    {

        savebutton.gameObject.SetActive(true);
        playername.gameObject.SetActive(true);

        sound.ButtonSound();
       
        sound.MenuMusic();
        Application.LoadLevel(mainmenulevel);
        
    }

    


}
