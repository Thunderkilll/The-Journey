using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator anim;
    private float delayMele = 1f;
    public float delayMagic = 2f;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
 
    }

    public void meleAttack()
    {
        Debug.Log("button attack pushed");
 
        
            
            anim.SetBool("attack", true);

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);//circle invisible pour connaitres les enemies who are attacking me and deal them damage later
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {//looop throughout all the enemies found inside the circle range
                enemiesToDamage[i].GetComponent<Ennemy>().TakeDamage(damage);
            }
            
 
            StartCoroutine(Waiting());
           
        


    }
   
    public void MagicAttack()
    {
        Debug.Log("button attack pushed");



        anim.SetBool("Ismagic", true);
        StartCoroutine(Waiting1());

    }
    IEnumerator Waiting()
    {
        Debug.Log("time " + Time.time);
        yield return new WaitForSeconds(delayMele);
        Debug.Log("time " + Time.time);
        anim.SetBool("attack", false);
    }
    IEnumerator Waiting1()
    {
        Debug.Log("time magic " + Time.time);
        yield return new WaitForSeconds(delayMagic);
        Debug.Log("time magic" + Time.time);
        anim.SetBool("Ismagic", false);
    }
}
