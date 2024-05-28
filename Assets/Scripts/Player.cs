using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 8f;

    public float gravity = -12f;
    public float jumpHeight = 2;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;

    Vector3 velocity;
    bool isGrounded;

    public GameObject gameOverPanel;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;


    public AudioSource deathSound;
    public AudioSource healSound;
    public AudioSource grountSound;

    void Start()
    {

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    public void IncreaseHealth(int amount)  // Método para aumentar la vida del jugador
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Asegura que la vida actual no exceda la vida máxima
        healSound.Play();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        grountSound.Play();

        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto.");
        deathSound.Play();

        // Verificar y actualizar la puntuación más alta
        Score.instance.CheckHighScore();

        // Mostrar la puntuación y la puntuación más alta en el panel de Game Over
        if (gameOverPanel != null && gameOverScoreText != null && gameOverHighScoreText != null)
        {
            gameOverScoreText.text = "0" + Score.instance.GetScore();
            gameOverHighScoreText.text = "000" + Score.instance.GetHighScore();
            gameOverPanel.SetActive(true);
        }
    }

    // Este método es llamado cuando el jugador es golpeado por un enemigo
    public void OnEnemyHit(int damage)
    {
        TakeDamage(damage);
        Debug.Log("Player Golpeado");
    }

}
