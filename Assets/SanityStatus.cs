using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityStatus : MonoBehaviour
{
    public SanityBar sanityBar;
    public Transform lightSource;
    public Transform thePlayer;
    public AudioSource audioBreathing;
    public AudioSource audioSpooky;
    public AudioClip test;

    public float maxSanity = 100;
    public float minSanity = 0;
    public float currentSanity;

    public float sanityRegenRate = 0.6f;
    public float sanityLossRate = 0.4f;

    bool noLight = false;
    bool sanityLoss = false;
    bool isBreathing = false;

    void Start()
    {
        sanityBar.SetMaxSanity(maxSanity);
        currentSanity = maxSanity;
    }

    void Update()
    {
        sanityBar.UpdateSanity(currentSanity);

        if (currentSanity >= maxSanity)
        {
            currentSanity = maxSanity;
        }
        else if (currentSanity <= minSanity)
        {
            currentSanity = minSanity;
        }

        SanityConditions();
        SanityRegen();

        Debug.Log(currentSanity);
    }

    void SanityConditions()
    {
        if (currentSanity <= 70)
        {
            isBreathing = true;
            StartCoroutine(BreathingSound());
        }
        else if (currentSanity <= 50)
        {
            /*The player will start hearing random spooky sounds*/
        }
        else if (currentSanity <= 30)
        {
            /*Player vision will start to get fuzzy*/
        }
        else if ( currentSanity <= 10)
        {
            /*The player will start seeing random entities at a random time*/
        }
    }

    void SanityRegen()
    {
        float distance = (thePlayer.transform.position - lightSource.transform.position).magnitude;

        if (distance <= 6)
        {
            noLight = false;
            currentSanity += sanityRegenRate * Time.deltaTime;
        }
        else if (distance < 15 && distance > 6)
        {
            currentSanity = currentSanity;
        }
        else if (distance > 15)
        {
            noLight = true;

            if (noLight == true)
            {
                sanityLoss = true;
            }

            SanityConsume();
        }
    }

    void SanityConsume()
    {
        if (noLight == true && sanityLoss == true)
        {
            currentSanity -= sanityLossRate * Time.deltaTime;
        }
        else if (noLight == true && sanityLoss == false)
        {
            currentSanity = currentSanity;
        }
    }

    IEnumerator BreathingSound()
    {
        yield return new WaitForSeconds(Random.Range(10f, 20f));
        audioBreathing.Play();
    }
}
