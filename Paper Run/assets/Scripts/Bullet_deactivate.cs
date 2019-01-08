using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_deactivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
           // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
            Destroy(other);
            other.gameObject.SetActive(false);
        }
    }*/

}
