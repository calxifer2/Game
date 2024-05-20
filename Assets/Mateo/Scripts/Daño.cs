using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    [SerializeField]
    private int daño;

    // Corrected OnTriggerEnter method with return type 'void'
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemigo")
        {
            other.GetComponent<DatosEnemigo>().vida -= daño;
        }
    }}