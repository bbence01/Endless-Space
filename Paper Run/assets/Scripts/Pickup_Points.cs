using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Points : MonoBehaviour {

    public int scoretogive; // mennyi pontot adjon az érme

    private Score_manager thescoremanager;

    private Audio_manager sound;

    // Use this for initialization
    void Start () {

        thescoremanager = FindObjectOfType<Score_manager>();

        sound = FindObjectOfType<Audio_manager>();

    }
	
	// Update is called once per frame
	void Update () {
		


	}

    private void OnTriggerEnter2D(Collider2D other) // beépített unity fügvény, ha valami belesétál 
    {
      
        if ( other.gameObject.name =="Mupi")
        {
            thescoremanager.Addscore(scoretogive); // hozzáadja a jalanlagihez az érme értékét
            gameObject.SetActive(false);

            sound.CoinSound();

        }
    }

}
