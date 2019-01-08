using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_manager : MonoBehaviour {

    private bool doubleppoints;
    private bool safemode;

    private bool powerupactive;

    private float poweruplengthcounter;

    private Score_manager thescoremanager;
    private Platform_gen theplatformgen;
    private Game_manager thegamemanager;

    private float normalpointsps;    
    private float spikerate;
    private float enemyrate;


    private Plat_destroy[] dangerlist;
    private Option_values values;

    public Text poweruptext;


    void Start () {

        thescoremanager = FindObjectOfType<Score_manager>();
        theplatformgen = FindObjectOfType<Platform_gen>();
        thegamemanager = FindObjectOfType<Game_manager>();
        values = FindObjectOfType<Option_values>();
     

    }



    void Update () {

        if (doubleppoints)
        {
            poweruptext.text = "Double Points";
        }
        else if (safemode)
        {
            poweruptext.text = "Safe Mode";
        }
        else
        {
            poweruptext.text = "";
        }


        if (powerupactive)       
        {

            poweruplengthcounter -= Time.deltaTime;




            if (thegamemanager.powerupreset || poweruplengthcounter <= 0)     
            {

                poweruplengthcounter = 0;
                
                doubleppoints = false;
                safemode = false;
                powerupactive = false;

                theplatformgen.spikethreshold = values.spikethreshold;
                theplatformgen.enemythreshold = values.enemythreshold;


                thescoremanager.shoulddouble = false;
                thegamemanager.powerupreset = false;
            }


            if (doubleppoints)     
                {

                    thescoremanager.shoulddouble = true;     

                }
            else if(!doubleppoints)
            {
                thescoremanager.shoulddouble = false;
            }


            if (safemode)
            {

                theplatformgen.spikethreshold = 0f;
                theplatformgen.enemythreshold = 0f;
             }
            else if(!safemode)
            {
                theplatformgen.spikethreshold = values.spikethreshold;
                theplatformgen.enemythreshold = values.enemythreshold;
            }
          


        }

        
        
      



    }


    public void Activatepowerup(bool points, bool safe, float time)
    {

        doubleppoints = points;
        safemode = safe;
        poweruplengthcounter = time;
        

 


        if (safemode)
        {

            dangerlist = FindObjectsOfType<Plat_destroy>();         

            for (int i = 0; i < dangerlist.Length; i++)
            {
                if (dangerlist[i].gameObject.name.Contains("spikes") || dangerlist[i].gameObject.name.Contains("red"))        
                {
                    dangerlist[i].gameObject.SetActive(false);       
                }
            }

        }


        powerupactive = true;

    }


}
