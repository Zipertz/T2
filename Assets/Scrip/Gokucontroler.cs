using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gokucontroler : MonoBehaviour
{

 Animator animator;
Rigidbody2D rb;
SpriteRenderer sr;
private float gravityScale;

public int velocity = 10;
private bool tieneNuve = false;
private float defaultGravity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();   
        animator = GetComponent<Animator>(); 
        defaultGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
                
        
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x,0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
           sr.flipX = false;
            
            
            
        }
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            
             
            
           
           sr.flipX = true;
          
        }
        
        if(Input.GetKey(KeyCode.UpArrow) && tieneNuve){


            rb.velocity = new Vector2(rb.velocity.x,velocity);

            }

        if(Input.GetKey(KeyCode.DownArrow) && tieneNuve){


            rb.velocity = new Vector2(rb.velocity.x,-velocity);

            }    



  



    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Nube"){
            rb.gravityScale = 0;
            tieneNuve = true;
            animator.SetInteger("Estado",1);
          //  SceneManager.LoadScene(1);

        }
    } 

    void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag == "Suelo"){

        rb.gravityScale = defaultGravity;
        tieneNuve = false;
        animator.SetInteger("Estado",0);
        }


    }



}
