using Cinemachine.Utility;
using JetBrains.Annotations;
using UnityEngine;

public class HandMove : MonoBehaviour
{

    //where the hand is trying to get to
    public GameObject endPoint;

    //the hands in question
    public GameObject hand;


    Vector3 handPos;
    Vector3 endPos;
    Vector3 travelPos;

    //force modifiers

    float forcePower = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        //setting values
        handPos = hand.transform.position;
        endPos = endPoint.transform.position;
        travelPos = handPos - endPos;

        hand.transform.position += travelPos;


    }
}
