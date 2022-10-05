using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala3 : MonoBehaviour
{
    public float Speed;
    private GameManagerController gameManager;
    private Rigidbody2D rb;
    public float velocity = 20;
     SpriteRenderer sr;
    // Start is called before the first frame update

   public void SetRightDirection(){
        Speed = velocity;
    }
    public void SetLeftDirection(){
        Speed = -velocity;
    }


    void Start()
    {
       gameManager = FindObjectOfType<GameManagerController>();
       sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        sr.flipX=true;
        rb.velocity = new Vector2(Speed,0);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Enemy" ){
           // Destroy(other.gameObject);
            Destroy(this.gameObject);
           // gameManager.GanarPuntos(10);
            
           
        }
    }
     
}
