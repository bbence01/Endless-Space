using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_gen : MonoBehaviour {

    public Object_Pooler coinpool;

    public float distbetweenc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawncoins( Vector3 startposition) // legenerálja az érméket
    {

        GameObject coin1 = coinpool.Getobjectpooled();
        coin1.transform.position = startposition;
        coin1.SetActive(true);

        GameObject coin2 = coinpool.Getobjectpooled();
        coin2.transform.position = new Vector3(startposition.x - distbetweenc, startposition.y, startposition.z); //  ball  kerül
        coin2.SetActive(true);


        GameObject coin3 = coinpool.Getobjectpooled();
        coin3.transform.position = new Vector3(startposition.x + distbetweenc, startposition.y, startposition.z); // jobbra kerül
        coin3.SetActive(true);

    }
}
