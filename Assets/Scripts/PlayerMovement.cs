using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
 

    //   AudioSource footsteps;
    public Animator animator;
    public float runSpeed = 40f;
    public GameObject gameover;

    float horizontalMove = 0f;
    public bool death = false;
    bool jump = false;
    bool crouch = false;
    public static float scoreGim = 0;
    // Start is called before the first frame update
    
    public List<float> volumes;

    void Start()
    { 
        
   
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spikes")
        {
             

            animator.SetBool("IsHit", true);
          
            
            gameover.SetActive(true);
            Debug.Log("player death");
            

        }
        else
        {
            animator.SetBool("IsHit", false);
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
            animator.SetBool("IsCollecting", false);

      
 
        }
    }



 
}
