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
        // Obtener el item arrastrado
        GameObject item = eventData.pointerDrag;
        
        Destroy(item);

        // Activar sonido de reciclaje
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
