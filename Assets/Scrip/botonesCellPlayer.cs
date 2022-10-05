using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class botonesCellPlayer : MonoBehaviour
{

    public float JumpForce = 5;
    public float velocity = 0;
    public float defaultVelocity=14;

    private int escalable = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public GameObject bullet;
    private GameManagerController gameManager;
    private Vector3 lastCheckPointPosition;


     Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CAMINAR = 1;
    const int ANIMATION_CORRER = 2;
    const int ANIMATION_ATACAR = 3;
    const int ANIMATION_Saltar = 4;
    const int ANIMATION_MUERTE = 5;
    const int ANIMATION_DESLIZAR = 6;
    const int ANIMATION_ESCALAR = 7;

    int aux = 0;
    int aux1 = 0;
    int aux2 = 0;


    public AudioClip jumpclip;
    public AudioClip ComerHongoclip;
    public AudioClip coin;
    AudioSource audioSource;




         
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManagerController>();   
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }


    private void Movimiento()
    {
        Walk();
        
    }


    private void Walk()
    {
        rb.velocity = new Vector2(velocity,rb.velocity.y);
        if(velocity < 0)
            sr.flipX = true;

        if(velocity > 0)
            sr.flipX = false;
    }

    public void MoverDerecha()
    {
        ChangeAnimation(ANIMATION_CAMINAR);
        velocity = defaultVelocity;
        

    }

    public void MoverIzquierda()
    {
        ChangeAnimation(ANIMATION_CAMINAR);
          velocity = -defaultVelocity;
        
           
    }

    public void Quieto()
    {
        ChangeAnimation(ANIMATION_QUIETO);  
        velocity=0;
    }


    public void Saltar()
    {
        audioSource.PlayOneShot(jumpclip);
        ChangeAnimation(ANIMATION_Saltar);
        if(aux < 2)
        {
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            aux++;
        }
        
    }


    public void atacar()
    {
        if(aux1 < 5){
            var game = FindObjectOfType<GameManagerController>();
                //Crear escudo
                if(sr.flipX == false){
                
                    
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(bullet,
                                    shieldPosition,
                                    Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<bala>();
                    controller.SetRightDirection(); 
                    game.perderBala(5);
                    aux1++;
                }
                if(sr.flipX==true){
                    
                    
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(bullet,
                                    shieldPosition,
                                    Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<bala>();
                    controller.SetLeftDirection(); 
                    game.perderBala(5);
                    aux1++;
                }
         
        }



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
