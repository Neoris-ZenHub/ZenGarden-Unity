using UnityEngine;

public class FollowMouseOnClick : MonoBehaviour {
    private bool isFollowing = false; // Variable para rastrear si el objeto sigue el cursor
    private Vector3 targetPosition; // Posición de destino para el objeto
    public float moveSpeed = 0.1f;

    void Update () {
        if (isFollowing) {
            // Si está siguiendo, actualiza la posición de destino a la posición del cursor
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // Mantener la misma posición Z
        }

        // Mover gradualmente hacia la posición de destino
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
    }

    void OnMouseDown() {
        // Cambiar el estado de seguimiento cuando se hace clic sobre el objeto
        isFollowing = !isFollowing;
    }
}
