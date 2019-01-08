using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour {


    public Transform platgen;    
    private Vector3 platformstartpoint;

    public Player_movement theplayer;    
    private Vector3 playerstartpoint;


    private Plat_destroy[] platformlist;

    private Score_manager thescoremanager;

    public Death_menu theDeathscreen;
    public GameObject thePausebutton;

    public bool powerupreset;

    private Audio_manager sound;

    private Scrolling_Background scroll;

    private Option_values values;

    private Platform_gen platformgen;

    void Start () {

        platformstartpoint = platgen.position;    
        platformstartpoint = theplayer.transform.position;
        
        thescoremanager = FindObjectOfType<Score_manager>();
        
        sound = FindObjectOfType<Audio_manager>();

        scroll = FindObjectOfType<Scrolling_Background>();

        values = FindObjectOfType<Option_values>();

        platformgen = FindObjectOfType<Platform_gen>();

    }
	
	void Update () {
		
	}


    public void EndGame()    
    {

        thescoremanager.scoreincreaseing = false;
        theplayer.gameObject.SetActive(false);    

        thePausebutton.SetActive(false);
        theDeathscreen.gameObject.SetActive(true);
        scroll.parallax = false;
        sound.DeathMusic();        

    }

    public void ReStartGame()
    {

        theDeathscreen.gameObject.SetActive(false);
        thePausebutton.SetActive(true);


        platformlist = FindObjectsOfType<Plat_destroy>();         

        for (int i = 0; i < platformlist.Length; i++)
        {

            platformlist[i].gameObject.SetActive(false);       

        }

        
       platformgen.spikethreshold = values.spikethreshold;
        
        platformgen.enemythreshold = values.enemythreshold;


        theplayer.transform.position = platformstartpoint;  
        platgen.position = platformstartpoint;

        theplayer.gameObject.SetActive(true);    

        thescoremanager.scorecount = 0;
        thescoremanager.scoreincreaseing = true;

        powerupreset = true;
        scroll.parallax = true;
        sound.MainMusic();
    }

}
