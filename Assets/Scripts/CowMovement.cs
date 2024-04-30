using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float distancia;

    private int numAleatorio;
    public float intervaloCambio = 80f;

    private Animator animator;

    public void Start()
    {
        numAleatorio = Random.Range(0, puntos.Length);

        animator = GetComponent<Animator>();
        //animator.SetBool("stop", true);

        //InvokeRepeating("CambiaPunto", 0f, intervaloCambio);
    }

    public void Update()
    {
        //numAleatorio = Random.Range(0, puntos.Length);
        animator.SetBool("stop", false);

        transform.position = Vector2.MoveTowards(transform.position, puntos[numAleatorio].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntos[numAleatorio].position) < distancia)
        {
            numAleatorio = Random.Range(0, puntos.Length);
            //Move();

            if (transform.position.y < puntos[numAleatorio].position.y)
            {
                animator.SetBool("movingY", true);
            }
            else
            {
                animator.SetBool("movingY", false);
            }
        }
    }

    /*public void Move()
    {
        if (transform.position.y < puntos[numAleatorio].position.y)
        {
            animator.SetBool("movingY", true);
        }
        else
        {
            animator.SetBool("movingY", false);
        }
    }*/
}

/*public class CowMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float stopDuration = 2f; // Tiempo que la vaca se detiene antes de cambiar de dirección
    private float minY = -2.06f;
    private float maxY = 2.27f;
    private float movementDirection = 0f; // Dirección actual del movimiento en Y
    private float movementY = 0f; // Velocidad y dirección del movimiento para el Animator

    private Animator animator;
    private float stopTime; // Tiempo para la próxima parada

    public float intervaloCambio = 80f;

    void Start()
    {
        animator = GetComponent<Animator>();
        //ChooseDirection();

        InvokeRepeating("ChangeDirection", 0f, intervaloCambio);
    }

    void ChangeDirection()
    {
        if (Time.time >= stopTime)
        {
            ChooseDirection(); // Elegir nueva dirección después de la parada
        }

        // Mover la vaca y actualizar el Animator
        float newY = Mathf.Clamp(transform.position.y + movementY * Time.deltaTime, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Actualizar el parámetro del Animator con la dirección del movimiento
        animator.SetFloat("movY", movementDirection);
    }

    void ChooseDirection()
    {
        if (transform.position.y <= minY)
        {
            // Mover hacia arriba
            movementDirection = 1f;
        }
        else if (transform.position.y >= maxY)
        {
            // Mover hacia abajo
            movementDirection = -1f;
        }
        else
        {
            // Elegir una dirección aleatoria
            movementDirection = Random.Range(0, 2) == 0 ? 1f : -1f;
        }

        movementY = movementDirection * speed;
        stopTime = Time.time + stopDuration + Random.Range(-0.5f, 0.5f); // Añadir un poco de aleatoriedad al tiempo de parada
    }
}
*/