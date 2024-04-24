using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    //private bool isSelected = false;void Start()
    void Start()
    {
        // Get the Animator component
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            // Set the "PlayAnimation" boolean to false
            animator.SetBool("PlayAnimation", false);
        }
    }





    public void InitialiseItem(Item newItem){
        Debug.Log("Initialising item with newItem: " + (newItem != null ? newItem.name : "null"));
        Debug.Log("Image component is: " + (image != null ? "assigned" : "null"));

        if (newItem == null || image == null){
            Debug.LogError("InitialiseItem received null newItem or image is not assigned.");
            return;
        }
        item = newItem;
        image.sprite = newItem.image;
    }

    public void OnBeginDrag (PointerEventData eventData){
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging");
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
