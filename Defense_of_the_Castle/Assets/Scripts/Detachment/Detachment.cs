using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detachment : MonoBehaviour, ITouch
{
    [SerializeField] private LayerMask _handler;
    [SerializeField] private LayerMask _touchUp;
    [SerializeField] private DetachmentInfo _detachmentInfo;

    private SpawnPlaneInfo _spawnPlaneInfo;

    private List<GameObject> _troops = new List<GameObject>();

    public Func<int, DetachmentInfo> MergeFunc;

    public DetachmentInfo DetachmentInfo => _detachmentInfo;
    public void StartSettings(SpawnPlaneInfo spawnPlaneInfo, DetachmentInfo detachmentInfo)
    {
        _spawnPlaneInfo = spawnPlaneInfo;
        _detachmentInfo = detachmentInfo;
        _spawnPlaneInfo.isFree = false;

        Spawn();
    }

    public void TouchDown(Vector2 handler)
    {
        Vector3 pos = TouchRay(handler);
        transform.DOMove(pos, 0.1f);

        gameObject.layer = 11;
    }

    public void TouchHandler(Vector2 handler)
    {
        Vector3 pos = TouchRay(handler);

        transform.position = pos;
    }

    public void TouchUp(Vector2 up)
    {
        Ray ray = Camera.main.ScreenPointToRay(up);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _touchUp))
        {
            Debug.Log(hit.transform.name);

            if(hit.transform.TryGetComponent(out Detachment detachment))
            {
                if (_detachmentInfo == detachment.DetachmentInfo)
                {
                    DetachmentInfo info = MergeFunc?.Invoke(_detachmentInfo.Level);

                    if(info != null)
                    {
                        detachment.Merge(info);
                        _spawnPlaneInfo.isFree = true;
                        Destroy(gameObject);
                        return;
                    }
                }
            }
            else if(hit.transform.TryGetComponent(out SpawnPlaneInfo spawnPlaneInfo))
            {
                _spawnPlaneInfo.isFree = true;
                _spawnPlaneInfo = spawnPlaneInfo;
                _spawnPlaneInfo.isFree = false;
            }
                
            transform.DOMove(_spawnPlaneInfo.Position.position, 0.1f);
            gameObject.layer = 0;
        }
    }

    public void Merge(DetachmentInfo info)
    {
        foreach(var obj in _troops)
        {
            Destroy(obj);
        }
        _troops.Clear();

        _detachmentInfo = info;

        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _detachmentInfo.NumSoldiers; i++)
        {
            GameObject obj = Instantiate(_detachmentInfo.DetachmentPrefab.Prefab, transform);
            obj.transform.position += 0.1f * Vector3.up;
            obj.GetComponent<Renderer>().material = _detachmentInfo.DetachmentPrefab.Material;

            _troops.Add(obj);
        }
    }

    private Vector3 TouchRay(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _handler))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
