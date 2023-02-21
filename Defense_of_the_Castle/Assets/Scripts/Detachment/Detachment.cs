using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Detachment : ScriptableObject
{
    [SerializeField] private int _troopCount;
    [SerializeField] private PrefabInfo _detachmentPrefab;

    public int TroopCount => _troopCount;
    public PrefabInfo DetachmentPrefab => _detachmentPrefab;
}

[Serializable]
public class PrefabInfo
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _material;

    public GameObject Prefab => _prefab;
    public Material Material => _material;
}