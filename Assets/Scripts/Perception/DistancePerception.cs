using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerception : Perception
{
    public float distance = 10.0f;
    public float angle = 10.0f;
    public string tagName = "";

    public override GameObject[] GetGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagName);

        gameObjects = GetGameObjectsInDistance(gameObjects, distance);
        gameObjects = GetGameObjectsInAngle(gameObjects, angle);
        gameObjects = SortGameObjectsByDist(gameObjects);

        return gameObjects;
    }

    public GameObject[] GetGameObjectsInDistance(GameObject[] gameObjects, float maxDistance)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject go in gameObjects)
        {
            if (go == gameObject)
                continue;

            float dist = Vector3.Distance(transform.position, go.transform.position);

            if (dist <= maxDistance)
            {
                result.Add(go);
            }
        }

        return result.ToArray();
    }

    public GameObject[] GetGameObjectsInAngle(GameObject[] gameObjects, float maxAngle)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject go in gameObjects)
        {
            if (go == gameObject)
                continue;

            Vector3 direction = (go.transform.position - transform.position).normalized;
            float dot = Utilities.Dot(transform.forward, direction);
            dot = Mathf.Clamp(dot, -1, 1);
            float a = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (a <= maxAngle)
            {
                result.Add(go);
            }
        }

        return result.ToArray();
    }

    public GameObject[] SortGameObjectsByDist(GameObject[] gameObjects)
    {
        List<GameObject> result = new List<GameObject>(gameObjects);

        result.Sort(SortByDistance);

        return result.ToArray();
    }

    int SortByDistance(GameObject go1, GameObject go2)
    {
        float distanceA = Vector3.Distance(go1.transform.position, transform.position);
        float distanceB = Vector3.Distance(go2.transform.position, transform.position);
        
        return distanceA.CompareTo(distanceB);
    }
}
