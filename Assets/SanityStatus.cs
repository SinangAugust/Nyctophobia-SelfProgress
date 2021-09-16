using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityStatus : MonoBehaviour
{
    public SanityBar sanityBar;
    public GlitchEffect glitchEffect;
    public Transform lightSource;
    public Transform thePlayer;
    public AudioSource audioBreathing;
    public AudioSource audioSpooky;

    public float maxSanity = 100;
    public float minSanity = 0;
    public float currentSanity;

    public float sanityRegenRate = 0.3f;
    public float sanityLossRate = 0.4f;

    float conditionOne = 70;
    float conditionTwo = 50;
    float conditionThree = 30;
    float conditionFour = 10;

    bool noLight = false;
    bool sanityLoss = false;

    void Start()
    {
        sanityBar.SetMaxSanity(maxSanity);
        currentSanity = maxSanity;
    }

    void Update()
    {
        sanityBar.UpdateSanity(currentSanity);

        SanityConditions();
        SanityRegen();

        // --This is to set the default of the sanity value
        if (currentSanity >= maxSanity)
        {
            currentSanity = maxSanity;
        }
        else if (currentSanity <= minSanity)
        {
            currentSanity = minSanity;
        }
    }

    void SanityRegen()
    {
        // --This is the condition to regenerate the sanity
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
        // --This is the condition to have sanity loss
        if (noLight == true && sanityLoss == true)
        {
            currentSanity -= sanityLossRate * Time.deltaTime;
        }
        else if (noLight == true && sanityLoss == false)
        {
            currentSanity = currentSanity;
        }
    }

    void SanityConditions()
    {
        // --This is the aftereffects of every value of the current sanity the player has
        if (conditionOne < currentSanity)
        {
            audioBreathing.Play();
        }
        if (conditionTwo < currentSanity)
        {
            audioSpooky.Play();
        }   
        if (conditionThree < currentSanity)
        {
            // --Players will have their screens glitch which will make it harder for them to see.
            // --Just add the already made glitch camera script.
        }
        if (conditionFour < currentSanity)
        {
            // --Player will start seeing random ghost in their vision.
            // --Player will have AI attracted to them (I can't do this part because I do not have AI related tasks)
        }
    }
}
