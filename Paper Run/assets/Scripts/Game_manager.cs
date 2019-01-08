using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour {


    public Transform platgen; //hozzárendeljük a platform generátorunkat
    private Vector3 platformstartpoint;

    public Player_movement theplayer; //hozzárendeljük  a karaktert
    private Vector3 playerstartpoint;


    private Plat_destroy[] platformlist;

    private Score_manager thescoremanager;

    public Death_menu theDeathscreen;
    public GameObject thePausebutton;

    public bool powerupreset;

    private Audio_manager sound;

    private Scrolling_Background scroll;

	// Use this for initialization
	void Start () {

        platformstartpoint = platgen.position;  //beállítjuk a kezdőértékeket
        platformstartpoint = theplayer.transform.position;
        
        thescoremanager = FindObjectOfType<Score_manager>();
        
        sound = FindObjectOfType<Audio_manager>();

        scroll = FindObjectOfType<Scrolling_Background>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Restartgame() //másahonnan is meghívható metódus
    {

        //     StartCoroutine("RestartgameCo"); //meghívás

        thescoremanager.scoreincreaseing = false;
        theplayer.gameObject.SetActive(false); // inactiv, nem látjuk

        thePausebutton.SetActive(false);
        theDeathscreen.gameObject.SetActive(true);
        scroll.paralax = false;
        sound.DeathMusic();        

    }

    public void Resetgame()
    {

        theDeathscreen.gameObject.SetActive(false);
        thePausebutton.SetActive(true);


        platformlist = FindObjectsOfType<Plat_destroy>(); // megkeresi az összes platformot és belerakja a listába

        for (int i = 0; i < platformlist.Length; i++)
        {

            platformlist[i].gameObject.SetActive(false); //végig megy a listánn és mided inactiválja

        }

        theplayer.transform.position = platformstartpoint; // visszaállítás
        platgen.position = platformstartpoint;

        theplayer.gameObject.SetActive(true); // inactiv, nem látjuk

        thescoremanager.scorecount = 0;
        thescoremanager.scoreincreaseing = true;

        powerupreset = true;
        scroll.paralax = true;
        sound.MainTheme();
    }

   /* public IEnumerator RestartgameCo()  //magától futtu metódus(corutin), for time delay reasons when the player dies 
    {

        thescoremanager.scoreincreaseing = false;

        theplayer.gameObject.SetActive(false); // inactiv, nem látjuk

        yield return new WaitForSeconds(0.5f); //várakozás

        platformlist = FindObjectsOfType<Plat_destroy>(); // megkeresi az összes platformot és belerakja a listába

        for( int i=0; i < platformlist.Length; i++)
        {

            platformlist[i].gameObject.SetActive(false); //végig megy a listánn és mided inactiválja

        }

        theplayer.transform.position = platformstartpoint; // visszaállítás
        platgen.position = platformstartpoint;

        theplayer.gameObject.SetActive(true); // inactiv, nem látjuk

        thescoremanager.score = 0;
        thescoremanager.scoreincreaseing = true;

    }*/

}
