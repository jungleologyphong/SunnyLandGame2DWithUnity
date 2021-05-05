using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeverLogin : MonoBehaviour
{
    [SerializeField] InputField lgusername;
    [SerializeField] InputField lgpassword;

    [SerializeField] Button btnLogin;
    [SerializeField] Button btnRegister;
    [SerializeField] Text errorMessage;
    [SerializeField] string url;
    [SerializeField] GameObject panel;
    WWWForm form;

    public void OnLoginButtonClicked(){
        btnLogin.interactable = false;
        StartCoroutine(Login());
    }  

    public void OnRegisterClicked(){
        SceneManager.LoadScene("RegisterScene");
    }

    IEnumerator Login(){
        form = new WWWForm();

        form.AddField("lgusername", lgusername.text);
        form.AddField("lgpassword", lgpassword.text);

        WWW w = new WWW(url, form);
        yield return w;

        if(w.error != null){
            errorMessage.text = "404 Not Found";
        }else{
            if(w.isDone){
                if(w.text.Contains("error")){
                    panel.SetActive(true);
                    if(lgusername.text == ""){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Username";
                    }
                    if(lgpassword.text == ""){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Password";
                    }
                    if((lgusername.text == "") && (lgpassword.text == "")){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Username & Password";
                    }else{
                        errorMessage.text = "Invalid with Username : "+lgusername.text+" or Password: "+lgpassword.text+" "+w.text;
                    }
                    
                }else{
                    SceneManager.LoadScene("MainScene");
                }
            }
        }
        btnLogin.interactable = true;
    } 
}
