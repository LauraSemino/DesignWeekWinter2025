using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;

public class ArmMoveNew : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject leftHand; 
    public GameObject rightHand;

    Vector3 rotBaseR;
    Vector3 rotBaseL;

    Vector3 lHandRot;
    Vector3 rHandRot;

    float rangeMotion = 90;

    private StarterAssetsInputs _input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();

        rotBaseL = leftHand.transform.localEulerAngles;
        rotBaseR = rightHand.transform.localEulerAngles;
        lHandRot = leftHand.transform.localEulerAngles;
        rHandRot = rightHand.transform.localEulerAngles;



    }

    // Update is called once per frame
    void Update()
    {
        if (_input.lArm.y != 0)
        {
            lHandRot.y = rotBaseL.y + (rangeMotion * _input.lArm.x);
        }

        if(_input.lArm.x != 0)
        {
            lHandRot.x = rotBaseL.x + (rangeMotion * -_input.lArm.y); 
        }

        if (_input.rArm.y != 0)
        {
            rHandRot.y = rotBaseR.y + (rangeMotion * -_input.rArm.x);
        }

        if (_input.rArm.x != 0)
        {
            rHandRot.x = rotBaseR.x + (rangeMotion * -_input.rArm.y);
        }


        leftHand.transform.localEulerAngles = lHandRot;
        rightHand.transform.localEulerAngles = rHandRot;
    }
}
