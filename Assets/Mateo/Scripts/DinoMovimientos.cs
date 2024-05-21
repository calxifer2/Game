using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovimientos : MonoBehaviour
{
    public float speed = 2f; // Velocidad del enemigo
    public float randomMoveInterval = 3f; // Intervalo de tiempo para cambiar de dirección en movimientos aleatorios
    public float detectionRange = 15f; // Rango de detección del jugador
    private Transform player; // Referencia al transform del jugador
    private bool isPlayerInRange = false; // Bandera para comprobar si el jugador está cerca
    private Vector3 randomDirection; // Dirección aleatoria
    private float timeSinceLastMove = 0f; // Tiempo transcurrido desde el último cambio de dirección

    void Start()
    {
        // Encuentra al jugador por su tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        // Genera una dirección aleatoria inicial
        GenerateRandomDirection();
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula la distancia al jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Si el jugador está dentro del rango de detección, moverse hacia él
            if (distanceToPlayer <= detectionRange)
            {
                isPlayerInRange = true;
            }
            else
            {
                isPlayerInRange = false;
            }
        }

        if (isPlayerInRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveRandomly();
        }
    }

    void MoveTowardsPlayer()
    {
        // Dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        // Movimiento hacia el jugador
        transform.position += direction * speed * Time.deltaTime;
    }

    void MoveRandomly()
    {
        // Incrementa el tiempo transcurrido
        timeSinceLastMove += Time.deltaTime;

        // Si ha pasado suficiente tiempo, genera una nueva dirección aleatoria
        if (timeSinceLastMove >= randomMoveInterval)
        {
            GenerateRandomDirection();
            timeSinceLastMove = 0f;
        }

        // Mueve al enemigo en la dirección aleatoria actual
        transform.position += randomDirection * speed * Time.deltaTime;
    }

    void GenerateRandomDirection()
    {
        // Genera una dirección aleatoria
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0).normalized;
    }
}
