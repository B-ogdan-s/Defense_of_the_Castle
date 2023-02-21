using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationDetachment : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private SpawnPlaneInfo[] _spawnPlanes;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private Timer _timer;

    [SerializeField] private Barrack[] _barracks;

    [SerializeField] private int _detachmentNum = 0;

    private void Start()
    {
        _timer.UpdateText(_detachmentNum);
        _timer.StartTimer(_timeSpawn);
        _timer.AddDetachment += AddDetachment;

        foreach(Barrack b in _barracks)
        {
            b.CheckFreeTroops += CheckFreeTroops;
        }
    }

    private void AddDetachment()
    {
        _detachmentNum++;
        _timer.UpdateText(_detachmentNum);
        _timer.StartTimer(_timeSpawn);
    }

    private void CheckFreeTroops(Barrack barrack, System.Func<int, DetachmentInfo> action)
    {
        if (_detachmentNum <= 0)
            return;
        SpawnPlaneInfo spawnPlaneInfo = null;

        foreach(var s in _spawnPlanes)
        {
            if (s.isFree)
            {
                spawnPlaneInfo = s;
                break;
            }
        }
        if (spawnPlaneInfo == null)
            return;

        _detachmentNum--;

        Detachment det = Instantiate(_spawnPrefab).GetComponent<Detachment>();
        det.MergeFunc += action;
        det.transform.position = spawnPlaneInfo.Position.position;
        det.StartSettings(spawnPlaneInfo, barrack.Detachment);

        _timer.UpdateText(_detachmentNum);
         
    }

    private void OnDestroy()
    {
        _timer.AddDetachment -= AddDetachment;
        foreach (Barrack b in _barracks)
        {
            b.CheckFreeTroops -= CheckFreeTroops;
        }
    }
}
