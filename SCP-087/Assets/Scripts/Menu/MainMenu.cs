using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public TMP_Text playerName;
    public Toggle agreement;
    public void PlayGame()
    {
        if(playerName!= null && !string.IsNullOrEmpty(playerName.text)  && agreement.isOn)
        {
            string path = Application.dataPath + "/EmoRecords/record.txt";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Emotion record \n\n");
            }
            File.AppendAllText(path, playerName.text);


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("My Name is" + PlayerPrefs.GetString(name));
        }else if(string.IsNullOrEmpty(playerName.text))
        {
            Debug.Log("Input your nickname");
        }else if (!agreement.isOn)
        {
            Debug.Log("Please agree to our term");
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
