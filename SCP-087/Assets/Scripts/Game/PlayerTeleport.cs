using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject Player;
    public bool IsGoingDown = true;


    private void Start()
    {

       // if(IsGoingDown )playerBody.transform.position += new Vector3(0,0,10);
    }
    void Update()
    {
        //Debug.Log("x: "+ playerBody.transform.position.x + " y: " + playerBody.transform.position.y);
    }

    private void OnTriggerEnter(Collider Other)
    {

       // Debug.Log("Collided");
        if (IsGoingDown)
        {
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position += new Vector3(0, 9, 0);
            Player.GetComponent<CharacterController>().enabled = true;
            // Debug.Log("Going Down");
        }
        else 
        {
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position += new Vector3(0, -9, 0);
            Player.GetComponent<CharacterController>().enabled = true;
            //  Debug.Log("Going Up");
        }

    }
}
