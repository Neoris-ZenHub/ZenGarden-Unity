using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public PrefabSpawner prefabSpawner; // Añade una referencia al PrefabSpawner

    public void AddItem(Item item){
        // Use the PrefabSpawner to add items
        prefabSpawner.LoadAllItems();
    }


    // Método delegado a PrefabSpawner para instanciar nuevos items
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        prefabSpawner.SpawnItem(item, slot); // Asumiendo que esta función existe en PrefabSpawner
    }
}
