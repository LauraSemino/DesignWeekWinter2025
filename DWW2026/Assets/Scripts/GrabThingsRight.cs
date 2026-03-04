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
                Debug.Log(transform.position.y - monkeyBody.position.y);
                rb.AddForce((grabpos - releasepos) * 10, ForceMode.Impulse);
                Debug.Log("release");
                _input.rRelease = false;
            }

        }

    }
    public void OnTriggerExit(Collider other)
    {
        closeHandIcon.SetActive(false);
        openhandIcon.SetActive(true);
        checkGrab = false;
        rb.useGravity = true;

    }
}
