using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_destroy : MonoBehaviour {

    public GameObject platdestpoint;

    void Start()
    {
        platdestpoint = GameObject.Find("platdestpoint");        
    }

    void Update()
    {
        if (transform.position.x < platdestpoint.transform.position.x)

        {
            gameObject.SetActive(false);

        }


     }
}

