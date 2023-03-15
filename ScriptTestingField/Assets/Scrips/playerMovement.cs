using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController Controller;
    public Animator MovementAnimator;
    public float speed = 6f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector2 velocity;
    bool isGrouded;
    bool isWalking;
    bool isRunning;
    // Update is called once per frame
    void Update()
    {
        float sped = speed;
        isGrouded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrouded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(x!=0 || z!=0) MovementAnimator.SetBool("IsWalking", true);
        else MovementAnimator.SetBool("IsWalking", false);
        Vector3 move = transform.right * x + transform.forward * z;
        //Jump
        if (Input.GetButton("Jump") && isGrouded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            MovementAnimator.SetBool("IsJumping", true);
        }
        else
        {
            MovementAnimator.SetBool("IsJumping", false);
        }
        //Sprint
        if (Input.GetButton("Fire3") && isGrouded)
        {
            MovementAnimator.SetBool("IsRunning", true);
            sped *= 2;
        }
        else
        {
            MovementAnimator.SetBool("IsRunning", false);
        }

        Controller.Move(move * sped * Time.deltaTime);
        //gravity
        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }
}
