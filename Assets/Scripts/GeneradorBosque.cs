using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBosque : MonoBehaviour
{

    public GameObject[] arboles;
    public Vector2 posiciones;
    public int CuantosArboles;

    public GameObject[] rocas;
    public Vector2 posicionesRocas;
    public int CuantasRocas;

    void Start()
    {
        CrearArboles();
        CrearRocas();
    }

    void CrearArboles()
    {
        for(int i = 0; i < CuantosArboles; i++)
        {
            Instantiate(arboles[Random.Range(0, arboles.Length)],
            new Vector3(Random.Range(-posiciones.x, posiciones.x), 0, Random.Range(-posiciones.y, posiciones.y)) + transform.position,
            Quaternion.identity,
            transform
            );
        }
    }

    void CrearRocas()
    {
        for (int i = 0; i < CuantasRocas; i++)
        {
            Instantiate(rocas[Random.Range(0, rocas.Length)],
            new Vector3(Random.Range(-posiciones.x, posiciones.x), 0, Random.Range(-posiciones.y, posiciones.y)) + transform.position,
            Quaternion.identity,
            transform
            );
        }
    }

}
