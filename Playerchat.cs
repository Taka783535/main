using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerchat : MonoBehaviour
{
    //チャット入力場所,チャット表示場所
    public GameObject chatfield;
    public GameObject chatpaneltxt;


    //チャットボタンクリックしたら呼ばれる
    //チャットフィールド出現,規定では50文字まで
    public void Getchatfield()
    {
        if (chatfield.activeInHierarchy == false)
        {
            chatfield.SetActive(true);
        }
        else
        {
            chatfield.SetActive(false);
        }
    }

    //入力処理,EndEditイベントで呼ばれる
    public void Getchatcharactor()
    {
      
        //chatxt==チャット入力場所に入力された値,chatpaneltx==チャットパネルのテキストボックス
        Text chattext = chatfield.GetComponentInChildren<Text>();
        string fowardtext = chatpaneltxt.GetComponent<Text>().text;
        chatpaneltxt.GetComponent<Text>().text= fowardtext+gameObject.transform.parent.name+": "+ chattext.text+Environment.NewLine;
        chatfield.GetComponent<InputField>().text = "";
        chatfield.SetActive(false);
    }


}
