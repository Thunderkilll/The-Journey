using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{

   
    void Start()
    {
        //anim = GetComponent<Animator>();
    }
    public void MeleAttack()
    {
        //wait for couple seconds 
        Debug.Log("mele attacking");
  

    }

    public void MagicAttack()
    {
        Debug.Log("magic attacking");
    }
}
