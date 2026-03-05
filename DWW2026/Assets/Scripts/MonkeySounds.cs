using System.Security.Cryptography;
using UnityEngine;

public class MonkeySounds : MonoBehaviour
{

    public Rigidbody monkey;
    public float forceAmt;
    int randomSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        monkey.GetAccumulatedForce(forceAmt);




    }


    public void swing()
    {

        if (forceAmt > 1) {


            AudioManager.Instance.Play(AudioManager.SoundType.Swing);



        }

    }

    public void grab()
    {
         randomGen(1,2);

            if (randomSelect == 1) { AudioManager.Instance.Play(AudioManager.SoundType.Grab1);}
            if (randomSelect == 2) { AudioManager.Instance.Play(AudioManager.SoundType.Grab2); }

    }

    public void release()
    {

        if (forceAmt > 1)
        {


            AudioManager.Instance.Play(AudioManager.SoundType.Swing);



        }



    }
    void randomGen(int min, int max)
    {


        //set to the amount of sounds
        randomSelect = Random.Range(0, 2);

    }



}
