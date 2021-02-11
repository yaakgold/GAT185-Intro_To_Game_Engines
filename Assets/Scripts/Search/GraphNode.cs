using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{
    public enum eType
    {
        DEFAULT,
        SOURCE,
        DESTINATION,
        PATH,
        VISITED
    }

    Color[] colors =
    {
        Color.white,
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue
    };

    public struct Edge
    {
        public GraphNode nodeA;
        public GraphNode nodeB;
    }

    public List<Edge> Edges { get; set; } = new List<Edge>();
    public eType Type { get; set; } = eType.DEFAULT;
    public GraphNode Parent { get; set; } = null;
    public bool Visited { get; set; } = false;
    public float Cost { get; set; } = float.MaxValue;
    public float Heuristic { get; set; } = 0;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = colors[(int)Type];

        foreach (Edge edge in Edges)
        {
            Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position);
        }
    }

    public static GraphNode[] GetGraphNodes()
    {
        return GameObject.FindObjectsOfType<GraphNode>();
    }

    public static GraphNode GetGraphNode(eType type)
    {
        GraphNode[] graphNodes = GetGraphNodes();

        foreach (GraphNode gn in graphNodes)
        {
            if(gn.Type == type)
            {
                return gn;
            }
        }

        return null;
    }

    public static void UnLinkNodes()
    {
        GraphNode[] graphNodes = GetGraphNodes();

        foreach (GraphNode node in graphNodes)
        {
            node.Edges.Clear();
        }
    }

    public static void LinkNodes(float range)
    {
        GraphNode[] graphNodes = GetGraphNodes();

        foreach (GraphNode node in graphNodes)
        {
            LinkNode(node, range);
        }
    }

    public static void LinkNode(GraphNode node, float range)
    {
        Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);
        foreach (Collider col in colliders)
        {
            GraphNode other = col.GetComponent<GraphNode>();
            if (other != null && other != node)
            {
                GraphNode.Edge edge;
                edge.nodeA = node;
                edge.nodeB = other;

                node.Edges.Add(edge);
            }
        }
    }

    public static void ClearNodeType(eType type)
    {
        GraphNode[] graphNodes = GetGraphNodes();

        foreach (GraphNode node in graphNodes)
        {
            if(node.Type == type)
            {
                node.Type = eType.DEFAULT;
            }
        }
    }

    public static void Reset()
    {
        ClearNodeType(eType.PATH);
        ClearNodeType(eType.VISITED);

        GraphNode[] graphNodes = GetGraphNodes();

        foreach (GraphNode node in graphNodes)
        {
            node.Visited = false;
            node.Parent = null;
            node.Cost = float.MaxValue;
        }
    }
}
