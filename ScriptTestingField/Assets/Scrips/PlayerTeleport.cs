using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject playerBody;
    public GameObject blocker;
    public GameObject platform;
    public bool IsGoingDown = true;

    // Update is called once per frame
    private void Start()
    {
        if (blocker != null)
            blocker.SetActive(true);
        if (platform != null)
            platform.SetActive(true);
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (IsGoingDown)
        {
            playerBody.transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 20, playerBody.transform.position.z);
        }
        else
        {
            playerBody.transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y - 20, playerBody.transform.position.z);
            if (blocker !=null && blocker.activeSelf) blocker.SetActive(false);
            if (platform != null && platform.activeSelf) platform.SetActive(false);

        }
    }
}
