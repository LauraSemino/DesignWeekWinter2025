using StarterAssets;
using System;
using System.Security.Cryptography;
using UnityEngine;

public class MonkeySounds : MonoBehaviour
{
    StarterAssetsInputs _input;
    Rigidbody monkey;
    public float forceAmt;
    int randomSelect;
    

    GrabThingsRight handRight;
    GrabThingTrigger handLeft;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        forceAmt = monkey.linearVelocity.magnitude;

    }


    public void swing()
    {

        if (forceAmt > 1) {


            AudioManager.Instance.Play(AudioManager.SoundType.Swing);



        }

    }

    public void grab()
    {


       bool callOnce = true;


        if(callOnce == true)
        {

            Debug.Log("yep");

            randomGen(1, 2);
            AudioManager.Instance.Play(AudioManager.SoundType.Grab1);
            if (randomSelect == 1) { AudioManager.Instance.Play(AudioManager.SoundType.Grab1); }
            if (randomSelect == 2) { AudioManager.Instance.Play(AudioManager.SoundType.Grab2); }

            callOnce = false;

        }


    }

    public void release()
    {
        Debug.Log("Release");
        if (forceAmt > 1)
        {


            AudioManager.Instance.Play(AudioManager.SoundType.Swing);



        }



    }
    void randomGen(int min, int max)
    {


        //set to the amount of sounds
        randomSelect = UnityEngine.Random.Range(0, 2);

    }



}
