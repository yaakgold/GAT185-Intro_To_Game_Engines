using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offset;
    [Range(1, 20)] public float rate;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = targetTransform.position + (targetTransform.rotation * offset);

        Ray ray = new Ray(targetTransform.position, (targetPos - targetTransform.position));
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPos = hit.point;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * rate);

        Vector3 dir = targetTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
