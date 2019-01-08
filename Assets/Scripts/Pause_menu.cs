using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour
{

    public string mainmenulevel;

    public GameObject pausemenu;

    private Audio_manager sound;
   


    // Use this for initialization
    void Start()
    {
        sound = FindObjectOfType<Audio_manager>();
        

        //sound.whatMusic = "pauseMusic";
       // sound.music = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pausegame()
    {

        sound.ButtonSound();
        sound.PauseMusic();

        Time.timeScale = 0f; // unity saját idő mérője 0-megál, 1 normál
        pausemenu.SetActive(true);
    }

    public void Resumegame()
    {
        sound.ButtonSound();
        
        Time.timeScale = 1f; // unity saját idő mérője 0-megál, 1 normál
        pausemenu.SetActive(false);
        
        sound.MainMusic();
    }

   

    public void RestartGameFromPause()
    {
        sound.ButtonSound();
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        FindObjectOfType<Game_manager>().ReStartGame();
        
        sound.MainMusic();

    }

    public void Quittomainfrompause()
    {
        sound.ButtonSound();
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        sound.pauseMusic.Stop();
        sound.MenuMusic();
        Application.LoadLevel(mainmenulevel);

    }




}
