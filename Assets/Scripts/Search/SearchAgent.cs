using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAgent : MonoBehaviour
{
    public WaypointNode waypoint;

    private void Update()
    {
        if(waypoint != null)
        {
            Vector3 dir = waypoint.transform.position - transform.position;
            transform.position += dir.normalized * 2 * Time.deltaTime;
        }
    }
}
