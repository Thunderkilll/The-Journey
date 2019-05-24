using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
    
    public float cooldownSecs ;
    //UI
    public GameObject gameover;
    public GameObject LoadingScreen;
    //   AudioSource footsteps;
    public Animator animator;
    public float runSpeed = 40f;
    
    private float timeStamp ; //time stamp for delay purpouses 
    float horizontalMove = 0f;
    public bool death = false;
    public bool isGameOver = false;
    bool jump = false;
    bool crouch = false;
    public static float scoreGim = 0;
    // player health 
    public int health = 100;
    
    public List<float> volumes;
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        if(!death)
        {
            horizontalMove = joystick.Horizontal * runSpeed;

            if (joystick.Horizontal >= .2f)
            {
                horizontalMove = runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
                //  footsteps.Play();



            }
            else if (joystick.Horizontal <= -.2f)
            {
                horizontalMove = -runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));




            }
            else
            {
                horizontalMove = 0f;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            }

            //
            float verticalMove = joystick.Vertical;

            if (verticalMove >= .3f)
            {
                jump = true;
                animator.SetBool("IsJumping", true);

            }

            if (verticalMove <= -.3f)
            {
                animator.SetBool("IsCrouching", true);
            }
            else
            {
                animator.SetBool("IsCrouching", false);
            }

        }
        else
        {
            Debug.Log("You are dead");
            gameover.SetActive(true);
        }

    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

 

    void FixedUpdate()
    {
        // Move our character
         controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
         jump = false;
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
      
        if(col.tag == "Death")
        {

            restartGameAfterDeath(); //restart game 
        }
        if (col.tag == "EndLevel")
        {

            //load NextScene()
            loadNextScene();
        }
        if (col.tag == "pickUp")
        {
            Destroy(col.gameObject);
            
        }
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spikes")
        {



            restartGameAfterDeath();

            Debug.Log("player death");


        }
     

        if (other.gameObject.tag == "crystal")
        {
         

            //collecting crystal
            // add +1 to score 
            // sound of getting the cristal 
            // destroy object
            animator.SetBool("IsCollecting", true);
            Destroy(other.gameObject);
            scoreGim++;
            Debug.Log("cristal +1 : " + scoreGim);
            StartCoroutine(animationdelay(other));
           


        }
        else
        {
            animator.SetBool("IsCollecting", false);
        }

       if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("got Hit by enemy" + other.gameObject.name);
            //other.gameObject.GetComponent<Ennemy>().dodamage(health);

        } 
    }
      
  void restartGameAfterDeath()
    {
       
        isGameOver = true; //turn this game ver to true )
         
        gameover.SetActive(isGameOver); //open the UI of gameover 
                                        //be able to restart after a time 

       // timeStamp = Time.time + cooldownSecs; //just a small cooldown 
        StartCoroutine(Waiting()); //waiting for some secs 
       
       
    }

    IEnumerator Waiting()
    {
        scoreGim = 0;
        Debug.Log("restart game 1 " + timeStamp);
        yield return new WaitForSeconds(10f);
        Debug.Log(scene.buildIndex);
        SceneManager.LoadScene(scene.buildIndex); //reload active scene 
        Debug.Log("restart game 2 " + timeStamp);
        cooldownSecs = 100f;
    }


    void loadNextScene()
    {
        //set active load scene for quiet some time 
        //load next scene 
        LoadingScreen.SetActive(true);
        //use cooldown 
        StartCoroutine(loadingWait()); //waiting for some secs 
    }

    //loadingwait
    IEnumerator loadingWait()
    {
        scoreGim = 0;
        Debug.Log("loading next level  " );
        yield return new WaitForSeconds(1);
        // LoadingScreen.SetActive(false);
        SceneManager.LoadScene(scene.buildIndex + 1); //load next  scene 
        
        
    }
    IEnumerator animationdelay(Collision2D other)
    {
        
        yield return new WaitForSeconds(10);
        animator.SetBool("IsCollecting", false);
        

    }
}
