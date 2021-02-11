using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateAgent : Agent
{
    public StateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Execute();
    }
}
