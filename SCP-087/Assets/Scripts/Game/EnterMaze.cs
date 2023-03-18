using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMaze : MonoBehaviour
{

    public GameObject EntranceWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Entered the Maze");
        if (!EntranceWall.activeSelf && EntranceWall != null)
            EntranceWall.SetActive(true);
    }
}
