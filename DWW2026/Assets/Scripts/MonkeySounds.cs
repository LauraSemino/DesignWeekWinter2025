using StarterAssets;
using System;
using System.Security.Cryptography;
using UnityEngine;

public class MonkeySounds : MonoBehaviour
{
    StarterAssetsInputs _input;
    public Rigidbody monkey;
    public float forceAmt;
    int randomSelect;
    bool grabRight = true;
    bool grabLeft = true;
    public AudioSource wind;
    

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

        wind.volume = forceAmt / 20;


        //impact


        //grab noises
        if (_input.rGrab == true && grabRight || _input.lGrab == true && grabLeft)
        {
            grab();

            if (_input.rGrab == true) { grabRight = false; }
            if (_input.lGrab == true) { grabLeft = false; }
        }

        if (_input.rGrab == false && !grabRight || _input.lGrab == false && !grabLeft)
        {
            
            release();

            if (_input.rGrab == false) { grabRight = true; }
            if (_input.lGrab == false) { grabLeft = true; }
        }





    }


    public void swing()
    {

        if (forceAmt > 1) {


            AudioManager.Instance.Play(AudioManager.SoundType.Swing);



        }

    }

    public void grab()
    {


 


            randomGen(1, 2);

            AudioManager.Instance.Play(AudioManager.SoundType.Grab1);
            if (randomSelect == 1) { AudioManager.Instance.Play(AudioManager.SoundType.Grab1); }
            if (randomSelect == 2) { AudioManager.Instance.Play(AudioManager.SoundType.Grab2); }



    }

    public void release()
    {
       


            AudioManager.Instance.Play(AudioManager.SoundType.Release1);




    }
    void randomGen(int min, int max)
    {


        //set to the amount of sounds
        randomSelect = UnityEngine.Random.Range(0, 2);

    }



}
