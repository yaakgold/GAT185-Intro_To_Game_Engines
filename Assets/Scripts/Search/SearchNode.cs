using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SearchNode : MonoBehaviour
{
    internal static SearchNode GetRandomSearchNode()
    {
        SearchNode[] searchNodes = FindObjectsOfType<SearchNode>();
        return searchNodes[Random.Range(0, searchNodes.Length)];
    }
}
