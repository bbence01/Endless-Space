using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Object_Pooler : MonoBehaviour {

    public GameObject pooledobject;

    public int pooledamount;

    List<GameObject> pooledobjects;
    


	// Use this for initialization
	void Start ()
    {

        pooledobjects = new List<GameObject>(); //lista 

        for(int i= 0; i < pooledamount;i++) // végig megyünk a listán, deaktivájuk ha
        {

            GameObject obj = (GameObject)Instantiate(pooledobject); // a lista eleme a pooledobj
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }


	}



	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject Getobjectpooled() // 
    {
        for(int i= 0; i<pooledobjects.Count;i++)
        {
            if(!pooledobjects[i].activeInHierarchy) // ha az i edik elem nemaktív
            {
                return pooledobjects[i];
            }
            else { continue; }
        }

        GameObject obj = (GameObject)Instantiate(pooledobject); // a lista eleme a pooledobj
        obj.SetActive(false);
        pooledobjects.Add(obj);
        return obj;  // visszadajuk a most készített obj-et
    }

}
