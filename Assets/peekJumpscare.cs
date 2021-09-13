using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peekJumpscare : MonoBehaviour
{
    public Transform player;
    public Transform bed;

    public AudioSource scream;
    public GameObject FlashImg;

    bool isTriggered = false;

    KeyCode peekBed = KeyCode.V;

    void Update()
    {
        float distance = (player.transform.position - bed.transform.position).magnitude;

        if (distance < 5 && Input.GetKey(peekBed))
        {
            isTriggered = true;
        }

        if (isTriggered == true) PeekJumpscareStart();
    }

    void PeekJumpscareStart(){
        // StartCoroutine(JumpWaitOne());
        scream.Play();
        FlashImg.SetActive(true);
        // StopCoroutine(JumpWaitOne());
        // StartCoroutine(JumpWaitTwo());
        PeekJumpscareFinish();
    }

    void PeekJumpscareFinish(){
        FlashImg.SetActive(false);
        // StopCoroutine(JumpWaitTwo());
    }

    IEnumerator JumpWaitTwo(){
        yield return new WaitForSeconds(2f);
        PeekJumpscareFinish();
    }

    IEnumerator JumpWaitOne(){
        yield return new WaitForSeconds(2f);
    }
}
