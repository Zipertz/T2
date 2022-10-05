using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class BanderaSinMonedas : MonoBehaviour
{


    [SerializeField] private int cantidadMonedas;
    [SerializeField] private int MonedasEliminados;
    // Start is called before the first frame update
    void Start()
    {
        cantidadMonedas = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void MonedasEliminado()
    {
        MonedasEliminados +=1;
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")&& MonedasEliminados == cantidadMonedas)
        {
            SceneManager.LoadScene(1);
        }
        
    }
    
}
