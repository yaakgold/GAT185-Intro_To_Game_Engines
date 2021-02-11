using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeCreator : MonoBehaviour
{
    public GraphNode agents;
    public LayerMask layerMask;
    public float range = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
            {
                GraphNode node = Instantiate(agents, hit.point, Quaternion.identity);
                GraphNode.UnLinkNodes();
                GraphNode.LinkNodes(range);
            }
        }
    }
}
