using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject GetIcon()
    {
        if (transform.childCount > 0)
            return transform.GetChild(0).gameObject;
        else
            return null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (GetIcon() == null)
        {
            Drag.beingDraggedIcon.transform.SetParent(transform);
            Drag.beingDraggedIcon.transform.position = transform.position;
        }
    }
}

