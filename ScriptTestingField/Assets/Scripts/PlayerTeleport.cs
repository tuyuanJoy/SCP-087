using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject playerBody;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("x: "+ playerBody.transform.position.x + " y: " + playerBody.transform.position.y);
    }

    private void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Collided");
        playerBody.transform.position = teleportTarget.transform.position;
    }
}
