using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ataque : MonoBehaviour
{
    public GameObject Filo;
    public Animator swordAnimator;

    private bool isAttacking = false;

    void Start()
    {
        if (Filo != null)
        {
            Filo.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            Debug.LogError("Filo no está asignado en el inspector.");
        }

        if (swordAnimator == null)
        {
            Debug.LogError("swordAnimator no está asignado en el inspector.");
        }
    }

    public void OnAttackButtonPressed()
    {
        if (!isAttacking)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                if (swordAnimator != null)
                {
                    swordAnimator.SetTrigger("Sword");
                }

                if (Filo != null)
                {
                    Filo.GetComponent<BoxCollider>().isTrigger = true;
                }

                StartCoroutine(EndAttack());
            }
        }
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f);
        if (Filo != null)
        {
            Filo.GetComponent<BoxCollider>().isTrigger = false;
        }
        isAttacking = false;
    }
}