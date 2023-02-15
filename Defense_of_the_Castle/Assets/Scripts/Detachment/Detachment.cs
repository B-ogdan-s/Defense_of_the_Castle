using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Detachment : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private float _timeAttack;
    [SerializeField] private int _numSoldiers;
    [SerializeField] private GameObject _detachmentPrefab;

    public int Level => _level;
    public int Health => _health;
    public int Attack => _attack;
    public float TimeAttack => _timeAttack;
    public int NumSoldiers => _numSoldiers;
    public GameObject DetachmentPrefab => _detachmentPrefab;
}
