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

    public FixedJoystick movementJoystick; // Joystick para movimiento

    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
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

        // Usar el joystick para el movimiento
        float x = movementJoystick.Horizontal;
        float z = movementJoystick.Vertical;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && movementJoystick.Vertical > 0.5f) // Asegurar salto solo cuando el joystick se mueve hacia adelante
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Lógica para cuando el jugador muere
        Debug.Log("Jugador ha muerto.");
    }
}

