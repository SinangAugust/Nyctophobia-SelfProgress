using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class suddenGhost : MonoBehaviour
{
    public GameObject trigger;
    public GameObject ghostObj;
    public NavMeshAgent ghost;
    public Transform thePlayer;
    public AudioClip triggerSound;
    public float Volume;
    AudioSource audioSource;
    private bool isPlayed = false;
    private bool isTriggered = false;
    private bool isReady = false;

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

        if (!isTriggered)
        {
            float distance = (thePlayer.transform.position - trigger.transform.position).magnitude;

            if (distance <= 1 && distance >= -1)
            {
                // --This will activate the sudden ghost pop-up
                ghostObj.SetActive(true);
                isReady = true;

                if (isReady == true)
                {
                    // --This is to set the sudden ghost to run into the player
                    ghost.SetDestination(thePlayer.position);
                }
            }

            isTriggered = true;
        }
        StartCoroutine(ghostTrigger());
    }

    IEnumerator ghostTrigger()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(ghostObj);
    }
}
