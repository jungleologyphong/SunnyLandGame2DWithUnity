using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeverRegister : MonoBehaviour
{
    [SerializeField] InputField newUsername;
    [SerializeField] InputField newPassword;
    [SerializeField] InputField rePassword;
    [SerializeField] Button btnCancel;
    [SerializeField] Button btnRegister;
    [SerializeField] Text errorMessage;
    [SerializeField] string url;
    [SerializeField] GameObject panel;
    WWWForm form;

    public void OnRegisterButtonClicked(){
        btnRegister.interactable = false;
        StartCoroutine(Register());
    }  

    public void OnCancelButtonClicked(){
        SceneManager.LoadScene("LoginScene");
    }


    IEnumerator Register(){
        form = new WWWForm();

        form.AddField("newUsername", newUsername.text);
        form.AddField("newPassword", newPassword.text);
        form.AddField("rePassword", rePassword.text);

        WWW w = new WWW(url, form);
        yield return w;

        if(w.error != null){
            errorMessage.text = "404 Not Found";
        }else{
            if(w.isDone){
                if(w.text.Contains("error")){
                    panel.SetActive(true);
                    if(newUsername.text == ""){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Username";
                    }
                    if(newPassword.text == ""){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Password";
                    }
                    if(rePassword.text == ""){
                        panel.SetActive(true);
                        errorMessage.text = "Please enter the Password";
                    }

                    if(newPassword.text != rePassword.text){
                        panel.SetActive(true);
                        errorMessage.text = "Invalid Password !";
                    }else{
                        if(newPassword.text == rePassword.text){
                        SceneManager.LoadScene("LoginScene");
                        }
                    }
                }else{
                    SceneManager.LoadScene("LoginScene");
                }
            }
        }
        btnRegister.interactable = true;
    } 
}
