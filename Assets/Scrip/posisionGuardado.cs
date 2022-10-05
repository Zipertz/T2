using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posisionGuardado : MonoBehaviour
{

    public float PosX;
    public float PosY;

    public Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }


public void SavePosition(){


PlayerPrefs.SetFloat("PosicionX",transform.position.x);
PlayerPrefs.SetFloat("PosicionY",transform.position.y);
Debug.Log("Datos Guardados");


}


public void LoadData(){

    PosX = PlayerPrefs.GetFloat("PosicionX");
    PosY = PlayerPrefs.GetFloat("PosicionY");
    Position.x = PosX;
    Position.y = PosY;
    transform.position = Position;
    Debug.Log("Datos Cargados");

}

void OnTriggerEnter2D(Collider2D Guardar) {
    
if(Guardar.CompareTag ("GuardarPocicion")){
    
    SavePosition();


}


}



    // Update is called once per frame
  
}
