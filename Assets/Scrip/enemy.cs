using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 5;
    const int ANIMATION_CAMINAR = 1;
 private GameManagerController gameManager;
 private BanderaSinEnemigos baderas;
 
    private Rigidbody2D rb; // Cuerpo �f�sico� de los enemigos
    private int direction;
    private int cont1 = 0;
    private int cont2 = 0;
    private float  tiempoPresionado=0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        baderas = FindObjectOfType<BanderaSinEnemigos>();
      
    }

    // Update is called once per frame
    void Update()
    {   tiempoPresionado += Time.deltaTime;
        rb.velocity = new Vector2 (-velocity,0);
        ChangeAnimation(ANIMATION_CAMINAR);
        

    }
    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Player" ){
          
        }

         if (other.gameObject.tag == "Bala")
        {
            cont1++;
            if (cont1 == 2)
            {
                Destroy(this.gameObject);
                gameManager.PerderEnemigos(5);
                gameManager.GanarPuntos(10);
                baderas.EnemigosEliminado();
            }
        }


         if (other.gameObject.tag == "Bala3")
        {
            cont2=cont2+2;
            if (cont2 >= 2)
            {
                Destroy(this.gameObject);
                gameManager.PerderEnemigos(5);
                gameManager.GanarPuntos(10);
                baderas.EnemigosEliminado();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "loopEnemigoIzquierda"){
            velocity *= -1;
            ChangeAnimation(ANIMATION_CAMINAR);
            sr.flipX = false;    


        }
        if(other.gameObject.tag == "loopEnemigoDerecha"){
            velocity *= -1;
            ChangeAnimation(ANIMATION_CAMINAR);
              sr.flipX = true;  

        }
        if(other.gameObject.tag == "pinchos"){
               
            Destroy(this.gameObject);

        }

       
    }

   
}

