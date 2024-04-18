using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject inventoryItemPrefab; // Prefab de InventoryItem
    public InventorySlot[] inventorySlots; // Arreglo de todos los slots del inventario

    // Método para añadir un item al primer slot disponible
    public void SpawnItemInInventory(Item item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.transform.childCount == 0) // Verifica si el slot está vacío
            {
                SpawnItem(item, slot);
                return; // Sale del método después de colocar el item
            }
        }
        Debug.Log("No hay slots disponibles");
    }

    // Método para crear un item específico en un slot específico
    public void SpawnItem(Item item, InventorySlot slot)
    {
        if (slot.transform.childCount == 0) // Verifica si el slot está vacío
        {
            GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItemComponent = newItem.GetComponent<InventoryItem>();
            if (inventoryItemComponent != null)
            {
                inventoryItemComponent.InitialiseItem(item);
            }
        }
        else
        {
            Debug.Log("El slot está ocupado");
        }
    }
}
