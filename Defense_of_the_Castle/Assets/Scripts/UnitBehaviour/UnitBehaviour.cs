using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    public Enemy Enemy => _enemy;
    public Transform Target { get; set; }
    public StateMachine StateMachine { get; private set; }

    protected virtual void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Base").transform;
        StateMachine = new StateMachine();
        StateMachine.AddState(new MoveState(this));
        StateMachine.AddState(new AttackState(this));
        StateMachine.SetInitialState<MoveState>();
    }

    protected virtual void Update()
    {
        StateMachine.Update();
    }

    public virtual void MoveToTarget(Transform targetTransform)
    {
        if (targetTransform != null)
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, _enemy.Speed * Time.deltaTime);
        else
            StateMachine.ChangeState<MoveState>();
    }

    public virtual void Attack(IDamageble unit)
    {
        unit.TakeDamage(_enemy.Attack);
    }
}
public class MoveState : State
{
    public override string Id => "Move";

    private UnitBehaviour enemy;

    public MoveState(UnitBehaviour enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        enemy.Target = GameObject.FindGameObjectWithTag("Base").transform;
    }

    public override void Update()
    {
        if (enemy.Target != null)
        {
            enemy.MoveToTarget(enemy.Target);
            if (Vector3.Distance(enemy.transform.position, enemy.Target.position) < enemy.Enemy.AttackRange)
                enemy.StateMachine.ChangeState<AttackState>();
        }
    }
}

public class AttackState : State
{
    public override string Id => "Attack";

    private UnitBehaviour enemy;
    private IDamageble _attackTarget;

    public AttackState(UnitBehaviour enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        // Find the nearest player unit and set it as the target
        _attackTarget = enemy.Target.GetComponent<IDamageble>();
    }

    public override void Update()
    {
        if (_attackTarget == null)
            enemy.StateMachine.ChangeState<MoveState>();
        else if (Vector3.Distance(enemy.transform.position, enemy.Target.position) < enemy.Enemy.AttackRange)
            enemy.Attack(_attackTarget);
        else
            enemy.MoveToTarget(enemy.Target);
    }

    public class FindTargetState : State
    {
        public override string Id => "FindingTarget";
        private UnitBehaviour _unit;
        public FindTargetState(UnitBehaviour unit)
        {
            _unit = unit;
        }
        private Transform FindNearestPlayerUnit()
        {
            // Find the nearest player unit and return its transform
            // This might involve using Unity's built-in physics system or writing your own code
        }
    }
}
