using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoodMe;
using UnityEngine.UI;
using System.Linq;
using static MoodMe.GetEmotionValue;

public class Triggers : MonoBehaviour
{
   
    public Player.Player player;
    public bool IsUsingEmo;
    public GameObject vileHug;

    private float startTime;
    private float takenTime;
    private bool IsEventisFinished;
    private int angryCount;
    private int disgustCount;
    private int scaredCount;
    private int neuturalCount;
    


    private IEnumerator[] eventsLevel1 = new IEnumerator[3];
    private IEnumerator[] eventsLevel2 = new IEnumerator[4];
    private IEnumerator[] eventsLevel3 = new IEnumerator[2];


    void Start()
    {
        //vileHug 
        vileHug.SetActive(false);
        startTime = 0;
        takenTime = 0;

      // Debug.Log(IsUsingEmo + "IsUsing Emo");
        angryCount = 0;
        disgustCount = 0;
        scaredCount = 0;
        neuturalCount = 0;

        IsEventisFinished = true;
        //IsUsingEmo = player.IsUsingEmo;
        IsUsingEmo = false;
        //IsUsingEmo = true;
        eventsLevel1[0] = Trigger2Glitch();
        eventsLevel1[1] = FootStep();
        eventsLevel1[2] = Crying();
 
        eventsLevel2[0] = JumpScare1();
        eventsLevel2[1] = Trigger1Glitch();
        eventsLevel2[2] = JumpScare2();
        eventsLevel2[3] = SuddenBGM();

        eventsLevel3[0] = ResetLightIntense();
        eventsLevel3[1] = ReduceEvent();

    }

