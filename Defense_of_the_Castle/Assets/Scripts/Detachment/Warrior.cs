using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "Detachment/Warrior")]
public class Warrior : Detachment, IDetachmentSpawn
{
    [SerializeField] private float _speed;
    [SerializeField] private PrefabInfo _swordPrefab;
    [SerializeField] private Warrior _nextLevel;

    public float Speed => _speed;
    public PrefabInfo SwordPrefab => _swordPrefab;
    public Warrior NextLevel => _nextLevel;

    public void Spawn(Vector3 position)
    {
        Debug.Log("Warrior");
    }
}
