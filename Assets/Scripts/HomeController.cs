using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeController : MonoBehaviour
{
    public void OnClickGameButton(){
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickShopButton(){
        SceneManager.LoadScene("ShopItem");
    }

    public void OnClickExitButton(){
        Application.Quit();
    }
}
