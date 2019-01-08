using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour {


    
   
    public int life;

    public GameObject EnemybulletPrefab;
    public Transform EnemybulletSpawn;
    public float enemyfireRate;
    private float enemynextFire;

    private Audio_manager sound;




     public int shotChance; //probability of 'Enemy's' shooting during tha path
     public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
   

    private Shoot_bullet shoot;


    // Use this for initialization
    void Start () {

        shoot = FindObjectOfType<Shoot_bullet>();

        sound = FindObjectOfType<Audio_manager>();

       // Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));

        life = 1;

        //shoot.EnemyFire();

    }
	
	// Update is called once per frame
	void Update () {



        ActivateShooting();

    }

    void ActivateShooting()
    {
       // if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
       
            //  shoot.EnemyFire();
            // Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);

            
            
                  if (Time.time > enemynextFire )
                {
                     enemynextFire = Time.time + enemyfireRate;


                

                    //sound.ShootSound();

                    // Create the Bullet from the Bullet Prefab
                    var enemybullet = (GameObject)Instantiate(EnemybulletPrefab, EnemybulletSpawn.position, EnemybulletSpawn.rotation);

                    // Add velocity to the bullet
                    enemybullet.GetComponent<Rigidbody2D>().velocity = enemybullet.transform.right * -20;

                    // Destroy the bullet after x seconds
                    Destroy(enemybullet, 3.0f);



                }

            
        }

    public void GetEnemyHit()
    {
        sound.HitSound();
        life = life - 1;
        //if(life <= 0)
        {
            
           // gameObject.SetActive(false);
            life = 1;


        }
    }


}
