using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoodMe;
using UnityEngine.UI;

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
        if (EmotionsManager.Emotions.surprised > 0.4)
        {
            Debug.Log("Supirsed ");
            player.superised.PlayOneShot(player.superised.clip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.pointLight.intensity = 20;
        System.Random random = new System.Random();
        int tiggerType = random.Next(5);

        //
        switch (tiggerType)
        {
            case 0:
                
                Debug.Log("trigger1 ");
                StartCoroutine(Trigger1Glitch());
                break;
            case 1:
                Debug.Log("trigger2 ");
                StartCoroutine(Trigger2Glitch());
                break;
            case 2:
                Debug.Log("trigger3 ");
                player.cryingAudio.PlayOneShot(player.cryingAudio.clip);
                StartCoroutine(ResetLightIntense());
                break;
            case 3:

                Debug.Log("trigger4 ");
                player.footstepAudio.PlayOneShot(player.footstepAudio.clip);
                StartCoroutine(ResetLightIntense());
                break;
            case 4:
                //Jump scare
                StartCoroutine(JumpScare1());
                break;
            default:
                break;
        }
        


    }

    IEnumerator Trigger1Glitch()
    {
        if (player.digitalGlitch.intensity == 0)
        {
            player.digitalGlitch.intensity = 0.6f;
            yield return new WaitForSeconds(4f);

            player.digitalGlitch.intensity = 0.2f;
            yield return new WaitForSeconds(2f);
            player.digitalGlitch.intensity = 0;
            //Mathf.Lerp(0.5f, 0f, Time.time * 5);
            //player.digitalGlitch.intensity = 0f;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            player.pointLight.intensity = 0;
        } 

    }

    IEnumerator Trigger2Glitch()
    {
        if(player.analogGlitch.colorDrift == 0 && player.analogGlitch.scanLineJitter ==0)
        {
            player.analogGlitch.colorDrift = 0.6f;
            player.analogGlitch.scanLineJitter = 0.6f;
            yield return new WaitForSeconds(3f);
            player.analogGlitch.colorDrift = 0f;
            player.analogGlitch.scanLineJitter = 0f;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            player.pointLight.intensity = 0;
        }
    }
    IEnumerator ResetLightIntense()
    {
        yield return new WaitForSeconds(2f);
        player.pointLight.intensity = 0;

    }

    IEnumerator JumpScare1()
    {
        if (player.jumpScare1 != null)
        {
            player.jumpScare1.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        player.jumpScare1.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        player.jumpScare1.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.5f); 
        player.jumpScare1.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        player.jumpScare1.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        player.jumpScare1.SetActive(false);
    }





    // Light Effect - Vision blurry, lose vision for short time
    // Jump Scare - Monster Chasing, Horror face
    // Creepy effect  - Sound effect(foot steps, crying sound, piano sounds)
    // Discovery scary.  Crop laying in the corner, blood stain  
}
