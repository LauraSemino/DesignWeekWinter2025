using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;

public class ArmMove : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject leftHand; 
    public GameObject rightHand;

    Vector3 lHandRot;
    Vector3 rHandRot; 
    private StarterAssetsInputs _input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        lHandRot = leftHand.transform.localEulerAngles;
        rHandRot = rightHand.transform.localEulerAngles; 
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.lArm.y != 0)
        {
            lHandRot.z += rotationSpeed * Time.deltaTime * _input.lArm.y;
        }

        if(_input.lArm.x != 0)
        {
            lHandRot.x += rotationSpeed * Time.deltaTime * _input.lArm.x; 
        }

        if (_input.rArm.y != 0)
        {
            rHandRot.z += rotationSpeed * Time.deltaTime * _input.rArm.y;
        }

        if (_input.rArm.x != 0)
        {
            rHandRot.x += rotationSpeed * Time.deltaTime * _input.rArm.x;
        }



        lHandRot.x = Mathf.Clamp(lHandRot.x, 45, 90);
        lHandRot.z = Mathf.Clamp(lHandRot.z, 0, 45);

        rHandRot.x = Mathf.Clamp(rHandRot.x, 45, 90);
        rHandRot.z = Mathf.Clamp(rHandRot.z, 0, 45);

        leftHand.transform.localEulerAngles = lHandRot;
        rightHand.transform.localEulerAngles= rHandRot;
    }
}
