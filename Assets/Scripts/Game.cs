using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int Score { get; set; } = 0;

    static Game _instance = null;

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;
    }

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    public void AddScore(int points)
    {
        Score += points;
        Debug.Log(Score);
    }
}
