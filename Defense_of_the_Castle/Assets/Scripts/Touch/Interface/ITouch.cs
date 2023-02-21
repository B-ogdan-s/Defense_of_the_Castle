using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouch
{
    public void TouchDown(Vector2 down);
    public void TouchHandler(Vector2 handler);
    public void TouchUp(Vector2 up);
}
