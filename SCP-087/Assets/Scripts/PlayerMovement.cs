using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrouded;
   

    // Update is called once per frame
    void Update()
    {
        float  sped = speed;
        isGrouded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrouded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        //left - right
        float x = Input.GetAxis("Horizontal");
        //forward - back
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
       //Jump
        if (Input.GetButton("Jump") && isGrouded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
        }
        //Sprint
        if(Input.GetButton("Fire3")&& isGrouded)
        {
            sped *= 2;
        }
        controller.Move(move * sped * Time.deltaTime);
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity);

    }
}
