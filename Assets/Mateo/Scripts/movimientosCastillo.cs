using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosCastillo : MonoBehaviour
{
    public float moveSpeed = 8.0f; // Velocidad de movimiento del enemigo
    public float changeDirectionTime = 2.0f; // Tiempo entre cambios de dirección
    public float playerDetectionDistance = 20f; // Distancia para detectar al jugador

    private Vector3 movementDirection;
    private float timer;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on " + gameObject.name);
            return;
        }

        // Congelar rotaciones para evitar que el enemigo se caiga
        rb.freezeRotation = true;

        timer = changeDirectionTime;
        ChangeDirection();

        player = GameObject.FindGameObjectWithTag("Player"); // Buscar al jugador por la etiqueta "Player"
    }

    void Update()
    {
        if (rb == null || player == null) return; // Asegúrate de que el Rigidbody y el jugador estén asignados

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTime;
        }

        // Calcular la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Si la distancia es menor o igual a la distancia de detección del jugador, dirigirse hacia el jugador
        if (distanceToPlayer <= playerDetectionDistance)
        {
            MoveTowardsPlayer();
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return; // Asegúrate de que el Rigidbody está asignado

        MoveEnemy();
    }

    void ChangeDirection()
    {
        float randomAngleY = Random.Range(0f, 360f);
        float radiansY = randomAngleY * Mathf.Deg2Rad;

        // Movimiento solo en el plano XZ
        movementDirection = new Vector3(Mathf.Cos(radiansY), 0, Mathf.Sin(radiansY)).normalized;
    }

    void MoveTowardsPlayer()
    {
        movementDirection = (player.transform.position - transform.position).normalized;
    }

    void MoveEnemy()
    {
        rb.velocity = movementDirection * moveSpeed;
    }
}
