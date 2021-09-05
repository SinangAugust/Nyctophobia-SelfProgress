using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerStatus playerStats;
    public float speed = 8f;
    public float accelaration = 1.1f;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        isRunning();

        Vector3 move = transform.right * moveX + transform.forward * moveZ + transform.up * -9.81f;

        controller.Move(move * speed * Time.deltaTime);
    }

    void isRunning()
    {
        if (speed >= 12f)
        {
            speed = 12f;
        }

        if (Input.GetButton("Run") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            if (playerStats.currentStamina > 0)
            {
                speed *= accelaration;
                playerStats.currentStamina -= 20 * Time.deltaTime;
            }
            else
                speed = 12f;

        }

        if (Input.GetButtonUp("Run"))
        {
            speed = 12f;
            playerStats.regenStamina();
        }
    }
}
