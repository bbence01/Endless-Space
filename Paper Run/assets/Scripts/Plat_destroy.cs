using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_destroy : MonoBehaviour {

    public GameObject platdestpoint;

    // Use this for initialization
    void Start()
    {
        platdestpoint = GameObject.Find("platdestpoint"); //keresünk egy game objectet aminek ez a neve
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platdestpoint.transform.position.x)

        {
            //Destroy(gameObject); ha csak törlöm
            // object pooling
            gameObject.SetActive(false);

        }


     }
}

