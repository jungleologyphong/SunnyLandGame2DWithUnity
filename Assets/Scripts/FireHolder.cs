using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHolder : MonoBehaviour
{
    private SunnyController sunnyController;

    void Start()
    {
        sunnyController = GameObject.FindGameObjectWithTag("Sunny").GetComponent<SunnyController>();        
    }
    void Update()
    {
        transform.Translate(Vector3.down * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Sunny")){
            sunnyController.Damage(1);
        }
    }
}