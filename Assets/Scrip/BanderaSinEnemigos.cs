using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class BanderaSinEnemigos : MonoBehaviour
{


    [SerializeField] private int cantidadEnemigos;
    [SerializeField] private int EnemigosEliminados;
    // Start is called before the first frame update
    void Start()
    {
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemigosEliminado()
    {
        EnemigosEliminados +=1;
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")&& EnemigosEliminados == cantidadEnemigos)
        {
            SceneManager.LoadScene(1);
        }
        
    }
    
}
