using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_mamager : MonoBehaviour {

    private Player_movement player;
    private Enemy_manager enemy;
    private Score_manager thescoremanager ;







    void Start () {

        player = FindObjectOfType<Player_movement>();
        enemy = FindObjectOfType<Enemy_manager>();
        thescoremanager = FindObjectOfType<Score_manager>();

    }

    void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)       
    {
        if (other.gameObject.tag == "enemy" && gameObject.tag != "enemybullet" && !other.name.Contains("spike") )
        {
            
            
             //   enemy.GetEnemyHit();
                thescoremanager.Addscore(100);
                other.gameObject.SetActive(false);
            

            Destroy(gameObject);
        }
         else if ( other.gameObject.tag == "Player" && gameObject.tag == "enemybullet")              
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



