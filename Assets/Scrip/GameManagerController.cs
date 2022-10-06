using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManagerController : MonoBehaviour
{
    public Text BalasText;
    public Text scoreText;
    public Text livesText;
    public Text EnemigosText;
    public Text Coin1Text;
    public Text Coin2Text;
    public Text Coin3Text;
  
    //balas puntos 

   

    private int enemigos;
     
    
   
    private int score;
    private int lives;
    private int balas;
    //balas variables

    private int coin1;
    private int coin2;
    private int coin3;

    
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        lives=3;
        balas=10;

        enemigos=0;
        

        coin1=0;
        coin2=0;
        coin3=0;
        PrintScreenScore();
        PrintScreenCoin1();
        PrintScreenCoin2();
        PrintScreenCoin3();
        PrintScreenLives();
        PrintScreenEnemigos();
        PrintScoreInScreen();
        
       
        LoadGame();
    }



    public void SaveGame(){
        var filePath = Application.persistentDataPath + "/t2-2.dat";
        FileStream file;

        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else    
            file = File.Create(filePath);

        GameData data = new GameData();
        data.Score = score;
        data.Balas = balas;
        data.Lives = lives;

        data.Enemy = enemigos;

        data.Coin1=coin1;
        data.Coin2=coin2;
        data.Coin3=coin3;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();

    }

    public void LoadGame(){
            var filePath = Application.persistentDataPath + "/t2-2.dat";
        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }
        else    {
            Debug.LogError("No se encontreo archivo");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        //utilizar los datos guardados
        coin1 = data.Coin1;
        coin2 = data.Coin2;
        coin3 = data.Coin3;


         enemigos= data.Enemy;
        score = data.Score;
        balas = data.Balas;
        lives = data.Lives;
        PrintScoreInScreen();
        PrintScreenScore();
        PrintScreenLives();
        PrintScreenCoin1();
        PrintScreenCoin2();
        PrintScreenCoin3();
        
    }


    public int Score(){

        return score;

    }
      public int Lives(){

        return lives;

    }
    public int Enemigos(){

        return enemigos;

    }
   


      public int Balas(){

        return balas;

    }

    public int Coins1(){

        return coin1;

    }
    public int Coins2(){

        return coin2;

    }
    public int Coins3(){

        return coin3;

    }


public void GanarCoin1(int moneda1){
    coin1 += moneda1;
    PrintScreenCoin1();
   }

public void GanarCoin2(int moneda2){

    coin2 += moneda2;
    PrintScreenCoin2();
   }
public void GanarCoin3(int moneda3){

    coin3 += moneda3;
    PrintScreenCoin3();
   }




    
   public void GanarPuntos(int puntos){

    score += puntos;
    PrintScreenScore();
   }
    public void PerderVida( int lives){

    this.lives -=1;
    PrintScreenLives();
    

   }

 



    public void PerderEnemigos(int enemigos){

    this.enemigos +=1;
    PrintScreenEnemigos();
    

   }


    


    public void perderBala(int balas){
     this.balas-=1;
     PrintScoreInScreen();
    }

   
   private void PrintScreenScore(){
        scoreText.text = "Puntaje: " + score;

   }

   private void PrintScreenLives(){
        livesText.text = "Vida: " + lives;

   }

   
    
    private void PrintScreenEnemigos(){
        EnemigosText.text = "Enemigos: " + enemigos;

   }
  
    private void PrintScoreInScreen(){
        BalasText.text = "Balas: " + balas;
    }



    private void PrintScreenCoin1(){
        Coin1Text.text = "Tipo Moneda 1: " + coin1;

   }
    private void PrintScreenCoin2(){
        Coin2Text.text = "Tipo Moneda 2: " + coin2;

   }
    private void PrintScreenCoin3(){
        Coin3Text.text = "Tipo Moneda 3: " + coin3;

   }

   

   
}




