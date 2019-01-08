using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour {

    public Player_movement theplayer;  

    private Vector3 lastplayerposition;           
	void Start ()
    {

        theplayer = FindObjectOfType<Player_movement>();         
        lastplayerposition = theplayer.transform.position;   

    }
	
	void Update ()
    {

        transform.position = new Vector3(theplayer.transform.position.x + 5f, transform.position.y, transform.position.z);             


    }
}