    void Update()
    {
        takenTime = Time.deltaTime + startTime;
        if(takenTime >= Random.Range(15,20))
        {
            //VileHug actived
            vileHug.gameObject.SetActive(true);
        }



       // Debug.Log(IsUsingEmo + "IsUsing Emo");
        if (IsUsingEmo)
        {
           
            //For Surprise  NOt using this time
            if (EmotionsManager.Emotions.surprised > 0.4)
                {
                   // Debug.Log("Supirsed ");
                   // player.superised.PlayOneShot(player.superised.clip);
                }

           
           
            //Disgust
            if (TriggerConditionDetector(ref disgustCount, 10, 0.05f, EmotionsManager.Emotions.disgust) && IsEventisFinished)
            {
               
                Debug.Log("Disgust!!!!!!!!!!!!!!!!!!!!!!!!! ");
                //LEVEL 2
                int index = Random.Range(0, eventsLevel2.Length);
                StartCoroutine(eventsLevel2[index]);
               
            }
            //For Scared
            else if (TriggerConditionDetector(ref scaredCount, 30, 0.1f, EmotionsManager.Emotions.scared) && IsEventisFinished)
            {
                //LEVEL3
                Debug.Log("Scared!!!!!!!!!!!!!!!!!!!!!!!!! ");
                int index = Random.Range(0, eventsLevel3.Length);
                StartCoroutine(eventsLevel3[index]);
            } 
            //Angrey
            else if (TriggerConditionDetector(ref angryCount, 30, 0.1f, EmotionsManager.Emotions.angry) && IsEventisFinished)
            {

                Debug.Log("Angry!!!!!!!!!!!!!!!!!!!!!!!!! ");
                //LEVEL 13
                int index = Random.Range(0, 2);
                switch (index)
                {
                    case 0:
                        index = Random.Range(0, eventsLevel1.Length);
                        StartCoroutine(eventsLevel1[index]);
                        break;
                    case 1:
                        index = Random.Range(0, eventsLevel3.Length);
                        StartCoroutine(eventsLevel3[index]);
                        break;
                    default:
                        break;
                }
            }
            //For netural
            else if (TriggerConditionDetector(ref neuturalCount, 1000, 0.8f, EmotionsManager.Emotions.neutral) && IsEventisFinished)
            {
                Debug.Log("Neutural!!!!!!!!!!!!!!!!!!!!!!!!! ");
                //LEVEL 12
                int index = Random.Range(0, 2);
                switch (index)
                {
                    case 0:
                        index = Random.Range(0, eventsLevel1.Length);
                        StartCoroutine(eventsLevel1[index]);
                        break;
                    case 1:
                        index = Random.Range(0, eventsLevel2.Length);
                        StartCoroutine(eventsLevel2[index]);
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
    private bool TriggerConditionDetector(ref int count, int countThreshold, float threshold, float value)
    {
        if (value > threshold)
        {
            count++;
            if (count >= countThreshold)
            {
                count = 0;
                return true;
            }
        }
        else
        {
            count = 0;
        }
        
        
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsUsingEmo)
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
        
        


    }

    
    //LEVEL 1  --Screen satle Glitch  2s/3s
    IEnumerator Trigger2Glitch()
    {
        Debug.Log("LEVEL 1 Screen satle Glitch");
        IsEventisFinished = false;
        if (player.analogGlitch.colorDrift == 0 && player.analogGlitch.scanLineJitter ==0)
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
        IsEventisFinished = true;
    }
    //LEVEL 1 --FootStep
    IEnumerator FootStep()
    {
        Debug.Log("LEVEL 1 --FootStep");
        IsEventisFinished = false;
        player.footstepAudio.PlayOneShot(player.footstepAudio.clip);
        yield return new WaitForSeconds(4.2f);
        IsEventisFinished = true;
    }
    //LEVEL 1 --Crying
    IEnumerator Crying()
    {

        Debug.Log("LEVEL 1 --Cryring");
        IsEventisFinished = false;
        player.footstepAudio.PlayOneShot(player.cryingAudio.clip);
        yield return new WaitForSeconds(15f);
        IsEventisFinished = true;
    }
    //LEVEL 2  --Jump Scare
    IEnumerator JumpScare1()
    {
        Debug.Log(" //LEVEL 2  --Jump Scare");
        IsEventisFinished = false;
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

        IsEventisFinished = true;
    } 
    //LEVEL 2  --Screen Heave Glitch
    IEnumerator Trigger1Glitch()
    {
        Debug.Log("//LEVEL 2  --Screen Heave Glitch");
        IsEventisFinished = false;
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
        IsEventisFinished = true;

    }
    //LEVEL 2 --Jump Scare2
    IEnumerator JumpScare2()
    {
        Debug.Log("//LEVEL 2  --Jump Scare 2");
        IsEventisFinished = false;
        yield return new WaitForSeconds(10f);
        IsEventisFinished = true;
    }

    //LEVEL 2 --Sudden Voice 
    IEnumerator SuddenBGM()
    {
        Debug.Log("//LEVEL 2  --BGM");
        IsEventisFinished = false;
        player.superised.PlayOneShot(player.superised.clip);
        yield return new WaitForSeconds(33f);
        IsEventisFinished = true;
        
    }
    //LEVEL 3  --Enviroment Bright+   7s
    IEnumerator ResetLightIntense()
    {
        Debug.Log("//LEVEL 3  --Light");
        IsEventisFinished = false;
        player.pointLight.intensity = 5;
        yield return new WaitForSeconds(1f);
        player.pointLight.intensity = 8;
        yield return new WaitForSeconds(4f);
        player.pointLight.intensity = 10;
        yield return new WaitForSeconds(2f);
        player.pointLight.intensity = 3;
        IsEventisFinished = true;
    }
    //LEVEL 3 --REDUCE frequency of Events
    IEnumerator ReduceEvent()
    {
        Debug.Log("//LEVEL 2  --NO Events");
        IsEventisFinished = false;
        yield return new WaitForSeconds(10f);
        IsEventisFinished = true;
    }

    



  

   



    // Light Effect - Vision blurry, lose vision for short time
    // Jump Scare - Monster Chasing, Horror face
    // Creepy effect  - Sound effect(foot steps, crying sound, piano sounds)
    // Discovery scary.  Crop laying in the corner, blood stain  
}
