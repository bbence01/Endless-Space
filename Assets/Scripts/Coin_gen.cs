using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_gen : MonoBehaviour {

    public Object_Pooler coinpool;

    public float distbetweenc;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Spawncoins( Vector3 startposition)    
    {

        GameObject coin1 = coinpool.Getobjectpooled();
        coin1.transform.position = startposition;
        coin1.SetActive(true);

        GameObject coin2 = coinpool.Getobjectpooled();
        coin2.transform.position = new Vector3(startposition.x - distbetweenc, startposition.y, startposition.z);     
        coin2.SetActive(true);


        GameObject coin3 = coinpool.Getobjectpooled();
        coin3.transform.position = new Vector3(startposition.x + distbetweenc, startposition.y, startposition.z);   
        coin3.SetActive(true);

    }
}
