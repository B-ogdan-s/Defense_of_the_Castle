using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Archer", menuName = "DetachmentInfo/Archer")]
public class Archer : DetachmentInfo, IDetachmentSpawn
{
    [SerializeField] private PrefabInfo _onionPrefab;
    [SerializeField] private PrefabInfo _arrowPrefab;

    public PrefabInfo OnionPrefab => _onionPrefab;
    public PrefabInfo ArrowPrefab => _arrowPrefab;

    public void Spawn(Vector3 position)
    {
        Debug.Log("Archer");
    }
}
