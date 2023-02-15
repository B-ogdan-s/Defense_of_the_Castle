using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Archer", menuName = "Detachment/Archer")]
public class Archer : Detachment
{
    [SerializeField] private GameObject _onionPrefab;
    [SerializeField] private GameObject _arrowPrefab;

    [SerializeField] private Archer _nextLevel;

    public GameObject OnionPrefab => _onionPrefab;
    public GameObject ArrowPrefab => _arrowPrefab;

    public Archer NextLevel => _nextLevel;
}
