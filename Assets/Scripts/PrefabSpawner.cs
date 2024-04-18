using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject inventoryItemPrefab; // Prefab de InventoryItem
    public InventorySlot[] inventorySlots; // Arreglo de todos los slots del inventario
    public Item[] items; // Array of all possible items

    private void Start()
    {
        // Load all items from the "Items" folder in the Resources directory
        items = Resources.LoadAll<Item>("UnlockedItems");

        // Carga todos los items automáticamente al iniciar
        LoadAllItems();
    }

    // Método para cargar todos los items en los slots disponibles al inicio
    public void LoadAllItems()
    {
        foreach (Item item in items)
        {
            bool itemPlaced = false;
            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.transform.childCount == 0) // Verifica si el slot está vacío
                {
                    SpawnItem(item, slot);
                    itemPlaced = true;
                    break; // Sale del bucle una vez que el item es colocado
                }
            }
            if (!itemPlaced)
            {
                Debug.Log("No hay slots vacíos disponibles para colocar más items.");
                break; // Salir del bucle de items si no se encuentra un slot vacío
            }
        }
    }

    // Método para crear un item específico en un slot específico
    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItemComponent = newItem.GetComponent<InventoryItem>();
        if (inventoryItemComponent != null)
        {
            inventoryItemComponent.InitialiseItem(item);
        }
    }
}
