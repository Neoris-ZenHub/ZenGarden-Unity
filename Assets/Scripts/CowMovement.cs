using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float distancia;

    private int numAleatorio;
    private Animator animator;

    private float interval = 42f;
    private float activeDuration = 10f;

    public void Start()
    {
        numAleatorio = Random.Range(0, puntos.Length);

        animator = GetComponent<Animator>();

        StartCoroutine(MovementRoutine());
    }

    private IEnumerator MovementRoutine()
    {
        while (true) // Loop infinito
        {
            yield return new WaitForSeconds(interval);

            yield return new WaitForSeconds(0.5f);
            float endTime = Time.time + activeDuration; // Calcula el tiempo para dar fin al movimiento
            while (Time.time < endTime)
            {
                MoveToNextPoint();
                yield return null; // Espera un cuadro antes de continuar
            }

            ResetAnimator();
        }
    }

    private void MoveToNextPoint()
    {
        // Mover hacia el punto si no está lo suficientemente cerca
        if (Vector2.Distance(transform.position, puntos[numAleatorio].position) >= distancia)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntos[numAleatorio].position, speed * Time.deltaTime);
            UpdateAnimator();
        }
        else
        {
            // Cambiar al siguiente punto aleatorio
            numAleatorio = Random.Range(0, puntos.Length);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetBool("stop", false);
        if (transform.position.y < puntos[numAleatorio].position.y)
        {
            animator.SetBool("movingY", true);
            animator.SetBool("movingY2", false);
        }
        else if (transform.position.y > puntos[numAleatorio].position.y)
        {
            animator.SetBool("movingY", false);
            animator.SetBool("movingY2", true);
        }
    }

    private void ResetAnimator()
    {
        animator.SetBool("stop", false);
        animator.SetBool("movingY", false);
        animator.SetBool("movingY2", false);

        animator.Play("CowTurned");
    }
}