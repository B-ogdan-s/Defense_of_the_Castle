using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveState : State
{
    private IMoveble _moveble;
    private Unit _unit;
    public MoveState(IMoveble moveble, Unit unit)
    {
        Name = "MoveState";
        _moveble = moveble;
        _unit = unit;
    }
    public override string Name { get; }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    //private Transform GetTarget()
    //{
    //    if(_unit.AccessibleTargets.Count > 0)
    //}
}
