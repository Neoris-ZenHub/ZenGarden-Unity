using UnityEngine;
using UnityEngine.EventSystems;

public class TrashItem : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Activar sonido para trash
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // Obtener el item arrastrado
        GameObject item = eventData.pointerDrag;
        
        Destroy(item);
    }
}
