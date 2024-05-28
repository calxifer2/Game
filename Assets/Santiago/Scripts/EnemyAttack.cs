using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public PlayerHealth playerHealth;

    void Start()
    {
        // Encuentra al jugador en la escena
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
