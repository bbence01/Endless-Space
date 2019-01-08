using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_menu : MonoBehaviour {


    public string playgamelevel;
    public string scoretable;
    public string options;



    private Audio_manager sound;
   

    void Awake()
    {
        sound = FindObjectOfType<Audio_manager>();
    }



    void Start () {
        sound.MenuMusic();

    }



    void Update () {
      
	}

    public void Playgame()     
    {

        sound.ButtonSound();
        Application.LoadLevel(playgamelevel);

      
    }

 

    public void LeaderboardButton()
    {
        sound.ButtonSound();
      
        Application.LoadLevel(scoretable);

    }

    public void OptionsButton()
    {
        sound.ButtonSound();

        Application.LoadLevel(options);

    }



    public void SoundONOFF()
    {
        sound.SoundToggle();
    }

    public void MusicONOFF()
    {
        sound.MusicToggle();

    }

    public void Quitgame()
    {
        
        sound.ButtonSound();
        Application.Quit();    
    }
}
