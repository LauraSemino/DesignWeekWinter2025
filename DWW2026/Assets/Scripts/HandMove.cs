using Cinemachine.Utility;
using JetBrains.Annotations;
using UnityEngine;

public class HandMove : MonoBehaviour
{

    //where the hand is trying to get to
    public GameObject endPoint;

    //the hands in question
    public GameObject hand;

    //hand rigid body to apply forces to
    public Rigidbody handBody;

    Vector3 handPos;
    Vector3 endPos;
    Vector3 endForce;

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

           

        //adding force!
        handBody.AddForce(endForce.x, endForce.y, endForce.z);


        //multiplying force by the modifier

       

        //if increase the amount of force the farther away the hand is from the end point.

        endForce = handPos - endPos * forcePower;



        //X AXIS
        if (handPos.x >= endPos.x)
        {
            endForce.x = -1;


        }
        else if (handPos.x <= endPos.x)
        {

            endForce.x = 1;


        }


        //Y AXIS

        if (handPos.y >= endPos.y)
        {
            endForce.y = -1;


        }
        else if (handPos.y <= endPos.y)
        {

            endForce.y = 1;


        }

        //Z AXIS

        if (handPos.z >= endPos.z)
        {
            endForce.z = -1;


        }
        else if (handPos.z <= endPos.z)
        {

            endForce.z = 1;


        }




    }
}
