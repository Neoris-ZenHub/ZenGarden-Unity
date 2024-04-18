using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject inventoryItemPrefab; // Prefab de InventoryItem
    public InventorySlot[] inventorySlots; // Arreglo de todos los slots del inventario
    public Item[] items; // Array of all possible items
    private int currentItemIndex = 0; // Index to track the current item to be spawned

    private void Start()
    {
        // Load all items from the "Items" folder in the Resources directory
        items = Resources.LoadAll<Item>("UnlockedItems");
    }

    // Método para añadir un item al primer slot disponible en orden secuencial
    public void SpawnNextItemInInventory()
    {
        if (items.Length == 0) // Check if the items array is empty
        {
            Debug.Log("No items to spawn");
            return;
        }

        if (currentItemIndex >= items.Length) // Check if all items have been spawned
        {
            Debug.Log("All items have been spawned. Resetting index.");
            currentItemIndex = 0; // Reset the index or you can also choose to stop spawning
        }

        Item item = items[currentItemIndex++]; // Select the next item in the array and increment the index

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
