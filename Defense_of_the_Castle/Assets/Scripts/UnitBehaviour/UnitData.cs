using UnityEngine;

public abstract class UnitData : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _targetDetectionRadius;

    public int Level => _level;
    public float Damage => _damage;
    public float AttackCooldown => _attackCooldown;
    public float AttackRange => _attackRange;
    public float TargetDetectionRadius => _targetDetectionRadius;
}