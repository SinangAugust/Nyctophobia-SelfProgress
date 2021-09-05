using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Vector3 startingPosition;
    public Quaternion startingRotation;

    public Material defaultMaterial;
    public Material highlightMaterial;

    private void Awake()
    {
        defaultMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
    }

    public void OnHoverOver()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = highlightMaterial;
    }

    public void OnHoverExit()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
    }

    public void Select(Vector3 focusPosition, Vector3 target)
    {
        startingPosition = transform.position;
        transform.position = focusPosition;
        transform.LookAt(target);
    }

    public void Deselect()
    {
        transform.position = startingPosition;
    }
}
