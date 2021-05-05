using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FX : MonoBehaviour
{
    public Animator animCherry;
    public bool dieFX = true;
    public Text txtGold;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip pingClip;
    void Start(){
        animCherry = gameObject.GetComponent<Animator>(); 
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Sunny")){
            animCherry.SetBool("Die", dieFX);
            int parseString = Int32.Parse(txtGold.text);
            int totalGold = parseString + 100;
            txtGold.text = ""+totalGold;
            audioSource.PlayOneShot(pingClip);
            StartCoroutine("Destroy");
        }
    }

     IEnumerator Destroy(){
        yield return new WaitForSeconds(1);
        DestroyCherry();
    }

    void DestroyCherry(){
        Destroy(gameObject);
    }
}
