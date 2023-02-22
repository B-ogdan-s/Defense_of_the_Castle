using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MoveState : State
{
    private IMoveble _moveble;
    private Transform _target;
    public MoveState(Unit unit, IStateSwitcher stateSwitcher, IMoveble moveble) : base(unit, stateSwitcher)
    {
        Name = "MoveState";
        _moveble = moveble;
        _unit = unit;
    }
    public override string Name { get; }

    public override void Enter()
    {
        _target = GetTarget();
    }

    public override void Exit()
    {
        _target = null;
    }

    public override void Update()
    {
        if (_target == null)
        {
            _target = _unit.TargetDetection.SetNewTarget();
        }
        else
        {
            if (Vector3.Distance(_unit.transform.position, _target.position) > _unit.Data.AttackRange)
                _moveble.MoveToTarget(_target);
            else
                _stateSwitcher.ChangeState<AttackState>();
        }
    }

    protected virtual Transform GetTarget()
    {
        return _unit.TargetDetection.ClosestTarget;
    }
}
