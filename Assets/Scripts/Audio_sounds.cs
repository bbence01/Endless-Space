using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_sounds : MonoBehaviour {

    public static Audio_sounds instance = null;      
    private static Audio_sounds a_instance;

    public int music;

    void Start()
    {


    }



        void Update()
    {

    }

    public static Audio_sounds _instance
    {
        get
        {
            if (a_instance == null)
            {
                a_instance = new GameObject("Audio_sounds").AddComponent<Audio_sounds>();
            }
            else if (a_instance == true)
            {
                Destroy(a_instance);
            }
            DontDestroyOnLoad(a_instance);



            return a_instance;
        }
    }



    
}
