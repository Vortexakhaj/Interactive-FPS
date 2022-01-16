using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkeyboardmovement : MonoBehaviour
{
    [SerializeField] private string horizInput;
    [SerializeField] private string vertInput;
    [SerializeField] private string updown;
    [SerializeField] private float movespeed;
    
    private Vector3 temp;
    public CharacterController charcontrol;

    private void Start()
    {
        charcontrol = GetComponent<CharacterController>();        
    }

    private void Update()
    {
        PlayerWASD();
        if (Input.GetKey(KeyCode.R))
        {
            temp = transform.position;
            temp.x = 0f;
            temp.y = 1f;
            temp.z = 0f;
            transform.position = temp;
        }
    }
    private void PlayerWASD()
    {
        float horiz = Input.GetAxis(horizInput) * movespeed * Time.deltaTime ;
        float vert = Input.GetAxis(vertInput) * movespeed * Time.deltaTime ;
        float updo = Input.GetAxis(updown) * movespeed * Time.deltaTime ;

        charcontrol.Move(transform.TransformDirection(new Vector3(horiz, updo, vert)));
        

    }

    
}
