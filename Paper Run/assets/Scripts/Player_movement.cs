using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}


public class Player_movement : MonoBehaviour {

    private Rigidbody2D myridgedbody; //csak ez a script látja

    public float movespeed; // milyen gyorsan mozog
    private float movespeedstore; // elmentjük hogy erre vissza lehessen állítan ( mined adatnál)
   

    private float tempMoveSpeedUp;
    private float tempMoveSpeedDown;

    private float tempMoveSpeedUpstore;
    private float tempMoveSpeedDownstore;
  



    public float speedmulti;

    public float speedup;
    public float speeddown;
    

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCounte;
    private float speedmilestonecountstore;

    public float jumpforce; // mekkorát ugrik
    public float jumptime;
    private float jumptimecounter; // csak számlál
    private bool stoppedjumping; // igaz ha nem ugrik
    private bool candoublejump;

   

    public bool grounded; 
    public LayerMask whatisground; //mi legyen a föld
    public Transform groundcheck;
    public float groundcheckR;

    private float life;
    public Text lifetext;

    //   private Collider2D mycollider; //ötközés

    private Animator myanimator;
    public Game_manager thegamemanager;
    private Audio_manager sound;
    private Shoot_bullet shoot;
    private Pause_menu pause;


 


    // Use this for initialization
    //amit az elején akarok, mert csak egyszer csinálja meg 
    void Start ()
    {


        myridgedbody = GetComponent<Rigidbody2D>(); // hozzáfér a player adatához

       // mycollider = GetComponent<Collider2D>(); // a playerhez kapcsolt collidet használja

        myanimator = GetComponent<Animator>(); //animátor componensek

        jumptimecounter = jumptime;

        speedMilestoneCounte = speedIncreaseMilestone;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
       
        movespeedstore = movespeed;
        
        speedmilestonecountstore = speedMilestoneCounte;

   

        tempMoveSpeedUp = movespeed * speedup;

        tempMoveSpeedDown = movespeed * speeddown;

        tempMoveSpeedDownstore = tempMoveSpeedDown;
        tempMoveSpeedUpstore = tempMoveSpeedUp;


        pause = FindObjectOfType<Pause_menu>();


        sound = FindObjectOfType<Audio_manager>();

        shoot = FindObjectOfType<Shoot_bullet>();

        life = 3f;

        lifetext.text = "Life: " + Mathf.Round(life);  
        
        

        

        sound.MainTheme();


    }

    // Update is called once per frame, loop
    void Update ()
    {
        lifetext.text = "Life: " + Mathf.Round(life);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            myridgedbody.velocity = new Vector2(tempMoveSpeedUp, myridgedbody.velocity.y);
            //  movespeed = tempMoveSpeedUp;


        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myridgedbody.velocity = new Vector2(tempMoveSpeedDown, myridgedbody.velocity.y);
            //movespeed = tempMoveSpeedDown;
        }
        else
        {
            //movespeed = normalMoveSpeed;
            myridgedbody.velocity = new Vector2(movespeed, myridgedbody.velocity.y); //folyamatosan megy előre a movespeedben megadott érték szerint, felfelé nem mozog magátol 

        }




        if(transform.position.x > speedMilestoneCounte)
        {
            speedMilestoneCounte += speedIncreaseMilestone; //ha eléri hozzáad
            movespeed = movespeed * speedmulti; // növekedészik a sebeség

            speedIncreaseMilestone = speedIncreaseMilestone * speedmulti; // egyre messzebb vannak egymástól a növekedési pontok

            

           

            tempMoveSpeedUp = movespeed * speedup;

            tempMoveSpeedDown = movespeed * speeddown;



        }


        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckR, whatisground); // ha a player collider-e hozzáér a földhöz akkor igaz


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0)) // space-re és ball clickre ugrik
        { 
            if (grounded) // első ugrás
            {
                myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);
                stoppedjumping = false;
                sound.JumpSound();
             

            }

            if(!grounded && candoublejump)// második ugrás
            {
                myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);
                jumptimecounter = jumptime;
                stoppedjumping = false;
                candoublejump = false; // nem ugorhat többet
                sound.JumpSound();

            }

        }

        if ( (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)  || Input.GetMouseButton(0)) && !stoppedjumping) // ha tovább nyomjuk a gombot magasabbra ugrik a karakter
        {
            if (jumptimecounter > 0)
            {
               
                
                    myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);

                    jumptimecounter -= Time.deltaTime;
                
            }

        }

        if ( Input.GetKeyUp(KeyCode.UpArrow)  || Input.GetKeyUp(KeyCode.W) ||  Input.GetMouseButtonUp(0)  ) //amég as levegőben van 0 a számláló, így nem lehet folyamatosan ugrani
        {

            jumptimecounter = 0;
            stoppedjumping = true;
        }
        

        if(grounded) //ha a földön van ujra indul a számlálás, különben a következő frame-ben nem ugrana
        {
            jumptimecounter = jumptime;
            candoublejump = true;
        }

        myanimator.SetFloat("speed", myridgedbody.velocity.x); //  a sebeséget a ridegbodybd határozza meg, velocity.x-ként
        myanimator.SetBool("grounded", grounded); // az animátornál tabál lévő értékeket álítja

     

       





        if (Input.GetKeyDown(KeyCode.Space)  )
        {
            shoot.Fire();
        }


        if (Input.GetKeyDown(KeyCode.P)) // space-re és ball clickre ugrik
        {
            pause.Pausegame();

        }


    }

    private void OnCollisionEnter2D(Collision2D other)

    {
        if( other.gameObject.tag == "life")
        {
            life = life + 1;
        }

        if (other.gameObject.tag == "killbox")
        {

            thegamemanager.Restartgame(); // meghívja a metódust

            speedIncreaseMilestone = speedIncreaseMilestoneStore;           
            speedMilestoneCounte = speedmilestonecountstore;
            movespeed = movespeedstore;
            tempMoveSpeedDown = tempMoveSpeedDownstore;
            tempMoveSpeedUp = tempMoveSpeedUpstore;
            life = 3f;

            sound.DeathSound();


        }


            if (other.gameObject.tag == "enemy") // ha összeér a killbox-al jelölt objectumhoz(catcher)
        {
            other.gameObject.SetActive(false);

            GetPlayerHit();

          /*  if (life == 0)
            {
                {



                    thegamemanager.Restartgame(); // meghívja a metódust

                    speedIncreaseMilestone = speedIncreaseMilestoneStore;                    
                    speedMilestoneCounte = speedmilestonecountstore;
                    movespeed = movespeedstore;
                    tempMoveSpeedDown = tempMoveSpeedDownstore;
                    tempMoveSpeedUp = tempMoveSpeedUpstore;
                    

                    life = 3f;
                    sound.DeathSound();

                }
            }
            */
        }


    }



    public void GetPlayerHit()
    {

        life = life - 1;
        sound.HitSound();
        if (life == 0)
        {
            {



                thegamemanager.Restartgame(); // meghívja a metódust

                speedIncreaseMilestone = speedIncreaseMilestoneStore;
                movespeed = movespeedstore;
                speedMilestoneCounte = speedmilestonecountstore;
                tempMoveSpeedDown = tempMoveSpeedDownstore;
                tempMoveSpeedUp = tempMoveSpeedUpstore;


                life = 3f;
                sound.DeathSound();

            }
        }
        
    }



}
