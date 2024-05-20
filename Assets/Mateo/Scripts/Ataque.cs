using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject Filo;


    void Start()
    {
        Filo.GetComponent<BoxCollider>().isTrigger = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Sword");
            Filo.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(finAtaque());
        }
    }
    IEnumerator finAtaque()
    {
        yield return new WaitForSeconds(0.5f);
    Filo.GetComponent<BoxCollider>().isTrigger = false;
    }
}
