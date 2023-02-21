using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveble 
{
    float Speed { get; set; }
    void MoveToTarget(Transform target);
}
