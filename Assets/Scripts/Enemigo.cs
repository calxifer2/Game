using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    private Player player;

    public int maxHealth = 50;
    public int currentHealth;
    public Slider healthBar;

    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    private GameObject target;

    public int scoreValue; // La cantidad de puntos que el jugador obtiene al matar a este enemigo

    public int damage;

    private AudioSource audioSource;

    void Start()
    {
        // Busca el objeto del jugador y almacena una referencia a su componente Player
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("¡Error! No se encontró el objeto del jugador.");
        }

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    void ComportamientoEnemigo()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, target.transform.position);
        if (distanciaAlJugador > 15)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= 5)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    anim.SetBool("Idle", true);
                    anim.SetBool("Attack", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * Time.deltaTime);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Attack", false);
                    break;
            }
        }
        else
        {
            PerseguirYAtacarAlJugador(distanciaAlJugador);
        }
    }

    void PerseguirYAtacarAlJugador(float distanciaAlJugador)
    {
        var direccion = target.transform.position - transform.position;
        direccion.y = 0;
        var rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 3);

        if (distanciaAlJugador > 2)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            transform.Translate(Vector3.forward * 4 * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.OnEnemyHit(damage);
                Debug.Log("Golpe al player");
            }
        }

        if (other.CompareTag("PlayerWeapon"))
        {
            RecibirDanio(20);
            Debug.Log("Golpe al enemigo");
        }
    }


    public void RecibirDanio(int cantidad)
    {
        currentHealth -= cantidad;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {

        audioSource.Play();

        // Verificar si el Animator tiene el parámetro "Morir"
        if (anim != null && HasAnimatorParameter("Morir"))
        {
            anim.SetTrigger("Morir");
            Destroy(gameObject, 2f); // Destruir el objeto después de 2 segundos
        }
        else
        {
            Destroy(gameObject, 1f); // Destruir si no tiene la animación "Morir"
        }

        // Método para verificar si el Animator tiene un parámetro específico
        bool HasAnimatorParameter(string paramName)
        {
            foreach (AnimatorControllerParameter param in anim.parameters)
            {
                if (param.name == paramName)
                {
                    return true;
                }
            }
            return false;
        }

        // Llamar al GameManager para aumentar la puntuación
        Score.instance.IncreaseScore(scoreValue);

        // Aumentar la vida del jugador si no excede su vida máxima
        if (player != null)
        {
            player.IncreaseHealth(15); // Ajusta el valor de aumento según sea necesario
        }
    }

}
