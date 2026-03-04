using StarterAssets;
using System.Security.Cryptography;
using UnityEngine;

public class GrabThingsRight : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public Transform monkeyBody; 
    private bool repeat;
    private Vector3 raise; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
        repeat = false;
        raise = monkeyBody.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (repeat)
        {
            raise.y = 2;
            monkeyBody.position += raise * Time.deltaTime; 
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 0)
        {
            if (_input.rGrab && repeat == false)
            {
                repeat = true; 
            }

            else if (!_input.rGrab)
            {
                repeat = false; 
            }
        }

    }
}