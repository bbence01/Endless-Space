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


    /*private AudioSource themeMusic;
    private AudioSource menuMusic;
    private AudioSource pauseMusic;
    private AudioSource deathMusic;
    private AudioSource lbMusic;
    private AudioSource coinsound;
    private AudioSource jumpsound;
    private AudioSource powerupsound;
    private AudioSource deathsound;
    private AudioSource buttonsound;
    private AudioSource shootsound;
    */
    //private AudioSource musictoplay;


    private int music;

    public string whatmuisic;

   


    //  private Audio_sounds sounds;




     void Awake()
    {

        music = PlayerPrefs.GetInt("music");

    }



    // Use this for initialization
    void Start () {



        

        if ( !(PlayerPrefs.HasKey("music")) ) // ha nincs
        {
            music = 1;
            PlayerPrefs.SetInt( "music", music);
        }
        else if( (PlayerPrefs.HasKey("music")) ) // ha van
        {
           music = PlayerPrefs.GetInt("music");
        }

        // music = PlayerPrefs.GetInt("music");

       
    }

    /* void Awake()
     {
         //Check if there is already an instance of SoundManager
         if (instance == null)
             //if not, set it to this.
             instance = this;
         //If instance already exists:
         else if (instance != this)
             //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
             Destroy(gameObject);

         //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
         DontDestroyOnLoad(gameObject);
     }
     */
    // Update is called once per frame
    void Update () {
		
	}

    /*
    public static Audio_sounds instance = null; // más scenek is használhatják 
    private static Audio_sounds a_instance;

    public static Audio_sounds _instance
    {
        get
        {
            if (a_instance == null)
            {
                a_instance = new GameObject("Audio_sounds").AddComponent<Audio_sounds>();
            }
            else if (a_instance == true)
            {
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy(a_instance);
            }
            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(a_instance);



            return a_instance;
        }
    }
    */





    public void MainTheme()
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

        whatmuisic = "themeMusic";
       

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
       

       
        whatmuisic = "menuMusic";
        


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

        whatmuisic = "pauseMusic";
       

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

        whatmuisic = "deathMusic";
       

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
        whatmuisic = "lbMusic";
      
    }

    public void stopmusic()
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
        if (coinsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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

        if (jumpsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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

        if (powerupsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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

        if (buttonsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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

        if (shootsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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
        if (hitsound.isPlaying) // bugfiyx ha egyszerre sok érmét szedünk fel
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

                stopmusic();
                PlayerPrefs.SetInt("music", music);

            }

            else if (music == 0)
            {
                music = 1;
                PlayerPrefs.SetInt("music", music);

                switch (whatmuisic)
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
