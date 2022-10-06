using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class BanderaSinEnemigos : MonoBehaviour
{


    [SerializeField] private int cantidadEnemigos;
    [SerializeField] private int EnemigosEliminados;
    [SerializeField] private int cantidadMonedas;
    [SerializeField] private int MonedasEliminados;
    // Start is called before the first frame update
    void Start()
    {
        cantidadMonedas = GameObject.FindGameObjectsWithTag("moneda").Length;
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
    }

    public void EnemigosEliminado()
    {
        EnemigosEliminados +=1;
       
    }
    public void MonedasEliminado()
    {
       MonedasEliminados +=1;
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")&& EnemigosEliminados == cantidadEnemigos && MonedasEliminados == cantidadMonedas)
        {
            SceneManager.LoadScene(1);
        }
        
    }
    
}
