using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムバッグを管理するクラス

public class ItemBag : MonoBehaviour
{
    private GameObject inspectorname;
    private GameObject inspector;


    //引数：アイテム名，アイテムの説明
    //アイテム選択画面にて，引数で指定した内容をアイテム詳細ウィンドウへ表示する。
    public void SelectItem(string itemname,string iteminspector)
    {
        inspectorname = GameObject.Find("Itemname");
        inspector = GameObject.Find("ItemInspectorText");
        inspectorname.GetComponent<Text>().text = itemname;
        inspector.GetComponent<Text>().text = iteminspector;
    }


    //アイテム使用のメソッド
    //引数：アイテムID，指定したアイテムを使用する。
    public void UseItem(int itemid)
    {

        //アイテムIDで使用するアイテムを判別
        switch(itemid)
        {
            case 1:    //ポーション
                Potion potion = new Potion();
                potion.Usepotion(gameObject,itemid);
                break;

            case 2:   //転移クリスタル
                Savecrystal savecrystal = new Savecrystal();
                savecrystal.UseSavecrystal();
                break;

            default:
                break;
        }
    }



}
