using StarterAssets;
using UnityEngine;

public class GrabThings : MonoBehaviour
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
            if (_input.lGrab)
            {
                Debug.Log("Grab");
            }

            else if (_input.lRelease)
            {
                Debug.Log("Let Go");
            }
        }
      
    }
}
