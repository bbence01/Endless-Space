using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_gen : MonoBehaviour {

    

    public Object_Pooler[] platformObjecPools;
    private int platselector;

    public Transform platgenpoint;



    public float platdist; //távolság a platformok között az x tengelyen
    public float platdistmin;
    public float platdistmax;


    // public GameObject[] platforms;

    private float platwidth; // egy adott platform széllesége
    private float[] platwidths;

     //  objectompool lista

    private float minheight; //nem mehet magasabbra vagy alacsonybra, 
    private float maxheight; //  a camerán belül maradnak a platformok,

    public Transform maxheightpoint; // a a karakterrel eggyüt mozgó pont amihez képest y tengelyen helyezkednek ell a platformok
    public Transform minheightpoint; // a a karakterrel eggyüt mozgó pont amihez képest y tengelyen helyezkednek ell a platformok


    public float maxheigtchange; // a maximum lehetséges távolság két platform között az y tengelyen
    private float heightchange; // a tényleges távolság két platform közzöt az y tengelyen

    private Coin_gen thecoingen;
    public float cointhreshold; // milyen gyakran legyenek érmék

    public Object_Pooler spikepool;
    public float spikethreshold;
    

   
    public Object_Pooler poweruppool;
    public float powerupthreshold;
    public float poweruphight;


    public Object_Pooler enemypool;
    public float enemythreshold;
    public float enemyhight;

    public Option_values values;

    // Use this for initialization


        /*
    private static Platform_gen p_instance;
   

    
    public static Platform_gen _instance
    {
        get
        {
            if (p_instance == null)
            {
                p_instance = new GameObject("Platform_gen").AddComponent<Platform_gen>();
            }
            return p_instance;
        }
    }
    */

        void Awake()
    {
        /*
        cointhreshold = Option_values._instance.cointhreshold;
        spikethreshold = Option_values._instance.spikethreshold;
        powerupthreshold = Option_values._instance.powerupthreshold;
        enemythreshold = Option_values._instance.enemythreshold;
        */

    }



    void Start ()
    {
        thecoingen = FindObjectOfType<Coin_gen>();
        values = FindObjectOfType<Option_values>();


        cointhreshold = values.cointhreshold;
        spikethreshold = values.spikethreshold;
        powerupthreshold = values.powerupthreshold;
        enemythreshold = values.enemythreshold;
        

        //  platwidth = platform.GetComponent<BoxCollider2D>().size.x;
        platwidths = new float[platformObjecPools.Length];

        for(int i = 0; i< platformObjecPools.Length; i++) //végig járjuk az objectpool listát  
        {
            platwidths[i] = platformObjecPools[i].pooledobject.GetComponent<BoxCollider2D>().size.x; //értéket adunk a platform szélesség lista elemeinek a hozzá tartozó platform alapján 
        }

        minheight = minheightpoint.position.y; //transform.position.y;// -1.5f;
        maxheight = maxheightpoint.position.y;

 
       

    }

    // Update is called once per frame
    void Update ()
    {
        // emlkeztető, véletlen r, 10-20 féle platform egybe az ellenséggel, fix távlságok, r case, azon belül lesznek az if-ek, ,y is változik

        if(transform.position.x < platgenpoint.position.x ) // ha a generátor pot előrébb van mint a camerapont
        {

            platdist = Random.Range(platdistmin, platdistmax);  //random a pont kettő közt

            platselector = Random.Range(0, platformObjecPools.Length);// a szám maximum a lista nagysága leget

            heightchange = transform.position.y + Random.Range(maxheigtchange, -maxheigtchange); //meghatározza a platform helyét 

            if(heightchange > maxheight ) // a kamerán belülre kényszBizeríti a platformot, ha kiesne belőle
            {
                heightchange = maxheight - Random.Range(0f, maxheigtchange);

            }
            else if( heightchange < minheight) 
            {

                heightchange = minheight + Random.Range(0f, maxheigtchange);

            }




            // transform.position = new Vector3(transform.position.x + (platwidths[platselector] /2 )+ platdist, transform.position.y, transform.position.z); //  mozduljon arréb a pont
             transform.position = new Vector3(transform.position.x + (platwidths[platselector]  ) + platdist, heightchange, transform.position.z); //  mozduljon arréb a pont

            //  Instantiate(platform, transform.position, transform.rotation);  // új platformot hozzunk létre, megismétli az előzt

            GameObject newplatform = platformObjecPools[platselector].Getobjectpooled();

            newplatform.transform.position = transform.position;
            newplatform.transform.rotation = transform.rotation;
            newplatform.SetActive(true);

            if (Random.Range(0f, 100f) < cointhreshold) // randomizálja hogy melyik platformon less érma
            {

                thecoingen.Spawncoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z)); // egy egységgel a platform fölé rakja az érméket

            }


            if (Random.Range(0f, 100f) < spikethreshold) // randomizálja hogy melyik platformon less tüske
            {

                GameObject newspike = spikepool.Getobjectpooled(); // a megeadott elemet sokszorosítja


                float spikeXposition = Random.Range(-platwidths[platselector] / 2f +1f, platwidths[platselector] / 2f - 1f); //véletlenszerő értéket számol az adott platform két vége között

                Vector3 spikeposition = new Vector3(spikeXposition, 0.5f, 0f); //a tüske a platformhoz képest hol legyen, ha 0.5-tel megesebb pont a felszínen van

                newspike.transform.position = transform.position + spikeposition;
                newspike.transform.rotation = transform.rotation;
                newspike.SetActive(true);

            }


            if (Random.Range(0f, 100f) < powerupthreshold)  //eldöntjük hogy legyen e itt power upp
            {
                GameObject newpowerup = poweruppool.Getobjectpooled();

                newpowerup.transform.position = transform.position + new Vector3(platdist / 2f, Random.Range(1f, poweruphight), 0f); // két platform közé keről

                newpowerup.SetActive(true);

            }

            if (Random.Range(0f, 100f) < enemythreshold)
            {
                GameObject newenemy = enemypool.Getobjectpooled();

                newenemy.transform.position = transform.position + new Vector3(platdist / 2f, Random.Range(1f, enemyhight), 0f); // két platform közé keről

                newenemy.SetActive(true);

            }



            //transform.position = new Vector3(transform.position.x + (platwidths[platselector] / 2), heightchange, transform.position.z); //  mozduljon arréb a pont


        }


    }
}
