using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Object_Pooler : MonoBehaviour {

    public GameObject pooledobject;

    public int pooledamount;

    List<GameObject> pooledobjects;
    


	void Start ()
    {

        pooledobjects = new List<GameObject>();  

        for(int i= 0; i < pooledamount;i++)       
        {

            GameObject obj = (GameObject)Instantiate(pooledobject);      
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }


	}



	
	
	void Update ()
    {
		
	}

    public GameObject Getobjectpooled() 
    {
        for(int i= 0; i<pooledobjects.Count;i++)
        {
            if(!pooledobjects[i].activeInHierarchy) 
            {
                return pooledobjects[i];
            }
            else { continue; }
        }

        GameObject obj = (GameObject)Instantiate(pooledobject); 
        obj.SetActive(false);
        pooledobjects.Add(obj);
        return obj;  
    }

}
