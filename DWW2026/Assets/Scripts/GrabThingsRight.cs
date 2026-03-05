using StarterAssets;
using UnityEngine;

public class GrabThingsRight : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public FirstPersonController fpc;
    public Transform monkeyBody;
    public Rigidbody rb;
    private bool repeat;
    private Vector3 raise;
    public Vector3 grabpos;
    public Vector3 releasepos;

    public Transform handpos;

    bool checkGrab = false;

    public GameObject closeHandIcon;
    public GameObject openhandIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.rGrab == false)
        {
            checkGrab = false;
            rb.useGravity = true;
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (_input.rRelease == true)
        {
            _input.rRelease = false;
        }
        

    }
    public void OnTriggerStay(Collider collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            if (_input.rGrab == true)
            {               
                if (checkGrab == false)
                {
                    closeHandIcon.SetActive(true);
                    openhandIcon.SetActive(false);
                    checkGrab = true;
                    grabpos = handpos.position;
                }
                rb.linearVelocity = Vector3.zero;
                rb.useGravity = false;
            }

            //a^2 = lastpos^2 + currentpos^2 - 2bc * cos(A)

            if (_input.rRelease == true)
            {
                closeHandIcon.SetActive(false);
                openhandIcon.SetActive(true);
                releasepos = handpos.position;
                Vector3 force = (grabpos - releasepos) * 10;
                if (Mathf.Abs(force.x) >= 100)
                {
                    force.x = Mathf.Sign(force.x) * 100;
                    
                }
                if (Mathf.Abs(force.y) >= 100)
                {
                    force.x = Mathf.Sign(force.y) * 100;

                }
                if (Mathf.Abs(force.z) >= 100)
                {
                    force.x = Mathf.Sign(force.z) * 100;

                }
                rb.AddForce(force, ForceMode.Impulse);
                Debug.Log("release");
                _input.rRelease = false;
            }

        }

    }
    public void OnTriggerExit(Collider other)
    {
        //grabpos = Vector2.zero;
       // releasepos = Vector2.zero;
        closeHandIcon.SetActive(false);
        openhandIcon.SetActive(true);
        checkGrab = false;
        rb.useGravity = true;

    }
}
