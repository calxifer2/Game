using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    public GameObject[] enemigos1;
    public Vector2 posiciones;
    public int CuantosEnemigos1;

    void Start()
    {
        CrearEnemigos();
    }

    void Update()
    {
        //GetComponent<Animation>().Play("Armature|ArmatureAction");
    }

    void CrearEnemigos()
    {
        for (int i = 0; i < CuantosEnemigos1; i++)
        {
            Instantiate(enemigos1[Random.Range(0, enemigos1.Length)],
            new Vector3(Random.Range(-posiciones.x, posiciones.x), 0, Random.Range(-posiciones.y, posiciones.y)) + transform.position,
            Quaternion.identity,
            transform
            );
        }
    }

}
