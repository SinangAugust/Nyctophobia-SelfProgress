using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject FlashImg;
    public GameObject Trigger;
    bool isTriggered = false;

    void OnTriggerEnter()
    {
        if (isTriggered == false)
        {
            StartCoroutine(EndJump());
            isTriggered = true;
        }
        else
        {
            Trigger.SetActive(false);
        }
    }

    IEnumerator EndJump()
    {
        // --This is the trigger for the close-up jumpscare
        yield return new WaitForSeconds(1);
        Scream.Play();
        ThePlayer.SetActive(false);
        JumpCam.SetActive(true);
        FlashImg.SetActive(true);
        yield return new WaitForSeconds(2.03f);
        ThePlayer.SetActive(true);
        JumpCam.SetActive(false);
        FlashImg.SetActive(false);
    }
}
