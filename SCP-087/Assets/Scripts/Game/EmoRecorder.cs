using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoodMe;
using System.IO;
using Player;

public class EmoRecorder : MonoBehaviour
{
    private int angerCount;
    private int disgustCount;
    private int scaredCount;
    private int surpirseCount;

    public void Start()
    {
        angerCount = 0;
        disgustCount = 0;
        scaredCount = 0;
        surpirseCount = 0;

    }

    public void Update()
    {
        if (EmotionsManager.Emotions.surprised > 0.4) surpirseCount++;
        if (EmotionsManager.Emotions.angry > 0.4) angerCount++;
        if (EmotionsManager.Emotions.disgust > 0.4) disgustCount++;
        if (EmotionsManager.Emotions.scared > 0.3) scaredCount++;
    }

    public void OnApplicationQuit()
    {
        GenerateRecordFile();
    }

    public void GenerateRecordFile()
    {
        string path = Application.dataPath + "/EmoRecords/record.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Emotion record \n\n");
        }
        string content =  PlayerPrefs.GetString(name) + " With Emotion AI: " + true + "; SurpriseCount:" + surpirseCount
            + "; Angry Count:" + angerCount + "; DisgustCount:" + disgustCount + "; ScaredCount:" + scaredCount + "; \n";
        File.AppendAllText(path, content);
    }
}
