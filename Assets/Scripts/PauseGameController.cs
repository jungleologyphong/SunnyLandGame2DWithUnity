using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameController : MonoBehaviour
{
    [SerializeField] GameObject panelPauseGame;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            panelPauseGame.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnClickPlayButton(){
        panelPauseGame.SetActive(false);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void OnClickHomeButton(){
        SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1;
    }
}
