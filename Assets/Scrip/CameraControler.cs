using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smooterFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition= target.position + offset;
        var smooterPosition = Vector3.Lerp(transform.position, targetPosition, smooterFactor * Time.fixedDeltaTime);
        transform.position = smooterPosition;
    }
}
