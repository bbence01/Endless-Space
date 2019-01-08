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




     public int shotChance;       
     public float shotTimeMin, shotTimeMax;            
   

    private Shoot_bullet shoot;


    void Start () {

        shoot = FindObjectOfType<Shoot_bullet>();

        sound = FindObjectOfType<Audio_manager>();

        life = 1;

    }
	
	void Update () {



        ActivateEnemyShooting();

    }

    void ActivateEnemyShooting()
    {
            
            
                  if (Time.time > enemynextFire )
                {
                     enemynextFire = Time.time + enemyfireRate;


                

                    var enemybullet = (GameObject)Instantiate(EnemybulletPrefab, EnemybulletSpawn.position, EnemybulletSpawn.rotation);

                    enemybullet.GetComponent<Rigidbody2D>().velocity = enemybullet.transform.right * -20;

                    Destroy(enemybullet, 3.0f);



                }

            
        }

    public void GetEnemyHit()
    {
        sound.HitSound();
    }


}
