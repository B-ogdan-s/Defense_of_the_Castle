using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Militia : Unit, IDamageble
{
    public int Health { get; set; }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    protected override void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
