using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermousemovement : MonoBehaviour
{

    [SerializeField] private string mouseXInput, mouseYInput;
    [SerializeField] private float mousesensitivity = 100.0f;
    [SerializeField] private Transform Playerbody;
    private float Xclamp;

    private void Initialized()
    {
        Xclamp = 0.0f;
    }
    
    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float XInput = Input.GetAxis(mouseXInput) * mousesensitivity * Time.deltaTime;
        float YInput = Input.GetAxis(mouseYInput) * mousesensitivity * Time.deltaTime;

        Xclamp += YInput;

        if(Xclamp > 90.0f)
        {
            Xclamp = 90.0f;
            YInput = 0.0f;
            Xclamprotationtovalue(270.0f);
        }
        else if (Xclamp < -90.0f)
        {
            Xclamp = -90.0f;
            YInput = 0.0f;
            Xclamprotationtovalue(90.0f);
        }

        transform.Rotate(Vector3.left * YInput);
        Playerbody.Rotate(Vector3.up * XInput);


    }

    private void Xclamprotationtovalue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
