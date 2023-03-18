using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject Env;
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
             Env.transform.position +=new Vector3(0,-9,0);
            // Debug.Log("Going Down");
        }
        else 
        {
            Env.transform.position += new Vector3(0,9,0);
          //  Debug.Log("Going Up");
        }

    }
}
