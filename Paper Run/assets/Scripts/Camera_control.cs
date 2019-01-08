using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour {

    public Player_movement theplayer; //a karakter

    private Vector3 lastplayerposition; // hol volt a player van Z értéke, de nem számít
    //private float distancetomove; 

	// Use this for initialization
	void Start ()
    {

        theplayer = FindObjectOfType<Player_movement>(); // a játék elején a unity megkeresi a playert
        lastplayerposition = theplayer.transform.position; // x,y,z, kiolvassa

    }
	
	// Update is called once per frame
	void Update ()
    {

      //  distancetomove = theplayer.transform.position.x - lastplayerposition.x;

        transform.position = new Vector3(theplayer.transform.position.x + 5f, transform.position.y, transform.position.z); // nem változik az y és a z érték, nem ugrik a kamera

      //  lastplayerposition = theplayer.transform.position; // x,y,z, kiolvassa


    }
}
