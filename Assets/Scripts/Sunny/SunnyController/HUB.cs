using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public Sprite[] HeartSprites;
    
    public Image HeartUI;

    private SunnyController sunny;

    void Start(){
        sunny = GameObject.FindGameObjectWithTag("Sunny").GetComponent<SunnyController>();
    }
    void Update(){
        HeartUI.sprite = HeartSprites[sunny.currentHealth];
    }
}
