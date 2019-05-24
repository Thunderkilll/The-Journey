using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{

    public float speed = 0f;
    public float distance = 3f;
    public Transform target;
    public int damage = 2;
    public Image imageUiHealth;
    public GameObject Gameover;
    private Scene scene;
    private PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position ,  target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //MoveToward(from , to , speed);
            if (Vector2.Distance(transform.position, target.position) <= 0.5)
            {
                Debug.Log("player damaged /  health --");
                if (imageUiHealth.fillAmount > 0)
                {
                    imageUiHealth.fillAmount -=  (float)damage / 100;
                }
                else
                {
                    restartGameAfterDeath();
                }
                
            }
        }
        
    }
    void restartGameAfterDeath()
    {

        //turn this game ver to true )

        Gameover.SetActive(true); //open the UI of gameover 
                                        //be able to restart after a time 

        // timeStamp = Time.time + cooldownSecs; //just a small cooldown 
        StartCoroutine(Waiting()); //waiting for some secs 


    }

    IEnumerator Waiting()
    {
        PlayerMovement.scoreGim = 0;
        Debug.Log("restart game 1 " );
        yield return new WaitForSeconds(10f);
        Debug.Log(scene.buildIndex);
        SceneManager.LoadScene(scene.buildIndex); //reload active scene 
        Debug.Log("restart game 2 ");
     
    }
    public void dodamage()
    {
        //health -= damage;
        Debug.Log("damage  player !!" );
        HealthBarSystem healthBarSystem = new HealthBarSystem();
        healthBarSystem.HealthDamage(damage);
         Debug.Log("damage  player !!  " + damage );
    }
}
