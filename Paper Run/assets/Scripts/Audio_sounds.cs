using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_sounds : MonoBehaviour {

    /* private Audio_manager sounds;

     public AudioSource themeMusic;
     public AudioSource menuMusic;
     public AudioSource pauseMusic;
     public AudioSource deathMusic;
     public AudioSource lbMusic;
     public AudioSource coinsound;
     public AudioSource jumpsound;
     public AudioSource powerupsound;
     public AudioSource deathsound;
     public AudioSource buttonsound;
     public AudioSource shootsound;

    
     public string whatmuisic;



     // Use this for initialization
     


         sounds = FindObjectOfType<Audio_manager>();

         themeMusic = sounds.themeMusic;
         menuMusic = sounds.menuMusic;
         pauseMusic = sounds.pauseMusic;
         deathMusic = sounds.deathMusic;
         lbMusic = sounds.lbMusic;
         coinsound = sounds.coinsound;
         jumpsound = sounds.jumpsound;
         powerupsound = sounds.powerupsound;
         deathsound = sounds.deathsound;
         buttonsound = sounds.buttonsound;
         shootsound = sounds.shootsound;


     // Update is called once per frame


     */

    public static Audio_sounds instance = null; // más scenek is használhatják 
    private static Audio_sounds a_instance;

    public int music;

    void Start()
    {


    }



        void Update()
    {

    }

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



    
}
