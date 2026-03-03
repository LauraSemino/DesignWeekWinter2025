using StarterAssets;
using UnityEngine;

public class GrabThingsRight : MonoBehaviour
{
    private StarterAssetsInputs _input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (_input.rGrab)
            {
               // Debug.Log("Grab");
            }

            if (_input.rRelease)
            {
                Debug.Log("Let Go");
            }
        }

    }
}