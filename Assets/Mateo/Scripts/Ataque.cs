using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F))
    {
        gameObject.GetComponent<Animator>().SetTrigger("Sword");
    }
  }
}
