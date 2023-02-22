using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection
{
    public Transform BaseTarget { get; private set; }
    public Transform ClosestTarget { get; private set; }

    private MonoBehaviour _monoBehaviour;
    private LayerMask _enemyLayer;
    private float _detectionRadius;

    public TargetDetection(Transform baseTarget, MonoBehaviour monoBehaviour, LayerMask enemyLayer, float detectionRadius)
    {
        BaseTarget = baseTarget;
        _monoBehaviour = monoBehaviour;
        _enemyLayer = enemyLayer;
        _detectionRadius = detectionRadius;
    }

    public void CompareTarget(Transform target)
    {
        if (ClosestTarget == null)
            ClosestTarget = target;
        else
            CheckDistanceToTarget(target);
    }

    public Transform SetNewTarget()
    {
        if (!Physics.CheckSphere(_monoBehaviour.transform.position, _detectionRadius, _enemyLayer))
        {
            ClosestTarget = BaseTarget;
        }
        else
        {
            Collider[] targets = Physics.OverlapSphere(_monoBehaviour.transform.position, _detectionRadius, _enemyLayer);
            if (targets.Length == 1)
                ClosestTarget = targets[0].transform;
            else
                ClosestTarget = GetClosestTarget(targets);
        }

        return ClosestTarget;
    }

    private void CheckDistanceToTarget(Transform target)
    {
        if (GetDistanceToTarget(target.position) < GetDistanceToTarget(ClosestTarget.position))
            ClosestTarget = target;
    }

    private float GetDistanceToTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(_monoBehaviour.transform.position, targetPosition);
    }

    private Transform GetClosestTarget(Collider[] targets)
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider target in targets)
        {
            float distance = Vector3.Distance(_monoBehaviour.transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestTarget = target.transform;
                closestDistance = distance;
            }
        }

        return closestTarget;
    }
}
