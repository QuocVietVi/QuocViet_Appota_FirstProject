using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public Transform propeller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        propeller.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (Mathf.Abs(verticalInput) > 0.1f)
        {
            transform.Rotate(Vector3.left, rotationSpeed * verticalInput * Time.deltaTime);
        }
        else
        {
            AutoBalance();
        }


        
    }

    void AutoBalance()
    {
        if (transform.rotation.x < 0)
        {
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
        }
        if (transform.rotation.x > 0)
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

}
