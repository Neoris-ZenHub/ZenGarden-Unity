using UnityEngine;
using UnityEngine.EventSystems;

public class TrashItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Obtener referencia al item arrastrado
        GameObject item = eventData.pointerDrag;
        
        Destroy(item);

        // Activar sonido de reciclaje
    }
}
