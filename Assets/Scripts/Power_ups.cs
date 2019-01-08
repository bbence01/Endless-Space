using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_ups : MonoBehaviour {

    public bool doubleppoints;   
    public bool safemode;

    public float poweruplength;

    private Powerup_manager thepowerupmanager;
    private Audio_manager sound;

    public Sprite[] powerupsprites;

   
    

    void Start () {

        thepowerupmanager = FindObjectOfType<Powerup_manager>();
        sound = FindObjectOfType<Audio_manager>();

    }

     void Awake(){

        int powerupselector = Random.Range(0, 2);     

        switch(powerupselector)      
        {

            case 0: doubleppoints = true;
                break;

            case 1: safemode = true;
                break;
             
        }

        GetComponent<SpriteRenderer>().sprite = powerupsprites[powerupselector];

    }


    void Update () {
		
	}

   private void OnTriggerEnter2D(Collider2D other)        
    {
        
        if( other.name =="Mupi")
        {
            thepowerupmanager.Activatepowerup(doubleppoints, safemode, poweruplength);

            sound.PowerupSound();

            gameObject.SetActive(false);

        }
        else if (other.tag == "Projectile")
        {
            Destroy(other);
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other);
        }


    }



}
