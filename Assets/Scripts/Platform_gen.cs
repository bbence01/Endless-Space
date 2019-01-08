using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_gen : MonoBehaviour {

    

    public Object_Pooler[] platformObjecPools;
    private int platselector;

    public Transform platgenpoint;



    public float platdist;       
    public float platdistmin;
    public float platdistmax;


    private float platwidth;     
    private float[] platwidths;

    private float minheight;      
    private float maxheight;        

    public Transform maxheightpoint;               
    public Transform minheightpoint;               


    public float maxheigtchange;           
    private float heightchange;          

    private Coin_gen thecoingen;
    public float cointhreshold;     

    public Object_Pooler spikepool;
    public float spikethreshold;
    

   
    public Object_Pooler poweruppool;
    public float powerupthreshold;
    public float poweruphight;


    public Object_Pooler enemypool;
    public float enemythreshold;
    public float enemyhight;

    public Option_values values;


        void Awake()
    {
    }



    void Start ()
    {
        thecoingen = FindObjectOfType<Coin_gen>();
        values = FindObjectOfType<Option_values>();


        cointhreshold = values.cointhreshold;
        spikethreshold = values.spikethreshold;
        powerupthreshold = values.powerupthreshold;
        enemythreshold = values.enemythreshold;
        

        platwidths = new float[platformObjecPools.Length];

        for(int i = 0; i< platformObjecPools.Length; i++)       
        {
            platwidths[i] = platformObjecPools[i].pooledobject.GetComponent<BoxCollider2D>().size.x;             
        }

        minheight = minheightpoint.position.y;  
        maxheight = maxheightpoint.position.y;

 
       

    }

    void Update ()
    {
        if(transform.position.x < platgenpoint.position.x )          
        {

            platdist = Random.Range(platdistmin, platdistmax);      

            platselector = Random.Range(0, platformObjecPools.Length);       

            heightchange = transform.position.y + Random.Range(maxheigtchange, -maxheigtchange);     

            if(heightchange > maxheight )          
            {
                heightchange = maxheight - Random.Range(0f, maxheigtchange);

            }
            else if( heightchange < minheight) 
            {

                heightchange = minheight + Random.Range(0f, maxheigtchange);

            }




             transform.position = new Vector3(transform.position.x + (platwidths[platselector] /2 )+ platdist, transform.position.y, transform.position.z);      
            GameObject newplatform = platformObjecPools[platselector].Getobjectpooled();

            newplatform.transform.position = transform.position;
            newplatform.transform.rotation = transform.rotation;
            newplatform.SetActive(true);

            if (Random.Range(0f, 100f) < cointhreshold)       
            {

                thecoingen.Spawncoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));         

            }


            if (Random.Range(0f, 100f) < spikethreshold)       
            {

                GameObject newspike = spikepool.Getobjectpooled();     


                float spikeXposition = Random.Range(-platwidths[platselector] / 2f +1f, platwidths[platselector] / 2f - 1f);         

                Vector3 spikeposition = new Vector3(spikeXposition, 0.5f, 0f);              

                newspike.transform.position = transform.position + spikeposition;
                newspike.transform.rotation = transform.rotation;
                newspike.SetActive(true);

            }


            if (Random.Range(0f, 100f) < powerupthreshold)        
            {
                GameObject newpowerup = poweruppool.Getobjectpooled();

                newpowerup.transform.position = transform.position + new Vector3(platdist / 2f, Random.Range(1f, poweruphight), 0f);     

                newpowerup.SetActive(true);

            }

            if (Random.Range(0f, 100f) < enemythreshold)
            {
                GameObject newenemy = enemypool.Getobjectpooled();

                newenemy.transform.position = transform.position + new Vector3(platdist / 2f, Random.Range(1f, enemyhight), 0f);     

                newenemy.SetActive(true);

            }



            transform.position = new Vector3(transform.position.x + (platwidths[platselector] / 2), heightchange, transform.position.z);      


        }


    }
}
