using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{   public SunnyController sunny;
    void Start()
    {
        sunny = gameObject.GetComponentInParent<SunnyController>();
    }

    void FixedUpdate(){

    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Grounded")){
            sunny.grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Grounded")){
            sunny.grounded = false;
        }
    }
}
