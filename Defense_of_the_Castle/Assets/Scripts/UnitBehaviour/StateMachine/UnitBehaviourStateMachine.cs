using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviourStateMachine : IStateSwitcher
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
    protected Unit _unit;
    protected IStateSwitcher _stateSwitcher;
    public State(Unit unit, IStateSwitcher stateSwitcher)
    {
        _unit = unit;
        _stateSwitcher = stateSwitcher;
    }
    public abstract string Name { get; }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
