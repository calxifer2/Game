using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f; // Tiempo de vida de la bala
    public float speed = 20f; // Velocidad de la bala

    void Awake()
    {
        Destroy(gameObject, life); // Destruir la bala después de un cierto tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar que la bala solo destruya al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes añadir lógica para aplicar daño al jugador
            Debug.Log("Player hit!");
            // Destroy(collision.gameObject); // Si quieres destruir al jugador (generalmente no se hace así)
        }
        
        Destroy(gameObject); // Destruir la bala después de la colisión
    }
}
