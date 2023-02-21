using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentState;

    private Dictionary<Type, State> states = new Dictionary<Type, State>();

    public void AddState<T>(T state) where T : State
    {
        states[typeof(T)] = state;
    }

    public void SetInitialState<T>() where T : State
    {
        currentState = states[typeof(T)];
        currentState.Enter();
    }

    public void ChangeState<T>() where T : State
    {
        if (states.ContainsKey(typeof(T)))
        {
            currentState?.Exit();
            currentState = states[typeof(T)];
            currentState.Enter();
        }
        else
        {
            Debug.LogError($"State with id {typeof(T)} not found!");
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}

public abstract class State
{
    public abstract string Id { get; }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }
}
