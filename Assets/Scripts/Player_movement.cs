using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player_movement : MonoBehaviour {

    private Rigidbody2D myridgedbody;     

    public float movespeed;    
    private float movespeedstore;          
   

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

    public float jumpforce;   
    public float jumptime;
    private float jumptimecounter;   
    private bool stoppedjumping;     
    private bool candoublejump;

   

    public bool grounded; 
    public LayerMask whatisground;    
    public Transform groundcheck;
    public float groundcheckR;

    private float life;
    public Text lifetext;

    private Animator myanimator;
    public Game_manager thegamemanager;
    private Audio_manager sound;
    private Shoot_bullet shoot;
    private Pause_menu pause;


 


    void Start ()
    {


        myridgedbody = GetComponent<Rigidbody2D>();     

        myanimator = GetComponent<Animator>();  

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
        
        

        

        sound.MainMusic();


    }

    void Update ()
    {
        lifetext.text = "Life: " + Mathf.Round(life);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            myridgedbody.velocity = new Vector2(tempMoveSpeedUp, myridgedbody.velocity.y);

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myridgedbody.velocity = new Vector2(tempMoveSpeedDown, myridgedbody.velocity.y);
        }
        else
        {
            myridgedbody.velocity = new Vector2(movespeed, myridgedbody.velocity.y);             

        }




        if(transform.position.x > speedMilestoneCounte)
        {
            speedMilestoneCounte += speedIncreaseMilestone;   
            movespeed = movespeed * speedmulti;    

            speedIncreaseMilestone = speedIncreaseMilestone * speedmulti;        

            

           

            tempMoveSpeedUp = movespeed * speedup;

            tempMoveSpeedDown = movespeed * speeddown;



        }


        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckR, whatisground);          


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))      
        { 
            if (grounded)   
            {
                myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);
                stoppedjumping = false;
                sound.JumpSound();
             

            }

            if(!grounded && candoublejump)  
            {
                myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);
                jumptimecounter = jumptime;
                stoppedjumping = false;
                candoublejump = false;    
                sound.JumpSound();

            }

        }

        if ( (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)  ) && !stoppedjumping )          
        {
            if (jumptimecounter > 0)
            {
               
                
                    myridgedbody.velocity = new Vector2(myridgedbody.velocity.x, jumpforce);

                    jumptimecounter -= Time.deltaTime;
                
            }

        }

        if ( Input.GetKeyUp(KeyCode.UpArrow)  || Input.GetKeyUp(KeyCode.W) )            
        {

            jumptimecounter = 0;
            stoppedjumping = true;
        }
        

        if(grounded)              
        {
            jumptimecounter = jumptime;
            candoublejump = true;
        }

        myanimator.SetFloat("speed", myridgedbody.velocity.x);         
        myanimator.SetBool("grounded", grounded);       

     

       





        if (Input.GetKeyDown(KeyCode.Space)  )
        {
            shoot.Fire();
        }


        if (Input.GetKeyDown(KeyCode.P))      
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

            thegamemanager.EndGame();    

            speedIncreaseMilestone = speedIncreaseMilestoneStore;           
            speedMilestoneCounte = speedmilestonecountstore;
            movespeed = movespeedstore;
            tempMoveSpeedDown = tempMoveSpeedDownstore;
            tempMoveSpeedUp = tempMoveSpeedUpstore;
            life = 3f;

            sound.DeathSound();


        }


            if (other.gameObject.tag == "enemy")       
        {
            other.gameObject.SetActive(false);

            GetPlayerHit();

        }


    }



    public void GetPlayerHit()
    {

        life = life - 1;
        sound.HitSound();
        if (life == 0)
        {
            {



                thegamemanager.EndGame();    

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
