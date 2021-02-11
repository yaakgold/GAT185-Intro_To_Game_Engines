using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offset;
    [Range(1, 20)] public float rate;

    Vector2 inputRotation = Vector2.zero;
    float pitch = 30, yaw, distance = 3;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion rotBase = targetTransform.rotation;
        Quaternion rotation = rotBase * Quaternion.AngleAxis(yaw, Vector3.up) 
                                      * Quaternion.AngleAxis(pitch, Vector3.right);

        Vector3 targetPos = targetTransform.position + (rotation * (Vector3.back * distance));
        //Vector3 targetPos = targetTransform.position + (targetTransform.rotation * offset);

        Ray ray = new Ray(targetTransform.position, (targetPos - targetTransform.position));
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPos = hit.point;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * rate);

        Vector3 dir = targetTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void OnPitch(InputAction.CallbackContext ctx)
    {
        pitch += ctx.ReadValue<float>();
        pitch = Mathf.Clamp(pitch, -20, 70);
    }

    public void OnYaw(InputAction.CallbackContext ctx)
    {
        yaw += ctx.ReadValue<float>();
        yaw = Mathf.Clamp(yaw, -70, 70);
    }

    public void OnDistance(InputAction.CallbackContext ctx)
    {
        distance += ctx.ReadValue<float>();
        distance = Mathf.Clamp(distance, 3, 12);
    }

    public void OnCenter(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            yaw = 0;
        }
    }
}
