using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : MonoBehaviour, ITouch
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private DetachmentInfo[] _detachment;

    public DetachmentInfo Detachment => _detachment[0];

    public Action<Barrack, System.Func<int, DetachmentInfo>> CheckFreeTroops;

    public void TouchDown(Vector2 down)
    {

    }

    public void TouchHandler(Vector2 handler)
    {

    }

    public void TouchUp(Vector2 up)
    {
        CheckFreeTroops?.Invoke(this, Merge);
    }

    private DetachmentInfo Merge(int level)
    {
        if (level >= _detachment.Length)
            return null;

        return _detachment[level];
    }
}
