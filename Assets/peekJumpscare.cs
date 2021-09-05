using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peekJumpscare : MonoBehaviour
{
    public Transform player;
    public Transform bed;
    KeyCode peekBed = KeyCode.V;

    void Update()
    {
        float distance = (player.transform.position - bed.transform.position).magnitude;

        if (distance < 5 && Input.GetKey(peekBed))
        {
            Debug.Log("JUMPSCARE!");
        }
    }
}
