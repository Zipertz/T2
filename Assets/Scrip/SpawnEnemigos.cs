using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 100;
    private float counter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;

        if(counter >= interval){
            counter = 0;
            Instantiate(enemyPrefab, transform.position,transform.rotation);
            Destroy(this.gameObject,5);
        }
    }
}


