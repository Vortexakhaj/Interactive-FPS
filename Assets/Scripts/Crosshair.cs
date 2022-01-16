using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Animator animm;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animm = GetComponent<Animator>();
    }

    void Update()
    {
        quit();
        this.transform.position = Input.mousePosition;
        animm.enabled = true;
        if (Input.GetButtonDown("Fire1"))
        {
            animm.SetTrigger("shoot");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //animm.enabled = false;
        }
    }

    void quit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
