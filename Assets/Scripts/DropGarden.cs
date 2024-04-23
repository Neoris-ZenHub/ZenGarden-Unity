using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropGarden : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        draggableItem.parentAfterDrag = transform;

        // Get random coordinates within the specified range
        float randomX = Random.Range(-8.4f, 8.8f);
        float randomY = Random.Range(-2.6f, 4.2f);
        float randomZ = 0f; // Assuming the object remains at the same Z-coordinate

        // Set the position of the dropped object to the random coordinates
        dropped.transform.position = new Vector3(randomX, randomY, randomZ);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
