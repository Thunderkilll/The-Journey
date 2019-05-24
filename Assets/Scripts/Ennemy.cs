using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //death animation for enemy
            anim.SetBool("isDead",true);
            Destroy(gameObject);

        }
        else
        {
            anim.SetBool("isDead", false);
        }
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
   public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Take Damage !!");

    }
    /*public void dodamage(int health)
    {
        //health -= damage;
        Debug.Log("damage  player !!"+ health );
        HealthBarSystem healthBarSystem = new HealthBarSystem();
        healthBarSystem.HealthDamage(damage);
    }*/

}
