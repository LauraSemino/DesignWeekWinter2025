using StarterAssets;
using UnityEngine;

public class GrabThingTrigger : MonoBehaviour
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
        if (_input.lGrab == false)
        {
            checkGrab = false;
            rb.useGravity = true;
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (_input.lRelease == true)
        {
            _input.lRelease = false;
        }
        
    }
    public void OnTriggerStay(Collider collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 10)
        {
            if (_input.lGrab == true)
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

            if (_input.lRelease == true)
            {
                closeHandIcon.SetActive(false);
                openhandIcon.SetActive(true);
                releasepos = handpos.position;
                Debug.Log(transform.position.y - monkeyBody.position.y);
                
                Vector3 force = (grabpos - releasepos) * 10;
                if (Mathf.Abs(force.x) >= 16)
                {
                    force.x = Mathf.Sign(force.x) * 16;

                }
                if (Mathf.Abs(force.y) >= 16)
                {
                    force.y = Mathf.Sign(force.y) * 16;

                }
                if (Mathf.Abs(force.z) >= 16)
                {
                    force.z = Mathf.Sign(force.z) * 16;

                }
                Debug.Log(force);
                rb.AddForce(force, ForceMode.Impulse);
                Debug.Log("release");
                _input.lRelease = false;
            }

        }

    }
    public void OnTriggerExit(Collider other)
    {
       // grabpos = Vector2.zero;
       // releasepos = Vector2.zero;
        closeHandIcon.SetActive(false);
        openhandIcon.SetActive(true);
        checkGrab = false;
        rb.useGravity = true;

    }
}