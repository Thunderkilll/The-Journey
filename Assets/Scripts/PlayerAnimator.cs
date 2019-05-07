using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
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
      
                anim.SetBool("attack", true);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);//circle invisible pour connaitres les enemies who are attacking me and deal them damage later
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {//looop throughout all the enemies found inside the circle range
                    enemiesToDamage[i].GetComponent<Ennemy>().TakeDamage(damage);
                }
           
             //   anim.SetBool("attack", false);
      
      



    }
    public void stopMeleAttack()
    {
        Debug.Log("stop mele attacking --");
        anim.SetBool("attack", false);
    }
}
