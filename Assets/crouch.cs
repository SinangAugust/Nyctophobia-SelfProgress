using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    private bool m_Peek = false;
    private Transform m_Camera;

    public KeyCode peekKey = KeyCode.V;

    void Start()
    {
        m_Camera = this.gameObject.transform.GetChild(0);
        Debug.Log(m_Camera.localPosition);
    }

    void Update()
    {
        // --Basically use letter V to crouch
        if (Input.GetKey(peekKey))
        {
            m_Peek = true;
        }
        else
        {
            m_Peek = false;
        }
        CheckPeek();
    }

    void CheckPeek()
    {
        if (m_Peek == true)
        {
            m_Camera.localPosition = new Vector3(0, -0.2f, 0);
        }
        else
        {
            m_Camera.localPosition = new Vector3(0, 0.8f, 0);
        }
    }
}
