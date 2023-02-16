using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Archer", menuName = "Detachment/Archer")]
public class Archer : Detachment, IDetachmentSpawn
{
    [SerializeField] private PrefabInfo _onionPrefab;
    [SerializeField] private PrefabInfo _arrowPrefab;

    [SerializeField] private Archer _nextLevel;

    public PrefabInfo OnionPrefab => _onionPrefab;
    public PrefabInfo ArrowPrefab => _arrowPrefab;

    public Archer NextLevel => _nextLevel;

    public void Spawn(Vector3 position)
    {
        Debug.Log("Archer");
    }
}
