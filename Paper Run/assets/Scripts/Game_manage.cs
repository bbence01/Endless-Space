using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manage : MonoBehaviour {

    public Transform Platform_gen;   
    private Vector3 platstartpoint;

    public Player_movement player;
    private Vector3 playerstartpoint;

    private Plat_destroy[] platfromlist;

    

  
   
    

	// Use this for initialization
	void Start () {

        platstartpoint = Platform_gen.position;  // elmentjük a player és a hozzá tartózó pontok kezdő helyét
        playerstartpoint = player.transform.position;
       


    }
	
	// Update is called once per frame
	void Update () {


    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo"); // magátol fut, 
    }


    public IEnumerator RestartGameCo() // viisza állítjuk a játékot a kezdő pozícióba
    {

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f); //üresjáratot addok hozzá


        platfromlist = FindObjectsOfType<Plat_destroy>(); 

        for ( int i =0; i< platfromlist.Length;i++)      // a már legenerált platformokt inactivá tesszük
        {
            platfromlist[i].gameObject.SetActive(false);
       }
        player.transform.position = playerstartpoint; // vissza rakjuk a player karaktert a kezdő pontra
       

        Platform_gen.position = playerstartpoint;

       



        player.gameObject.SetActive(true); // újra indul a játék

        

    }


}
