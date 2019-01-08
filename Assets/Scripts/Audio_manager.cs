using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_manager : MonoBehaviour {



    




    public AudioSource themeMusic;
    public AudioSource menuMusic;
    public AudioSource pauseMusic;
    public AudioSource deathMusic;
    public AudioSource lbMusic;

    public AudioSource coinsound;
    public AudioSource jumpsound;
    public AudioSource powerupsound;
    public AudioSource deathsound;
    public AudioSource shootsound;
    public AudioSource hitsound;

    public AudioSource buttonsound;



    private int music;

    public string whatMusic;

   





     void Awake()
    {

        music = PlayerPrefs.GetInt("music");

    }



    void Start () {



        

        if ( !(PlayerPrefs.HasKey("music")) )   
        {
            music = 1;
            PlayerPrefs.SetInt( "music", music);
        }
        else if( (PlayerPrefs.HasKey("music")) )   
        {
           music = PlayerPrefs.GetInt("music");
        }

       
    }

    void Update () {
		
	}





    public void MainMusic()
    {

        menuMusic.Stop();
        pauseMusic.Stop();
        themeMusic.Stop();
        deathMusic.Stop();
        lbMusic.Stop();

        if (music == 1)
        {
            themeMusic.Play();
        }

        whatMusic = "themeMusic";
       

    }


    public void MenuMusic()
    {

         menuMusic.Stop();
         pauseMusic.Stop();
         themeMusic.Stop();
         deathMusic.Stop();
         lbMusic.Stop();

        if (music == 1)
        {
            menuMusic.Play();
        }
       

       
        whatMusic = "menuMusic";
        


    }




    public void PauseMusic()
         
    {

        menuMusic.Stop();
        pauseMusic.Stop();
        themeMusic.Stop();
        deathMusic.Stop();
        lbMusic.Stop();

        if (music == 1)
        {
            pauseMusic.Play();
        }

        whatMusic = "pauseMusic";
       

    }


    public void DeathMusic()
    {
        menuMusic.Stop();
        pauseMusic.Stop();
        themeMusic.Stop();
        deathMusic.Stop();
        lbMusic.Stop();

        if (music == 1)
        {
            deathMusic.Play();
        }

        whatMusic = "deathMusic";
       

    }

    public void LBMusic()
    {
        menuMusic.Stop();
        pauseMusic.Stop();
        themeMusic.Stop();
        deathMusic.Stop();
        lbMusic.Stop();

        if (music == 1)
        {
            lbMusic.Play();
        }
        whatMusic = "lbMusic";
      
    }

    public void Stopmusic()
    {
        menuMusic.Stop();
        pauseMusic.Stop();
        themeMusic.Stop();
        deathMusic.Stop();
        lbMusic.Stop();

        music = 0;
        PlayerPrefs.SetInt("music", music);
    }




    public void CoinSound()
    {
        if (coinsound.isPlaying)        
        {
            coinsound.Stop();
            coinsound.Play();
        }
        else
        {
            coinsound.Play();


        }

    }

    public void JumpSound()
    {

        if (jumpsound.isPlaying)        
        {
            jumpsound.Stop();
            jumpsound.Play();
        }
        else
        {
            jumpsound.Play();


        }
    }

    public void DeathSound()
    {
        deathsound.Play();
    }


    public void PowerupSound()
    {

        if (powerupsound.isPlaying)        
        {
            powerupsound.Stop();
            powerupsound.Play();
        }
        else
        {
            powerupsound.Play();


        }

    }

    public void ButtonSound()
    {

        if (buttonsound.isPlaying)        
        {
            buttonsound.Stop();
            buttonsound.Play();
        }
        else
        {
            buttonsound.Play();


        }

    }

    public void ShootSound()
    {

        if (shootsound.isPlaying)        
        {
            shootsound.Stop();
            shootsound.Play();
        }
        else
        {
            shootsound.Play();


        }

    }

    public void HitSound()
    {
        if (hitsound.isPlaying)        
        {
            hitsound.Stop();
            hitsound.Play();
        }
        else
        {
            hitsound.Play();


        }

    }



    public void SoundToggle()
    {
        if (AudioListener.pause == false)
        {

            AudioListener.pause = true;


        }
        else
        {

            AudioListener.pause = false;


        }
    }


    public void MusicToggle()

    {
        if (AudioListener.pause == false)
        {
            if (music == 1)
            {

                Stopmusic();
                PlayerPrefs.SetInt("music", music);

            }

            else if (music == 0)
            {
                music = 1;
                PlayerPrefs.SetInt("music", music);

                switch (whatMusic)
                {
                    case "themeMusic":
                        themeMusic.Play();

                        break;

                    case "menuMusic":
                        menuMusic.Play();

                        break;

                    case "pauseMusic":
                        pauseMusic.Play();

                        break;

                    case "deathMusic":
                        deathMusic.Play();

                        break;

                    case "lbMusic":
                        lbMusic.Play();

                        break;

                    default:
                        break;

                }
            }


        }

    }







}
