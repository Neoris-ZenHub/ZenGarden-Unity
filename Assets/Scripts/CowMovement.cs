using System.Collections;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public Animator animator;
    public float minY = -2.06f;
    public float maxY = 2.27f;
    private float restTime = 90f; // 1.5 minutes for rest
    private bool isResting;
    private float moveDuration;
    private float moveTimer;

    private void Start()
    {
        StartCoroutine(CowRoutine());
    }

    private IEnumerator CowRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 15f)); // Tiempo aleatorio entre animaciones
            if (!isResting)
            {
                // Activar una animación al azar
                string animation = GetRandomAnimation();
                animator.SetBool(animation, true);

                // Si se activan move o return, inicia movimiento
                if (animation == "IsMove" || animation == "IsReturn")
                {
                    moveDuration = Random.Range(3f, 15f); // Duración del movimiento aleatorio
                    moveTimer = moveDuration; // Reiniciar el temporizador de movimiento
                    float direction = (animation == "IsMove") ? -1f : 1f; // Determina la dirección basada en la animación
                    StartCoroutine(MoveCow(direction));
                }

                yield return new WaitForSeconds(1f); // Espera un segundo antes de desactivar la animación
                animator.SetBool(animation, false);

                // Si se activa rest, inicia el período de descanso
                if (animation == "IsRest")
                {
                    isResting = true;
                    yield return new WaitForSeconds(restTime);
                    animator.SetBool("IsUp", true); // Activa animación de levantarse
                    yield return new WaitForSeconds(1f); // Espera un poco antes de desactivar
                    animator.SetBool("IsUp", false);
                    isResting = false;
                }
            }
        }
    }

    private IEnumerator MoveCow(float direction)
    {
        while (moveTimer > 0)
        {
            float yMove = direction * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(0, yMove, 0);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY); // Mantén la posición dentro del rango
            transform.position = newPosition;

            moveTimer -= Time.deltaTime;
            yield return null;
        }
    }

    private string GetRandomAnimation()
    {
        string[] animations = { "IsTurned", "IsIdle", "IsMove", "IsReturn" };
        int randomIndex = Random.Range(0, animations.Length);
        return animations[randomIndex];
    }
}
