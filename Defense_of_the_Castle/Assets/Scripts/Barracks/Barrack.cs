using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : MonoBehaviour, ITouch
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Detachment _iDetachment;

    private IDetachmentSpawn _iDetachmentSpawn;

    public Action<Barrack> CheckFreeTroops;

    public void Spawn()
    {
        _iDetachmentSpawn.Spawn(_spawnPosition.position);
    }

    public void TouchDown()
    {

    }

    public void TouchHandler()
    {

    }

    public void TouchUp()
    {
        CheckFreeTroops?.Invoke(this);
    }

    private void OnValidate()
    {
        if(_iDetachment is IDetachmentSpawn)
        {
            _iDetachmentSpawn = (IDetachmentSpawn)_iDetachment;
        }
        else
        {
            _iDetachmentSpawn = null;
            _iDetachment = null;
        }
    }
}
