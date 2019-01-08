using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_mamager : MonoBehaviour {

    private Player_movement player;
    private Enemy_manager enemy;
    private Score_manager thescoremanager ;







    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Player_movement>();
        enemy = FindObjectOfType<Enemy_manager>();
        thescoremanager = FindObjectOfType<Score_manager>();

    }

    // Update is called once per frame
    void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other) //when a projectile collides with another object
    {
        if (other.gameObject.tag == "enemy"  )
        {
            if (gameObject.tag != "enemybullet")
            {
                enemy.GetEnemyHit();
                thescoremanager.Addscore(100);
                other.gameObject.SetActive(false);
            }

            Destroy(gameObject);
        }
         else if ( other.gameObject.tag == "Player") //if anoter object is 'player' or 'enemy sending the command of receiving the damage
        {
            player.GetPlayerHit();
          
                Destroy(gameObject);
        }
        else if(other.gameObject.tag == "ground")
        {

            Destroy(gameObject);
        }
        else 
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other );
            
        }
        
    


    }






}



