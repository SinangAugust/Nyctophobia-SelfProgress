using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{
    public AudioClip triggerSound;
    public float Volume;
    AudioSource audioSource;
    private bool isPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        if (!isPlayed)
        {
            audioSource.PlayOneShot(triggerSound, Volume);
            isPlayed = true;
        }
    }
}