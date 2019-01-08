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



    // Use this for initialization
    void Start () {
        sound.MenuMusic();

    }



    // Update is called once per frame
    void Update () {
      
	}

    public void Playgame() // betöltjük a következő scean-t
    {

        sound.ButtonSound();
        Application.LoadLevel(playgamelevel);

      
      //  sound.MainTheme();

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
        Application.Quit(); // kilép a játékból
    }
}
