using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_kathe : MonoBehaviour
{
     public Transform player;
    public float detectionRadius = 10f; 
    public float speed = 3f;

    private bool isPlayerInRange = false;

    void Update()
    {
        DetectPlayer();
        if (isPlayerInRange)
        {
            ChasePlayer();
        }
    }

    void DetectPlayer()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void ChasePlayer()
    {
        // Dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        // Mueve al enemigo hacia el jugador
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el radio de detección en la vista de escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}







