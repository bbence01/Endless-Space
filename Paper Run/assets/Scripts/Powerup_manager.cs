using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_manager : MonoBehaviour {

    private bool doubleppoints;
    private bool safemode;

    private bool powerupactive;

    private float poweruplengthcounter;

    private Score_manager thescoremanager;
    private Platform_gen theplatformgen;
    private Game_manager thegamemanager;

    private float normalpointsps; //elmentjük a normál értékeket
    private float spikerate;
    private float enemyrate;


   // private Plat_destroy[] spikelist;
    private Plat_destroy[] dangerlist;




    // Use this for initialization
    void Start () {

        thescoremanager = FindObjectOfType<Score_manager>();
        theplatformgen = FindObjectOfType<Platform_gen>();
        thegamemanager = FindObjectOfType<Game_manager>();


	}



    // Update is called once per frame
    void Update () {


        if (powerupactive) // ha felvettünk valamit kezdjen el számlálni
        {

            poweruplengthcounter -= Time.deltaTime;

            if (thegamemanager.powerupreset || poweruplengthcounter <= 0) //halál után kikapcsolja a powerup-ot
            {

                poweruplengthcounter = 0;
              // thescoremanager.pointPS = normalpointsps; // visszaállítjuk az eredeti értékekre
                thescoremanager.shoulddouble = false;
                doubleppoints = false;
                safemode = false;


                theplatformgen.spikethreshold = spikerate;
                theplatformgen.enemythreshold = enemyrate;



                thegamemanager.powerupreset = false;
            }
            /*
            if (poweruplengthcounter <= 0) // ha 0 ra éert a számlálo legyen vége 
            {

                thescoremanager.pointPS = normalpointsps; // visszaállítjuk az eredeti értékekre
                thescoremanager.shoulddouble = false;
                safemode = false;

                theplatformgen.spikethreshold = spikerate;
                theplatformgen.enemythreshold = enemyrate;


                powerupactive = false;

            }
            */


            if (doubleppoints) // melyik power up activw
                {

                  //  thescoremanager.pointPS = normalpointsps * 2f; // dupla pontok
                    thescoremanager.shoulddouble = true; // duplázza a érme értéket

                }


            if (safemode)
            {

                theplatformgen.spikethreshold = 0f;
                theplatformgen.enemythreshold = 0f;




            }


      





        }

		
	}


    public void Activatepowerup(bool points, bool safe, float time)
    {

        doubleppoints = points;
        safemode = safe;
        poweruplengthcounter = time;

        normalpointsps = thescoremanager.pointPS;
        spikerate = theplatformgen.spikethreshold;
        enemyrate = theplatformgen.enemythreshold;


        if (safemode)
        {

            dangerlist = FindObjectsOfType<Plat_destroy>(); // megkeresi az összes platformot és belerakja a listába

            for (int i = 0; i < dangerlist.Length; i++)
            {
                if (dangerlist[i].gameObject.name.Contains("spikes") || dangerlist[i].gameObject.name.Contains("red")) //csak akkor törli ha benne van a nevében
                {
                    dangerlist[i].gameObject.SetActive(false); //végig megy a listánn és mided inactiválja
                }
            }

           /* dangerlist = FindObjectsOfType<Plat_destroy>(); // megkeresi az összes platformot és belerakja a listába

            for (int i = 0; i < dangerlist.Length; i++)
            {
                if (dangerlist[i].gameObject.name.Contains("enemy")) //csak akkor törli ha benne van a nevében
                {
                    dangerlist[i].gameObject.SetActive(false); //végig megy a listánn és mided inactiválja
                }
            }*/
        }


        powerupactive = true;

    }


}
