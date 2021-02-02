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
        Vector3 targetPos = targetTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * rate);

        Vector3 dir = targetTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}