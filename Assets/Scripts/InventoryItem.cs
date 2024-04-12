using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag (PointerEventData eventData){
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging");
        // Convert mouse position to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Keep the same z-coordinate to maintain the same depth
        mousePosition.x = transform.position.x;
        mousePosition.y = transform.position.y;
        mousePosition.z = transform.position.z;
        // Set the position of the object to the mouse position
        transform.position = mousePosition;
    }

    public void OnEndDrag (PointerEventData eventData){
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}