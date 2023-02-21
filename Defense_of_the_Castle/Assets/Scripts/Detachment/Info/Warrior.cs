using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "DetachmentInfo/Warrior")]
public class Warrior : DetachmentInfo, IDetachmentSpawn
{
    [SerializeField] private float _speed;
    [SerializeField] private PrefabInfo _swordPrefab;
    public float Speed => _speed;
    public PrefabInfo SwordPrefab => _swordPrefab;


    public void Spawn(Vector3 position)
    {
        Debug.Log("Warrior");
    }
}
