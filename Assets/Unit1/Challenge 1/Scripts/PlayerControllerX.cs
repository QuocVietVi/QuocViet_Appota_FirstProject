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

    private Rigidbody rb;
    private float time;
    public float duration = 0.2f;
    private Quaternion rotationOnKeyUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0;
        rotationOnKeyUp = Quaternion.identity;
    }

    private void Update()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(verticalInput) > 0 && time == 0)
        {
            rotationOnKeyUp = transform.rotation;
        }

        time += Time.deltaTime;
        time *= verticalInput == 0 ? 1 : 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input

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
        Quaternion rot = Quaternion.Lerp(rotationOnKeyUp, Quaternion.identity, time / duration);
        rb.MoveRotation(rot);
    }

}
