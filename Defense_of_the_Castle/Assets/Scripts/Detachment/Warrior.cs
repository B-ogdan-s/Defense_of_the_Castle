using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "Detachment/Warrior")]
public class Warrior : Detachment
{
    [SerializeField] private GameObject _swordPrefab;

    [SerializeField] private Warrior _nextLevel;

    public GameObject SwordPrefab => _swordPrefab;
    public Warrior NextLevel => _nextLevel;
}
