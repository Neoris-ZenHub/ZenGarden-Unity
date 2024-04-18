using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public PrefabSpawner prefabSpawner; // Añade una referencia al PrefabSpawner
    /*
    int selectedSlot = -1;
    
    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != "")
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }
    
    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect(); // Asegura que Deselect() esté implementado en InventorySlot
        }

        inventorySlots[newValue].Select(); // Asegura que Select() esté implementado en InventorySlot
        selectedSlot = newValue;
    }
    */
    public void AddItem(Item item){
        // Use the PrefabSpawner to add items
        prefabSpawner.SpawnRandomItemInInventory();
    }


    // Método delegado a PrefabSpawner para instanciar nuevos items
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        prefabSpawner.SpawnItem(item, slot); // Asumiendo que esta función existe en PrefabSpawner
    }
}
