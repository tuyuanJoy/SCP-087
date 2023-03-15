using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject playerBody;
    //public bool IsGoingDown;

    private float beforeColliderHeight;
    private float afterColliderHeight;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("x: "+ playerBody.transform.position.x + " y: " + playerBody.transform.position.y);
    }

    private void OnTriggerEnter(Collider Other)
    {
        beforeColliderHeight = playerBody.transform.position.y;
        Debug.Log("Collided");
        afterColliderHeight = playerBody.transform.position.y;
        if (beforeColliderHeight > afterColliderHeight)
        { 
            playerBody.transform.position += new Vector3(0,9,0);
            Debug.Log("Going Down");
        }
        else if (beforeColliderHeight > afterColliderHeight)
        {
            playerBody.transform.position += new Vector3(0, -9, 0);
            Debug.Log("Going Up");
        }else
        {
            Debug.Log("Not moving up or down");
        }

    }
}
