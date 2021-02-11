using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;

    Dictionary<string, State> states = new Dictionary<string, State>();

    public Agent Owner { get; set; }
    public State State { get; set; }


    void Start()
    {
        Owner = GetComponent<Agent>();
        State[] myStates = GetComponents<State>();

        foreach (State state in myStates)
        {
            states.Add(state.GetType().Name, state);
        }

        SetState(initialState);
    }

    public void Execute()
    {
        State?.Execute(Owner);
        Owner.animator.SetFloat("Speed", Owner.movement.Velocity.magnitude);
    }

    public void SetState(State newState)
    {
        if(newState != State)
        {
            State?.Exit(Owner);
            State = newState;
            newState.Enter(Owner);
        }
    }

    public void SetState(string stateName)
    {
        if(states.ContainsKey(stateName))
        {
            SetState(states[stateName]);
        }
    }
}
