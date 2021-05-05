using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{      
    [SerializeField] GameObject rowPlayer;
    [SerializeField] GameObject panel;
    [SerializeField] Button btnLeaderBoard, btnCloseLeaderBoard;
    [SerializeField] string URL;
    [SerializeField] string checkText;

    public void OnButtonLeaderBoardClicked(){
        if(checkText == btnLeaderBoard.transform.Find("TXTLeaderBoard").GetComponent<Text>().text){
            panel.SetActive(true);
        }

        if(checkText != btnLeaderBoard.transform.Find("TXTLeaderBoard").GetComponent<Text>().text){
            panel.SetActive(true);
            StartCoroutine(ConnectDataBase()); 
        }
    }
    public void OnInteractableButtonClicked(){
        btnLeaderBoard.interactable = false;      
    }

    public void OnCloseLeaderBoard(){
        btnLeaderBoard.transform.Find("TXTLeaderBoard").GetComponent<Text>().text = "LeaderBoard!";
        panel.SetActive(false);
        btnLeaderBoard.interactable = true;   
    }

    IEnumerator ConnectDataBase(){
        WWWForm form = new WWWForm();
        form.AddField("ldboard", "LeaderBoard");
        WWW w = new WWW(URL,form);
        yield return w;
        string data = w.text;
        string[] listData = new string[]{};
        listData = data.Split(',');
        for(int i=0; i< (listData.Length)-1; i++) {
            string row = listData[i]  ; 
            string[] b = new string[]{};
            b = row.Split('-');
            GameObject gameObject = (GameObject)Instantiate(rowPlayer);
            gameObject.transform.SetParent(this.transform);
            gameObject.transform.Find("PlayerName").GetComponent<Text>().text=b[1];
            gameObject.transform.Find("Points").GetComponent<Text>().text=b[4];
        }
    }
}
