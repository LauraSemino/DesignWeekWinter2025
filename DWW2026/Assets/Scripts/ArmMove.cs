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

        lHandRot.y = 22.5f;
        lHandRot.z = 72.5f;
        rHandRot.y = 157f;
       
        rHandRot.z = 75f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.lArm.y != 0)
        {
            lHandRot.y = 22.5f + (40f * _input.lArm.y);
        }

        if(_input.lArm.x != 0)
        {
            lHandRot.z = 80f + (40f * _input.lArm.x); 
        }

        if (_input.rArm.y != 0)
        {
            rHandRot.y = 22.5f + (40f * _input.rArm.y);
        }

        if (_input.rArm.x != 0)
        {
            rHandRot.z = - + (40f * _input.rArm.x);
        }


        leftHand.transform.localEulerAngles = lHandRot;
        rightHand.transform.localEulerAngles = rHandRot;
    }
}
