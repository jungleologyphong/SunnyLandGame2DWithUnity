using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ShopItem : MonoBehaviour
{
    private EnemyScripts enemyScripts;
    public Text TXTGoldInShop;
    public Button BTNGun1, BTNGun2, BTNGun3, BTNGun4;

    public static ShopItem instance;
    public List<int> listItemsGuns;
    private const string HIGH_GOLD = "HIGH GOLD";
    private const string CHECKED_BOUTGHT_ITEM1 = "CHECKED_BOUTGHT_ITEM1";
    private const string CHECKED_BOUTGHT_ITEM2 = "CHECKED_BOUTGHT_ITEM2";
    private const string CHECKED_BOUTGHT_ITEM3 = "CHECKED_BOUTGHT_ITEM3";
    private const string CHECKED_BOUTGHT_ITEM4 = "CHECKED_BOUTGHT_ITEM4";
    void Awake(){
         _MakeInstance();
    }
    void Start()
    {
        enemyScripts = gameObject.GetComponentInParent<EnemyScripts>();
        TXTGoldInShop.text = ""+GoldManager.instance.GetHighScore();

        List<int> listItemsGuns = new List<int>();

        if(GetBoutghtItem1() == 1){
            BTNGun1.interactable = false;
        }

        if(GetBoutghtItem2() == 1){
            BTNGun2.interactable = false;
        }

        if(GetBoutghtItem3() == 1){
            BTNGun3.interactable = false;
        }

        if(GetBoutghtItem4() == 1){
            BTNGun4.interactable = false;
        }
    }

    public void _MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    public void OnClickExitShopItem(){
        SceneManager.LoadScene("MainScene");
        int resultGold = Int32.Parse(TXTGoldInShop.text);
        SetHighScore(resultGold);
    }

    public void OnClickTranscendent(){
        int totalGold = Int32.Parse(TXTGoldInShop.text);
        if(totalGold < 1000){
            BTNGun1.interactable = false;
        }else{
            BTNGun1.interactable = true;
            TXTGoldInShop.text =  ""+ (totalGold - 1000);
            listItemsGuns.Add(1);
            SetBoughtItem1(1);
            int resultGold = Int32.Parse(TXTGoldInShop.text);
            SetHighScore(resultGold);
        }
    }

    public void OnClickLegendary(){
        int totalGold = Int32.Parse(TXTGoldInShop.text);
        
        if(totalGold < 500){
            BTNGun2.interactable = false;
        }else{
            BTNGun2.interactable = true;
            TXTGoldInShop.text =  ""+ (totalGold - 500);
            listItemsGuns.Add(2);
            SetBoughtItem2(1);
            int resultGold = Int32.Parse(TXTGoldInShop.text);
            SetHighScore(resultGold);
        }
    }

    public void OnClickMythic(){
        int totalGold = Int32.Parse(TXTGoldInShop.text);
        
        if(totalGold < 500){
            BTNGun3.interactable = false;
        }else{
            BTNGun3.interactable = true;
            TXTGoldInShop.text =  ""+ (totalGold - 500);
            listItemsGuns.Add(3);
            SetBoughtItem3(1);
            int resultGold = Int32.Parse(TXTGoldInShop.text);
            SetHighScore(resultGold);
        }
    }

    public void OnClickEpic(){
        int totalGold = Int32.Parse(TXTGoldInShop.text);
        
        if(totalGold < 500){
            BTNGun4.interactable = false;
        }else{
            BTNGun4.interactable = true;
            TXTGoldInShop.text =  ""+ (totalGold - 500);
            listItemsGuns.Add(4);
            SetBoughtItem4(1);
            int resultGold = Int32.Parse(TXTGoldInShop.text);
            SetHighScore(resultGold);
        }
    }

    public void SetHighScore(int gold){
        PlayerPrefs.SetInt(HIGH_GOLD,gold);
    }

    public int GetHighScore(){
        return PlayerPrefs.GetInt(HIGH_GOLD);
    }

    public void SetBoughtItem1(int checkedInt){
        PlayerPrefs.SetInt(CHECKED_BOUTGHT_ITEM1,checkedInt);
    }

    public int GetBoutghtItem1(){
        return PlayerPrefs.GetInt(CHECKED_BOUTGHT_ITEM1);
    }

    public void SetBoughtItem2(int checkedInt){
        PlayerPrefs.SetInt(CHECKED_BOUTGHT_ITEM2,checkedInt);
    }

    public int GetBoutghtItem2(){
        return PlayerPrefs.GetInt(CHECKED_BOUTGHT_ITEM2);
    }

    public void SetBoughtItem3(int checkedInt){
        PlayerPrefs.SetInt(CHECKED_BOUTGHT_ITEM3,checkedInt);
    }

    public int GetBoutghtItem3(){
        return PlayerPrefs.GetInt(CHECKED_BOUTGHT_ITEM3);
    }

    public void SetBoughtItem4(int checkedInt){
        PlayerPrefs.SetInt(CHECKED_BOUTGHT_ITEM4,checkedInt);
    }

    public int GetBoutghtItem4(){
        return PlayerPrefs.GetInt(CHECKED_BOUTGHT_ITEM4);
    }
}
