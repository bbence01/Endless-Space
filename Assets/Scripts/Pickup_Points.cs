using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Points : MonoBehaviour {

    public int scoretogive;      

    private Score_manager thescoremanager;

    private Audio_manager sound;

    void Start () {

        thescoremanager = FindObjectOfType<Score_manager>();

        sound = FindObjectOfType<Audio_manager>();

    }
	
	void Update () {
		


	}

    private void OnTriggerEnter2D(Collider2D other)        
    {
      
        if ( other.gameObject.name =="Mupi")
        {
            thescoremanager.Addscore(scoretogive);       
            gameObject.SetActive(false);

            sound.CoinSound();

        }
    }

}
