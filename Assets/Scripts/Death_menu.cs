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

    void Start() {
        sound = FindObjectOfType<Audio_manager>();
        scoresave = FindObjectOfType<Score_save>();
        score = FindObjectOfType<Score_manager>();
      



    }

    void Update() {

    }

    public void SaveScore()
    {
        sound.ButtonSound();
        if (playername.text != "" && playername != null)


        {
            Score_save._instance.SaveHighScore(playername.text, score.scorecount);
            playername.text = "";
            score.scorecount = 0;
            playername.gameObject.SetActive(false);
            savebutton.gameObject.SetActive(false);
           
        }
    }

    public void RestartgameFromDeath()
    {
        savebutton.gameObject.SetActive(true);
        playername.gameObject.SetActive(true);
        sound.ButtonSound();
        sound.MainMusic();
        FindObjectOfType<Game_manager>().ReStartGame();
        
    }

    public void QuitToMain()
    {

        savebutton.gameObject.SetActive(true);
        playername.gameObject.SetActive(true);

        sound.ButtonSound();
       
        sound.MenuMusic();
        Application.LoadLevel(mainmenulevel);
        
    }

    


}
