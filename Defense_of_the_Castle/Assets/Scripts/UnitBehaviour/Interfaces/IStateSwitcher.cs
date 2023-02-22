using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateSwitcher
{
    void ChangeState<T>() where T : State;
}
