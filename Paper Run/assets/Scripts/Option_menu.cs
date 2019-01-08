using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option_menu : MonoBehaviour {

    private Audio_manager sound;
    // public Platform_gen platforms;

    public float randomcointhreshold ;
    public float randomspikethreshold ;
    public float powerupthreshold ;
    public float enemythreshold ;

   // public float platforms;


    public Slider coinslider;
    public Slider spikeslider;
    public Slider powerupslider;
    public Slider enemyslider;

    public Slider audioslider;

    public Option_values values;

    public float volume;


   /* public static Option_menu instance = null; // más scenek is használhatják 
    private static Option_menu p_instance;

    public static Option_menu _instance
    {
        get
        {
            if (p_instance == null)
            {
                p_instance = new GameObject("Option_menu").AddComponent<Option_menu>();
            }
            else if (p_instance == true)
            {
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy(p_instance);
            }
            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(p_instance);



            return p_instance;
        }
    }
    */

   /* private static Option_menu o_instance;
   


    public static Option_menu _instance
    {
        get
        {
            if (o_instance == null)
            {
                o_instance = new GameObject("Option_menu").AddComponent<Option_menu>();
            }
            return o_instance;
        }
    }
    */

    void Awake()
    {
        sound = FindObjectOfType<Audio_manager>();

        //    platforms = FindObjectOfType<Platform_gen>();


        /*     if (o_instance == null)
             {
                 o_instance = this;
             }
             else if (o_instance != this)
                 Destroy(gameObject);

             DontDestroyOnLoad(gameObject);

     */

       /* coinslider.value = cointhreshold;
        spikeslider.value = spikethreshold;
        powerupslider.value = powerupthreshold;
        enemyslider.value = enemythreshold;
        */
    }


    // Use this for initialization
    void Start () {


        values = FindObjectOfType<Option_values>();

        randomcointhreshold = values.cointhreshold;
        randomspikethreshold = values.spikethreshold;
        powerupthreshold = values.powerupthreshold;
        enemythreshold = values.enemythreshold;

        coinslider.value = randomcointhreshold;
        spikeslider.value = randomspikethreshold;
        powerupslider.value = powerupthreshold;
        enemyslider.value = enemythreshold;
       // volume = AudioListener.volume;
        audioslider.value = AudioListener.volume;

        

        sound.MenuMusic();


    }

    // Update is called once per frame
    void Update () {
		
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

    public void MusicONOFF()
    {
        sound.MusicToggle();

    }

    public void Coinslider()
    {
     randomcointhreshold = coinslider.value;

     values.cointhreshold = coinslider.value;

        PlayerPrefs.SetFloat("cointhreshold", randomcointhreshold);

    }

    public void Spikeslider()
    {
       randomspikethreshold = spikeslider.value;
        values.spikethreshold = spikeslider.value;
        PlayerPrefs.SetFloat("spikethreshold", randomspikethreshold);
    }

    public void Powerupslider()
    {
  
        powerupthreshold = powerupslider.value;
        values.powerupthreshold = powerupslider.value;
        PlayerPrefs.SetFloat("powerupthreshold", powerupthreshold);
    }

    public void Enemyslider()
    {
         enemythreshold = enemyslider.value;
        values.enemythreshold = enemyslider.value;
        PlayerPrefs.SetFloat("enemythreshold", enemythreshold);
        // Platform_gen._instance.enemythreshold = enemyslider.value;


    }

    public void Volume()

    {
        AudioListener.volume = audioslider.value;
        values.volume = audioslider.value;
        
        PlayerPrefs.SetFloat("volume", audioslider.value);
    }

}
