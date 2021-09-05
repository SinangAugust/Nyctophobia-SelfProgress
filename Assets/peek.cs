using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class peek : MonoBehaviour
{
    public KeyCode peekBed = KeyCode.V;

    [SerializeField] private float m_Amount = 40f;

    private FirstPersonController m_FPSController;
    private Transform m_CameraTransform;
    private Vector3 m_InitPos;
    private Quaternion m_InitRot;

    private bool m_IsPeeking = false;

    void Start()
    {
        m_FPSController = GetComponent<FirstPersonController>();
        m_CameraTransform = m_FPSController.transform.GetChild(0);

        m_InitPos = m_CameraTransform.localPosition;
        m_InitRot = m_CameraTransform.localRotation;
    }

    void Update()
    {
        if (Input.GetKey(peekBed))
        {
            m_IsPeeking = true;
        }
        else
        {
            m_IsPeeking = false;
        }

        CheckLeaning();
    }

    void CheckLeaning()
    {
        if (m_IsPeeking)
        {
            m_FPSController.SetRotateZ(m_Amount);
        }
        else
        {
            m_FPSController.SetRotateZ(m_InitRot.eulerAngles.z);
        }
    }
}
