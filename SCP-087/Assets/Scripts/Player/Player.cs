using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;


public class Player : MonoBehaviour
{

    public CharacterController controller;
    public GameObject jumpScare1;
    //EventObject
      //light
    public Light pointLight;
    public DigitalGlitch digitalGlitch;
    public AnalogGlitch analogGlitch;
      //sound
    public AudioSource footstepAudio;
    public AudioSource cryingAudio;
    public AudioSource pianoAudio;
    public AudioSource superised;
      //jump Scare



    //Movment
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
   
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector2 velocity;
    bool isGrouded;
   
  
    // Movement
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
        controller.Move(velocity * Time.deltaTime);

    }
}
