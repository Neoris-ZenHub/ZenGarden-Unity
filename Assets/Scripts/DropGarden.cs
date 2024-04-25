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
        float randomY = Random.Range(-2.6f, 3.3f);
        float randomZ = 0f; // Assuming the object remains at the same Z-coordinate

        // Set the position of the dropped object to the random coordinates
        dropped.transform.position = new Vector3(randomX, randomY, randomZ);

        // Play the animation
        Animator animator = dropped.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("PlayAnimation", true);
            StartCoroutine(ResetAnimation(animator));
        }

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
}

    IEnumerator ResetAnimation(Animator animator)
    {
        // Wait for the length of the animation clip
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Then reset the boolean
        animator.SetBool("PlayAnimation", false);
    }

}
