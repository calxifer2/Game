using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosCastillo : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Velocidad de movimiento del enemigo
    public float changeDirectionTime = 2.0f; // Tiempo entre cambios de dirección
    public float playerDetectionDistance = 20f; // Distancia para detectar al jugador
    public float shootingDistance = 65f; // Distancia para empezar a disparar
    public float fireRate = 1f; // Tasa de disparo (tiempo entre disparos)
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo

    private Vector3 movementDirection;
    private float timer;
    private float fireTimer;
    private Rigidbody rb;
    private GameObject Player;

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

        Player = GameObject.FindGameObjectWithTag("Player"); // Buscar al jugador por la etiqueta "Player"

        if (Player == null)
        {
            Debug.LogError("No Player object found with tag 'Player'");
        }

        // Comprobación adicional para asegurarse de que el prefab tiene un Rigidbody
        if (bulletPrefab != null && bulletPrefab.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component");
        }
    }

    void Update()
    {
        if (rb == null || Player == null) return; // Asegúrate de que el Rigidbody y el jugador estén asignados

        timer -= Time.deltaTime;
        fireTimer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTime;
        }

        // Calcular la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        // Si la distancia es menor o igual a la distancia de detección del jugador, dirigirse hacia el jugador
        if (distanceToPlayer <= playerDetectionDistance)
        {
            movementDirection = (Player.transform.position - transform.position).normalized;
        }

        // Si la distancia es menor o igual a la distancia de disparo, disparar al jugador
        if (distanceToPlayer <= shootingDistance && fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate; // Reiniciar el temporizador de disparo
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

    void MoveEnemy()
    {
        rb.velocity = movementDirection * moveSpeed;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instanciar la bala y apuntar hacia el jugador
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            if (bulletRb != null)
            {
                // Calcular la dirección hacia el jugador y aplicar la fuerza a la bala
                Vector3 directionToPlayer = (Player.transform.position - firePoint.position).normalized;
                bulletRb.velocity = directionToPlayer * bulletPrefab.GetComponent<Bullet>().speed;
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody component");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab or fire point not assigned on " + gameObject.name);
        }
    }
}
