using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class TouchPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private ITouch _touch;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touch = TouchRay(eventData.position);

        if (_touch != null)
            _touch.TouchDown();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_touch == TouchRay(eventData.position) && _touch != null)
        {
            _touch.TouchHandler();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_touch == TouchRay(eventData.position) && _touch != null)
        {
            _touch.TouchUp();
        }
    }

    private ITouch TouchRay(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.transform.TryGetComponent(out ITouch touch))
                return touch;
        }
        return null;
    }
}
