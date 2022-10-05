using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class Payer : MonoBehaviour
{
    public float JumpForce = 5;
    public float velocity = 10;
    public float vcorrer = 20;

private float defaultGravity;
   
    public AudioClip jumpclip;
    public AudioClip ComerHongoclip;
    public AudioClip coin;
    AudioSource audioSource;

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;

    private float  tiempoPresionado=0;
   private float  tiempoPresionado1=0;


    Rigidbody2D rb;
    public BoxCollider2D platformGround;
    private int escalable = 0;
    private Transform tras;

    public static bool growUp;

    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CAMINAR = 1;
    const int ANIMATION_CORRER = 2;
    const int ANIMATION_ATACAR = 3;
    const int ANIMATION_Saltar = 4;
    const int ANIMATION_MUERTE = 5;
    const int ANIMATION_DESLIZAR = 6;
    const int ANIMATION_ESCALAR = 7;
    //bool puedeSaltar = false;
    int aux = 0;
    int aux1 = 0;
    int aux2 = 0;
    private GameManagerController gameManager;
    private Vector3 lastCheckPointPosition;
    // Start is called before the first frame update
    void Start()
    {
    
        gameManager = FindObjectOfType<GameManagerController>();   
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        platformGround =  GetComponent<BoxCollider2D>();
       growUp= false;
       defaultGravity = rb.gravityScale;
       // transformScala = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(ANIMATION_QUIETO);  
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
           sr.flipX = false;
            
            ChangeAnimation(ANIMATION_CAMINAR);
            
        }
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            
            
            
           
           sr.flipX = true;
           ChangeAnimation(ANIMATION_CAMINAR);
        }

       if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            
          rb.velocity = new Vector2(-vcorrer, rb.velocity.y);
            sr.flipX = true;
            
            ChangeAnimation(ANIMATION_CORRER);
        }

         if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(vcorrer, rb.velocity.y);
            sr.flipX = false;
            
            ChangeAnimation(ANIMATION_CORRER);
        }

        


    if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.N))
        {
            
          rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            
            ChangeAnimation(ANIMATION_DESLIZAR);
        }

         if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.N))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            
            ChangeAnimation(ANIMATION_DESLIZAR);
        }





         

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeAnimation(ANIMATION_ATACAR);
           

        }
        if (escalable == 1)
            {
                    
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
			          
                       
                        rb.velocity = new Vector2(rb.velocity.x, 5);
                        rb.gravityScale = 0;
                        
                        platformGround.enabled = false;
                       
                        ChangeAnimation( ANIMATION_ESCALAR);
                    }
                    

                    else if (Input.GetKey(KeyCode.DownArrow))
                    {
			            rb.gravityScale = 0;
                        rb.velocity = new Vector2(rb.velocity.x, -5);
                        ChangeAnimation( ANIMATION_ESCALAR);
                        
                    }
                   
                    
                    
                        escalable = 0;
                        platformGround.enabled = true;
                    
                       
                    
            }
            if( escalable == 0)
            {
                   
                    rb.gravityScale = defaultGravity;
                    
            }
                
       
              else if(aux==1){
                ChangeAnimation(ANIMATION_Saltar);
            } 

    

          if (Input.GetKeyDown(KeyCode.Space)  && aux<2)
        {
            audioSource.PlayOneShot(jumpclip);
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_Saltar);
            aux++;

           
        }
       
   
       
        if (Input.GetKeyDown(KeyCode.P)){

         animator.SetTrigger("Muerto");
         
       }

