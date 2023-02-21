using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitData _data;
    [SerializeField] private Transform _baseTarget;
    public Transform BaseTarget => _baseTarget;

    private Transform _closestTarget;
    public Transform ClosestTarget => _closestTarget;

    protected UnitBehaviourStateMachine _stateMachine;
    private SphereCollider _detectionCollider;
    protected abstract void Initialize();
    private void BaseInitialize()
    {
        _detectionCollider.radius = _data.TargetDetectionRadius;
        Initialize();
    }

    private void Start()
    {
        BaseInitialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble damageble))
        {
            //if (CheckDistanceToTarget(other.transform.position))
            //    _closestTarget = other.transform;
        }
    }

    //private bool CheckDistanceToTarget(Vector3 targetPosition)
    //{
    //    if(Vector3.Distance(transform.position, targetPosition))
    //}
}
