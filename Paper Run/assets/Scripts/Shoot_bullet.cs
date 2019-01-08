using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shoot_bullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float nextFire;
    public float fireRate;



    ///public GameObject EnemybulletSpawns;
    ///
    public GameObject EnemybulletPrefab;
    public Transform EnemybulletSpawn; 
    public float enemyfireRate;   
    private float enemynextFire;


    private Audio_manager sound;

    public object OnCollisionEnter2D { get; private set; }


    // Use this for initialization
    void Start () {

        sound = FindObjectOfType<Audio_manager>();


    }
	
	// Update is called once per frame
	void Update () {


    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            sound.ShootSound();

            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 20;

            // Destroy the bullet after x seconds
            Destroy(bullet, 3.0f);


         
        }


    }

    public void EnemyFire()
    {
      //  if (Time.time > enemynextFire )
        {
           // enemynextFire = Time.time + enemyfireRate;


            //EnemybulletSpawns = GameObject.Find("EnemybulletSpawn");

          //  EnemybulletSpawn = EnemybulletSpawns.transform;

            sound.ShootSound();

            // Create the Bullet from the Bullet Prefab
            var enemybullet = (GameObject)Instantiate(EnemybulletPrefab, EnemybulletSpawn.position, EnemybulletSpawn.rotation);

            // Add velocity to the bullet
            enemybullet.GetComponent<Rigidbody2D>().velocity = enemybullet.transform.right * -20;

            // Destroy the bullet after x seconds
            Destroy(enemybullet, 3.0f);



        }

    }




}