// Bala cargada 1
        if (Input.GetKey(KeyCode.C)  ){

           
           tiempoPresionado += Time.deltaTime;
            Debug.Log(tiempoPresionado);
        }
   
        if (Input.GetKeyUp(KeyCode.C)&& aux1<10)
             {
                
                if(tiempoPresionado < 3)
                {
                    var game = FindObjectOfType<GameManagerController>();
            //Crear escudo
               if(sr.flipX == false){
               
                
                var shieldPosition = transform.position + new Vector3(1,0,0);
                var gb = Instantiate(bullet,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala>();
                controller.SetRightDirection(); 
                game.perderBala(10);
                aux1++;
             }
             if(sr.flipX==true){
                
                
                var shieldPosition = transform.position + new Vector3(-1,0,0);
                var gb = Instantiate(bullet,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala>();
                controller.SetLeftDirection(); 
                game.perderBala(10);
                aux1++;
             }
                }
            
            if(tiempoPresionado > 5)
                {
                    RealseCarge3();
                }
               tiempoPresionado = 0;
                
             }

          



// Bala cargada 2
        if (Input.GetKey(KeyCode.D)  ){

           
           tiempoPresionado1 += Time.deltaTime;
        
        }
   
        if (Input.GetKeyUp(KeyCode.D) && tiempoPresionado1 >=2)
             {
                RealseCarge3();
                
                
             }

        if (Input.GetKeyUp(KeyCode.D) && tiempoPresionado1 <2 ){

           
           tiempoPresionado1 += Time.deltaTime;
        
             } 
       
     




    }

     void RealseCarge ()
     {

                var game = FindObjectOfType<GameManagerController>();
            //Crear escudo
               if(sr.flipX == false){
               
                
                var shieldPosition = transform.position + new Vector3(1,0,0);
                var gb = Instantiate(bullet2,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala2>();
                controller.SetRightDirection(); 
                game.perderBala(5);
                aux1++;
                
             }
             if(sr.flipX==true){
                
                
                var shieldPosition = transform.position + new Vector3(-1,0,0);
                var gb = Instantiate(bullet2,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala2>();
                controller.SetLeftDirection(); 
                game.perderBala(5);
                aux1++;
               
             }
            
             tiempoPresionado=0;

     }
 
    
     void RealseCarge3 ()
     {

                var game = FindObjectOfType<GameManagerController>();
            //Crear escudo
               if(sr.flipX == false){
               
                
                var shieldPosition = transform.position + new Vector3(1,0,0);
                var gb = Instantiate(bullet3,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala3>();
                controller.SetRightDirection(); 
                game.perderBala(10);
                aux1++;
                
             }
             if(sr.flipX==true){
                
                
                var shieldPosition = transform.position + new Vector3(-1,0,0);
                var gb = Instantiate(bullet3,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala3>();
                controller.SetLeftDirection(); 
                game.perderBala(10);
                aux1++;
               
             }
            tiempoPresionado1=0;
            

     }

    void OnCollisionEnter2D(Collision2D other)
    {
        //puedeSaltar = false;
        aux=0;
        if ((other.gameObject.tag == "Enemy")&& aux2<3)
        {
           
            animator.SetTrigger("Muerto");
            gameManager.PerderVida(3);

             aux2++;
            if(aux2 == 3)
            {
                
                
                SceneManager.LoadScene(1);
            }
           ChangeAnimation(ANIMATION_MUERTE) ;
           
        }
        if (other.gameObject.name== "DarkHole" && aux2<3)
        {
            gameManager.PerderVida(3);
            if (lastCheckPointPosition !=null)
            {
                transform.position = lastCheckPointPosition;
            }
            aux2++;
            if(aux2 == 3)
            {
                
                
                SceneManager.LoadScene(1);
            }
        }
        if (other.gameObject.name == "Hongo"){
            
            audioSource.PlayOneShot(ComerHongoclip);
            Destroy(other.gameObject);
            
        } 
       
    }



     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Onco");
        if(other.gameObject.name == "Flecha_Cpoint"){
        lastCheckPointPosition = transform.position;
         }
        if(other.gameObject.name == "Cartel_Cpoint"){
            lastCheckPointPosition = transform.position;
        }


        if(other.gameObject.tag == "moneda" ){
            audioSource.PlayOneShot(coin);
            Destroy(other.gameObject);
            gameManager.GanarCoin1(1);
            gameManager.GanarPuntos(10);
            

        }
         if(other.gameObject.tag == "moneda2" ){
            audioSource.PlayOneShot(coin);
            Destroy(other.gameObject);
            gameManager.GanarCoin2(1);
            gameManager.GanarPuntos(20);
            

        }
         if(other.gameObject.tag == "moneda3" ){
            audioSource.PlayOneShot(coin);
            Destroy(other.gameObject);
            gameManager.GanarCoin3(1);
            gameManager.GanarPuntos(30);
            
        }
        if (other.gameObject.tag == "final")    
        {
           
           
           
            gameManager.SaveGame();
           
           
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Escalera")
        {
            escalable = 1;
        }
         
    }



    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
    private void cambioAnimation(bool anima)
    {
        animator.SetBool("puedeSaltar", anima);


    }


 
}

    
