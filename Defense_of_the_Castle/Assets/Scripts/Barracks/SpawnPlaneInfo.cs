using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaneInfo : MonoBehaviour
{
    [SerializeField] private Transform _position;

    public bool isFree = true;
    public Transform Position => _position;
}
