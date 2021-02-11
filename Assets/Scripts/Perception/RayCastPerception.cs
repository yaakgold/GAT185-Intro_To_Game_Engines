using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPerception : Perception
{
    public Transform rayCastTransform;
    [Range(1, 40)] public float distance;
    [Range(0, 90)] public float angle;
    public int numRays = 1;

    public override GameObject[] GetGameObjects()
    {
        List<GameObject> gameObjects = new List<GameObject>();

        float angleOff = (angle * 2) / (numRays - 1);
        for (int i = 0; i < numRays; i++)
        {
            float rayDist = distance;

            Quaternion rot = Quaternion.AngleAxis(-angle + (angleOff * i), Vector3.up);
            Vector3 forward = rot * rayCastTransform.forward;

            Ray ray = new Ray(rayCastTransform.position, forward);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDist))
            {
                rayDist = hit.distance;
                gameObjects.Add(hit.collider.gameObject);
            }
            Debug.DrawRay(ray.origin, ray.direction * rayDist);

        }
        return gameObjects.ToArray();
    }
}
