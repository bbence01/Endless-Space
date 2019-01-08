using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_ups : MonoBehaviour {

    public bool doubleppoints; // milyen powerup
    public bool safemode;

    public float poweruplength;

    private Powerup_manager thepowerupmanager;
    private Audio_manager sound;

    public Sprite[] powerupsprites;

   
    

    // Use this for initialization
    void Start () {

        thepowerupmanager = FindObjectOfType<Powerup_manager>();
        sound = FindObjectOfType<Audio_manager>();

    }

     void Awake(){

        int powerupselector = Random.Range(0, 2); // véletlenszerően melyik powerup legyen

        switch(powerupselector) // csak az egyik lesz aktív
        {

            case 0: doubleppoints = true;
                break;

            case 1: safemode = true;
                break;
             
        }

        GetComponent<SpriteRenderer>().sprite = powerupsprites[powerupselector];

    }


    // Update is called once per frame
    void Update () {
		
	}

   private void OnTriggerEnter2D(Collider2D other) // amikor a játékos belelép a powerup -ba
    {
        
        if( other.name =="Mupi")
        {
            thepowerupmanager.Activatepowerup(doubleppoints, safemode, poweruplength);

            sound.PowerupSound();

            gameObject.SetActive(false);

        }
        else if (other.tag == "Projectile")
        {
            // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
            Destroy(other);
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
        }


    }



}
