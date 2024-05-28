using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaEnemigo : MonoBehaviour
{
    public int hp;
    public int dañoArma;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            if (anim != null)
            {
                anim.Play("color");
            }

            hp -= dañoArma;

           
        }
         if (hp <= 0)
            {
                Destroy(gameObject);
            }
    }
}
