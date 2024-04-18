using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (item)
        {
            item.transform.position = this.transform.position; // Ajusta esta línea según necesites
            Debug.Log("Objeto soltado en la zona de drop");
        }
    }
}
