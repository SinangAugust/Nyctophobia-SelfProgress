using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class depthOfFieldController : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;

    public Volume volume;

    [Range(1, 10)]
    public float focusSpeed;

    private DepthOfField depthOfField;

    private void Start()
    {
        volume.profile.TryGet(out depthOfField);
    }

    public void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 10f);

        isHit = false;

        if (Physics.Raycast(raycast, out hit, 10f))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }

        else
        {
            if (hitDistance < 10f)
            {
                hitDistance++;
            }
        }

        SetFocus();
    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.1f);

            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}
