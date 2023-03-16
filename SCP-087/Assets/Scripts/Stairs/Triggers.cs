using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        int tiggerType = random.Next(3);

        switch (tiggerType)
        {
            case 0:
                // StartCoroutine("Trigger1Glitch");
                player.digitalGlitch.intensity = Mathf.Lerp(0, 0.5f, Time.time * 5);
                player.digitalGlitch.intensity = Mathf.Lerp(0.5f, 0f, Time.time * 5);
               // player.digitalGlitch.intensity = 0f;
                break;
            case 1:
                //StartCoroutine("Trigger2Glitch");
                player.analogGlitch.colorDrift = 0f;
                player.analogGlitch.scanLineJitter = 0f;
                break;
            case 2:

                Debug.Log("trigger3 ");
                player.cryingAudio.PlayOneShot(player.cryingAudio.clip);
                break;
            case 3:

                Debug.Log("trigger4 ");
                player.pianoAudio.PlayOneShot(player.pianoAudio.clip);
                break;
            default:
                break;
        }


    }

    IEnumerator Trigger1Glitch()
    {
        while (true)
        {
            Debug.Log("trigger1 ");
            player.digitalGlitch.intensity = 0.2f;
            yield return new WaitForSeconds(3f);
           
        }

    }

    IEnumerator Trigger2Glitch()
    {
        while (true)
        {
            Debug.Log("trigger2 ");
            player.analogGlitch.colorDrift = 0.1f;
            player.analogGlitch.scanLineJitter = 0.3f;
            yield return new WaitForSeconds(3f);
            
            
        }
    }

   


    // Light Effect - Vision blurry, lose vision for short time
    // Jump Scare - Monster Chasing, Horror face
    // Creepy effect  - Sound effect(foot steps, crying sound, piano sounds)
    // Discovery scary.  Crop laying in the corner, blood stain  
}
