using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0){
            GameObject dropped = FollowMouseOnClick.selectedObject;
            if (dropped != null) {
                InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
                if (draggableItem != null) {
                    draggableItem.parentAfterDrag = transform;
                    FollowMouseOnClick.selectedObject = null;
                }
            }
        }
    }
}