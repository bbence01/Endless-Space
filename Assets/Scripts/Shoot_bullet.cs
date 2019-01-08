using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shoot_bullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float nextFire;
    public float fireRate;



    public GameObject EnemybulletPrefab;
    public Transform EnemybulletSpawn; 
    public float enemyfireRate;   
    private float enemynextFire;


    private Audio_manager sound;

    public object OnCollisionEnter2D { get; private set; }


    void Start () {

        sound = FindObjectOfType<Audio_manager>();


    }
	
	void Update () {


    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            sound.ShootSound();
           
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
           
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 20;
      
            Destroy(bullet, 3.0f);
         
        }


    }

    public void EnemyFire()
    {
        {

            sound.ShootSound();

            var enemybullet = (GameObject)Instantiate(EnemybulletPrefab, EnemybulletSpawn.position, EnemybulletSpawn.rotation);

            enemybullet.GetComponent<Rigidbody2D>().velocity = enemybullet.transform.right * -20;

            Destroy(enemybullet, 3.0f);



        }

    }




}
