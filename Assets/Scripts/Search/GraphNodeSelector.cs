using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeSelector : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject selection;

    public bool IsActive { get { return selection.activeSelf; } }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
        {
            GraphNode node = hit.collider.GetComponent<GraphNode>();

            selection.SetActive(true);
            selection.transform.position = hit.collider.transform.position;

            if(Input.GetMouseButton(1))
            {
                if(Input.GetKey(KeyCode.S))
                {
                    GraphNode.ClearNodeType(GraphNode.eType.SOURCE);
                    node.Type = GraphNode.eType.SOURCE;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GraphNode.ClearNodeType(GraphNode.eType.DESTINATION);
                    node.Type = GraphNode.eType.DESTINATION;
                }
            }
        }
        else
        {
            selection.SetActive(false);
        }
    }
}
