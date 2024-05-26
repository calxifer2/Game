using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovimientos : MonoBehaviour
{
    public float velocidad = 1f;
    public float randomMoveInterval = 9f;
    public float detectionRange = 15f; 
    private Transform player;
    private bool isPlayerInRange = false;
    private Vector3 randomDirection; 
    private float timeSinceLastMove = 2f; // Tiempo transcurrido desde el último cambio de dirección

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
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);


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
        transform.position += direction * velocidad * Time.deltaTime;
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
        transform.position += randomDirection * velocidad * Time.deltaTime;
    }

    void GenerateRandomDirection()
    {
        // Genera una dirección aleatoria
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0).normalized;
    }
}
