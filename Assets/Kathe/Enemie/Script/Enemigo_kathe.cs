using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_kathe : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Vector3 direccionMovimiento; // Nueva variable para almacenar la dirección de movimiento
    public GameObject target;

    public GameObject enemyPrefab; // Prefab del enemigo que quieres instanciar
    public float spawnInterval = 10f; // Intervalo de tiempo en segundos entre cada aparición
    private float spawnTimer; // Temporizador para la aparición de enemigos

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
        spawnTimer = spawnInterval; // Inicializa el temporizador
    }

    void Update()
    {
        Comportamiento_Enemigo();
        GestionarAparicionEnemigos();
    }

    public void Comportamiento_Enemigo()
    {
        // Calcula la dirección de movimiento hacia el jugador
        direccionMovimiento = (target.transform.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, target.transform.position) > 15)
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
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.LookRotation(direccionMovimiento); // Apunta hacia la dirección de movimiento
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Attack", false);
                    break;
            }
        }
        else
        {
            // Mantén la posición y rotación actual del enemigo, no cambies su rotación hacia el jugador
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", true);
            transform.Translate(direccionMovimiento * 4 * Time.deltaTime); // Mueve hacia la dirección de movimiento
        }
    }

    void GestionarAparicionEnemigos()
    {
        spawnTimer -= Time.deltaTime; // Reduce el temporizador en el tiempo transcurrido desde el último frame

        if (spawnTimer <= 0f)
        {
            InstanciarEnemigo(); // Llama al método que instancia el enemigo
            spawnTimer = spawnInterval; // Reinicia el temporizador
        }
    }

    void InstanciarEnemigo()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation); // Instancia el enemigo en la posición y rotación del spawner
    }
}







