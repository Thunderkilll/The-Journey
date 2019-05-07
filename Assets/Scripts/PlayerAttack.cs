using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack ;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Attacking enemy");
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position , attackRange , whatIsEnemies);//circle invisible pour connaitres les enemies who are attacking me and deal them damage later
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {//looop throughout all the enemies found inside the circle range
                    enemiesToDamage[i].GetComponent<Ennemy>().TakeDamage(damage);
                }
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;

        }
        
    }
    public Color gizmoColor = Color.red;
    void onDrawGismoSelected()
    {
        Gizmos.color = Color.red; //couleur cercle gizmos red
        Gizmos.DrawWireSphere(attackPos.position , attackRange);
    }
}
