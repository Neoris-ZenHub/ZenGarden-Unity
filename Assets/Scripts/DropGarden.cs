using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropGarden : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        draggableItem.parentAfterDrag = transform;

        // Get random coordinates within the specified range
        float randomX = Random.Range(-8.61f, 9.01f);
        float randomY = Random.Range(-2.77f, 4.44f);
        float randomZ = 0f; // Assuming the object remains at the same Z-coordinate

        // Set the position of the dropped object to the random coordinates
        dropped.transform.position = new Vector3(randomX, randomY, randomZ);
    }
}
