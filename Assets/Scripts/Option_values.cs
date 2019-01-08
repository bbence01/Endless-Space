using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_values : MonoBehaviour {


    public float cointhreshold = 25;
    public float spikethreshold = 25;
    public float powerupthreshold = 25;
    public float enemythreshold = 25;
    public float volume;

    public bool parallax = true ;
    public float check = 1;

    private static Option_values v_instance;



    public static Option_values _instance
    {
        get
        {
            if (v_instance == null)
            {
                v_instance = new GameObject("Option_values").AddComponent<Option_values>();
            }
            return v_instance;
        }
    }

    void Awake()
    { 





     

        if (v_instance == null)
        {
           // v_instance = new GameObject("Option_values").AddComponent<Option_values>();
           v_instance = this;
        }
        else if (v_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

      
    }


	// Use this for initialization
	void Start () {

               if ( (PlayerPrefs.HasKey("cointhreshold")) )
        {
            cointhreshold = PlayerPrefs.GetFloat("cointhreshold", cointhreshold);
            spikethreshold = PlayerPrefs.GetFloat("spikethreshold", spikethreshold);
            powerupthreshold = PlayerPrefs.GetFloat("powerupthreshold", powerupthreshold);
            enemythreshold = PlayerPrefs.GetFloat("enemythreshold" );

            check = PlayerPrefs.GetFloat("parallax");
            if( check ==1 )
            {
                parallax = true;
            }
            else if( check == 0)
            {
                parallax = false;
            }

            volume = PlayerPrefs.GetFloat("volume");
            AudioListener.volume = volume;

        }

        /* cointhreshold = Option_menu._instance.cointhreshold;
         spikethreshold = Option_menu._instance.spikethreshold;
         powerupthreshold = Option_menu._instance.powerupthreshold;
         enemythreshold = Option_menu._instance.enemythreshold;*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
