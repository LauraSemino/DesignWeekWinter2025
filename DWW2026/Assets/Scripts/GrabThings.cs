using StarterAssets;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class GrabThings : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public FirstPersonController fpc;
    public Transform monkeyBody;
    public Rigidbody rb;
    private bool repeat;
    private Vector3 raise;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
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

    public void OnTriggerStay(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 6)
        {
          //Debug.Log("touch");
            /*  if (_input.lGrab && repeat == false)
              {
                  repeat = true; 
              }

              else if (!_input.lGrab)
              {
                  repeat = false; 
              }*/
            if(_input.lGrab == true)
            {
                rb.linearVelocity = Vector3.zero;
                rb.useGravity = false;
            }
            if(_input.lGrab == false)
            {
                rb.useGravity = true;
            }


            if(_input.lRelease == true)
            {
                Debug.Log(transform.position.y - monkeyBody.position.y);
                rb.AddForce(new Vector3(0, (transform.position.y - monkeyBody.position.y) * 10, 0), ForceMode.Impulse);
                Debug.Log("release");
                _input.lRelease = false;
            }

        }
      
    }
    public void OnTriggerExit(Collider other)
    {
        rb.useGravity = true;
    }
}
