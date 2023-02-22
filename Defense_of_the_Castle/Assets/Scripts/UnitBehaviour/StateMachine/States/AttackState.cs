using System;
using UnityEngine;

public class AttackState : State
{
    private Transform _target;
    private IDamageble _damageble;
    public AttackState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher)
    {

    }
    public override string Name => "AttackState";

    public override void Enter()
    {
        _target = _unit.TargetDetection.ClosestTarget;

        if (Vector3.Distance(_unit.transform.position, _target.position) > _unit.Data.AttackRange)
            _stateSwitcher.ChangeState<MoveState>();
        else
            _damageble = _target.GetComponent<IDamageble>();
    } 
    public override void Update()
    {
        if (_target == null)
        {
            _target = _unit.TargetDetection.SetNewTarget();
            _damageble = _target.GetComponent<IDamageble>();
        }
        else
        {
            if (Vector3.Distance(_unit.transform.position, _target.position) <= _unit.Data.AttackRange)
                Attack(_damageble);
        }
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    private void Attack(IDamageble damageble)
    {
        throw new NotImplementedException();
    }
}