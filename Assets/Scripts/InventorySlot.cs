using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    private void Awake(){
        Deselect();
    }

    public void OnPointerEnter(PointerEventData eventData){
        Select();
    }

    public void OnPointerExit(PointerEventData eventData){
        Deselect();
    }

    public void Select(){
        image.color = selectedColor;
    }

    public void Deselect(){
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            InventoryItem droppedItem = dropped.GetComponent<InventoryItem>();

            // Comprobar si la ranura de destino ya tiene un elemento
            if (transform.childCount > 0)
            {
                // La ranura de destino ya tiene un item, intercambiar los items.
                InventoryItem currentItem = transform.GetChild(0).GetComponent<InventoryItem>();
                Transform droppedItemOriginalParent = droppedItem.parentAfterDrag;

                // Mueve el item actual al original del que se solt�
                currentItem.parentAfterDrag = droppedItemOriginalParent;
                currentItem.transform.SetParent(droppedItemOriginalParent);
                currentItem.transform.position = droppedItemOriginalParent.position;

                // Mueve el item soltado al espacio libre
                droppedItem.parentAfterDrag = transform;
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.position = transform.position;
            }
            else
            {
                // La ranura de destino est� vac�a, mover el item soltado aqu�.
                droppedItem.parentAfterDrag = transform;
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.position = transform.position;
            }
        }
    }
}
