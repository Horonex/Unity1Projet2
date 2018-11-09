using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float turnSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;


    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody body;
    [SerializeField] private Transform cam;
    Enemie en;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        //cam = GetComponent<Camera>();
        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        
        Move(); 
        Turn();
        
    }

    private void Turn()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*turnSpeed, 0));
        cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * turnSpeed, 0, 0));
    }

    private void Move()
    {
        float curSpeed = speed;
        
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Fire3") != 0)
            {
                curSpeed *= 2;
            }
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * curSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y  - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * curSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Goal")
        {
            Debug.Log("win");
        }
        if (col.transform.tag == "Enemie")
        {
            if(col.GetComponent<Enemie>().isDeadly)
            {
                Debug.Log("Dead");
                GameManager.Reset();
            }
            
        }
    }

    //void Update()
    //{
    //    body.AddForce(new Vector3(Input.GetAxis("Horizontal")*speed, 0.0f, Input.GetAxis("Vertical")*speed));


    //    if (controller.isGrounded)
    //    {
    //        // We are grounded, so recalculate
    //        // move direction directly from axes

    //        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    //        //moveDirection = transform.TransformDirection(moveDirection);
    //        //moveDirection = moveDirection * speed;

    //        //if (Input.GetButton("Jump"))
    //        //{
    //        //    moveDirection.y = jumpSpeed;
    //        //}

    //        if(Input.GetButton("Jump"))
    //        {
    //            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0));
    //        }

    //    }

    //    // Apply gravity
    //    //moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

    //    // Move the controller
    //    //controller.Move(moveDirection * Time.deltaTime);
    //}
}
