using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private LayerMask _mask;
    private ITouch _touch;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touch = TouchRay(eventData.position);

        if (_touch != null)
        {
            _touch.TouchDown(eventData.position);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_touch != null)
        {
            _touch.TouchHandler(eventData.position);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_touch != null)
        {
            _touch.TouchUp(eventData.position);
            _touch = null;
        }
    }

    private ITouch TouchRay(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _mask))
        {
            if(hit.transform.TryGetComponent(out ITouch touch))
                return touch;
        }
        return null;
    }
}
