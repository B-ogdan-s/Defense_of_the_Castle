using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitData _data;
    [SerializeField] private Transform _baseTarget;
    public UnitData Data => _data;
    public TargetDetection TargetDetection { get; private set; }

    protected UnitBehaviourStateMachine _stateMachine;

    private SphereCollider _detectionCollider;

    protected abstract void Initialize();
    private void BaseInitialize()
    {
        TargetDetection = new TargetDetection(_baseTarget, this, _data.EnemyLayer, _data.TargetDetectionRadius);
        _detectionCollider.radius = _data.TargetDetectionRadius;
        Initialize();
    }

    private void Start()
    {
        BaseInitialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _data.EnemyLayer)
            TargetDetection.CompareTarget(other.transform);
    }
}
