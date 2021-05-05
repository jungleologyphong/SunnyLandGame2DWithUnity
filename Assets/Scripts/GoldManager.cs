using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    private const string HIGH_SCORE = "HIGH SCORE";
    public Text TXTGoldInMainScene;
    void Awake(){
        _MakeInstance();
    }
    void Start()
    {   
        TXTGoldInMainScene.text = ""+ShopItem.instance.GetHighScore();
    }
    void _MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }
    public void SetHighScore(int score){
        PlayerPrefs.SetInt(HIGH_SCORE,score);
    }
    public int GetHighScore(){
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
