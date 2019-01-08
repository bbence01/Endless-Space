using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option_menu : MonoBehaviour {

    private Audio_manager sound;
    public float randomcointhreshold ;
    public float randomspikethreshold ;
    public float powerupthreshold;
    public float enemythreshold ;


    public Slider coinslider;
    public Slider spikeslider;
    public Slider powerupslider;
    public Slider enemyslider;

    public Slider audioslider;

    public float check;
    public Toggle parallax;

    public Option_values values;

    public float volume;


    void Awake()
    {
        sound = FindObjectOfType<Audio_manager>();


    }


    void Start () {


        values = FindObjectOfType<Option_values>();

        randomcointhreshold = values.cointhreshold;
        randomspikethreshold = values.spikethreshold;
        powerupthreshold = values.powerupthreshold;
        enemythreshold = values.enemythreshold;
        check = values.check;

        coinslider.value = randomcointhreshold;
        spikeslider.value = randomspikethreshold;
        powerupslider.value = powerupthreshold;
        enemyslider.value = enemythreshold;
        audioslider.value = AudioListener.volume;
        parallax.isOn = values.parallax;
        

        sound.MenuMusic();


    }

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

    }

    public void Volume()

    {
        AudioListener.volume = audioslider.value;
        values.volume = audioslider.value;
        
        PlayerPrefs.SetFloat("volume", audioslider.value);
    }

    public void Parallax()
    {
        if (parallax.isOn == true)
        {
            check = 1;
            values.check = 1;
            values.parallax = true;
        }
        else if (parallax.isOn == false)
        {
            check = 0;
            values.check = 0;
            values.parallax = false;
        }
        PlayerPrefs.SetFloat("parallax", check);
    }

}
