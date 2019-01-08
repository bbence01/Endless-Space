using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling_Background : MonoBehaviour {

    public bool scrolling;
    public bool paralax;

    public float backgroundsize;


    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftindex;
    private int rightindex;


    public float paralaxSpeed;
    private float lastCameraX;


	// Use this for initialization
	void Start () {

        

        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];

        for(int i=0; i < transform.childCount;i++)
        {

            layers[i] = transform.GetChild(i);
        }

        leftindex = 0;
        rightindex = layers.Length - 1;


	}
	
	// Update is called once per frame
	void Update () {

        if (paralax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeed);
        }


        lastCameraX = cameraTransform.position.x;

        if (scrolling)
        {
            if (cameraTransform.position.x < (layers[leftindex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }

            if (cameraTransform.position.x > (layers[rightindex].transform.position.x - viewZone))
            {
                ScrollRight();
            }

        }


    }


    private void ScrollLeft()
    {
        int lastRight = rightindex;
        layers[rightindex].position = new Vector3  (layers[leftindex].position.x - backgroundsize, layers[leftindex].position.y, layers[leftindex].position.z);
        leftindex = rightindex;
        rightindex--;
        if (rightindex < 0)
            rightindex = layers.Length - 1;

    }

     private void ScrollRight()
    {

        int lastLeft = leftindex;
        layers[leftindex].position = new Vector3(layers[rightindex].position.x + backgroundsize, layers[rightindex].position.y, layers[rightindex].position.z);
        // layers[leftindex].position = Vector3.right * (layers[rightindex].position.x + backgroundsize);
        rightindex = leftindex;
        leftindex++;
        if (leftindex == layers.Length)
            leftindex = 0;


    }

}
