using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    public static bool isPaused;
    public static GameObject pauseLabel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //SceneManager.LoadScene(0);
            TogglePause();
        }
    }

   
    public static void TogglePause()
    {
        if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            isPaused = true;
            if(pauseLabel)pauseLabel.SetActive(true); 
        }   
        else if(Time.timeScale == 0)
        {

            Time.timeScale = 1;
            AudioListener.pause = false;
            isPaused = false;
            if(pauseLabel)pauseLabel.SetActive(true);
        }
    }
}
