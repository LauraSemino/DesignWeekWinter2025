using UnityEngine;

public class cameraTurn : MonoBehaviour
{

    public GameObject camera;
    Vector3 cameraRotate;
    public float cameraSlow = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        cameraRotate.y += Time.deltaTime / cameraSlow;

        camera.transform.localEulerAngles = cameraRotate;
        

        
    }
}
