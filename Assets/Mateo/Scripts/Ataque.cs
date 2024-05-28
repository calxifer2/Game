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
        Filo.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void OnAttackButtonPressed()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            swordAnimator.SetTrigger("Sword");
            Filo.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(EndAttack());
        }
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Filo.GetComponent<BoxCollider>().isTrigger = false;
        isAttacking = false;
    }
}