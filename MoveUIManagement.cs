using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUIManagement : MonoBehaviour
{
    //UIの画面遷移を統括するクラス

    public GameObject canvas;　　　　//HPバー等が配置された通常のキャンバス
    public GameObject maincanvas;　　//装備やアイテム等のメニュー選択キャンバス
    public GameObject itemcanvas;    //アイテムバッグのUIが配置されたキャンバス
    public GameObject equipcanvas;　 //装備画面のキャンバス
    public GameObject errortext;　　 //アイテム売買画面でのエラーメッセージ

    //アイテム売買関係のUI
    [SerializeField] private Canvas itemstorecanvas;  //アイテム売買用のキャンバス
    [SerializeField] private GameObject countpanel;   //アイテムの購入個数指定パネル
    [SerializeField] private GameObject buy_checkpanel;    //購入確認画面
    [SerializeField] private GameObject decided_buyitempanel; //購入確定画面

    public Canvas set_canvas {  set { canvas = value.gameObject; } }   //通常のキャンバスを設定する。



    //UIが配置されたキャンバスは複数あり，状況によって最適なキャンバスに切り替わる。
    //以下は各キャンバスの遷移メソッド

    //メインメニュー
    public void OpenMainmenu()
    {
        canvas.SetActive(false);
        maincanvas.SetActive(true);
    }

    public void CloseMainmenu()
    {
        maincanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //アイテムバック
    public void OpenItembag()
    {
        maincanvas.SetActive(false);
        itemcanvas.SetActive(true);
    }

    public void CloseItembag()
    {
        itemcanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //装備画面
    public void OpenEquipment()
    {
        maincanvas.SetActive(false);
        equipcanvas.SetActive(true);
        
    }

    public void CloseEquipment()
    {
        equipcanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //アイテム売買画面
    public void OpenItemStoreMenu()
    {
        try
        {
            canvas.SetActive(false);
            itemstorecanvas.gameObject.SetActive(true);
        }
        catch
        {
            Debug.LogError("参照エラーです。");
        }
        
    }

    public void CloseItemStoreMenu()
    {
        try
        {
            itemstorecanvas.gameObject.SetActive(false);
            countpanel.SetActive(false);
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(false);
            canvas.SetActive(true);
            errortext.SetActive(false);
        }
        catch
        {
            Debug.LogError("参照エラーです。");
        }
        
    }



}
