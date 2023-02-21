using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Detachment : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private float _timeAttack;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _numSoldiers;
    [SerializeField] private PrefabInfo _detachmentPrefab;

    public int Level => _level;
    public int Health => _health;
    public int Attack => _attack;
    public float TimeAttack => _timeAttack;
    public float AttackRange => _attackRange;
    public int NumSoldiers => _numSoldiers;
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