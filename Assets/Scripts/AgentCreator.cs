﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCreator : MonoBehaviour
{
    public Agent[] agents;
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
            {
                Instantiate(agents[0], hit.point, Quaternion.identity);
            }
        }
    }
}
