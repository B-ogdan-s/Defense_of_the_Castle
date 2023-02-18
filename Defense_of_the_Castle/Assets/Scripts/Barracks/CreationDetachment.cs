using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationDetachment : MonoBehaviour
{
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

    private void CheckFreeTroops(Barrack barrack)
    {
        if (_detachmentNum <= 0)
            return;

        _detachmentNum--;
        barrack.Spawn();
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
