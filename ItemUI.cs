using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] protected ItemBaglist item_sobj; //アイテムバッグのデータベース(スクリプタブルオブジェクト)
    private List<Item> items; //データベースから取り出したアイテム

    //アイテムバッグ操作用変数
    [SerializeField] private Itemlist itemlist;
　　[SerializeField] private GameObject itemboardpanel;

    [SerializeField] private GameObject itemname_display;     //アイテムバッグ内においてアイテムの名前を表示するUI
    [SerializeField] private GameObject itemdetail_display;　 //アイテムバッグ内においてアイテムの詳細を表示するUI


    private const string itemname_panel = "Itemname";
    private const string item_inspectorpanel = "ItemInspectorText";


    private void Start()
    {
        int save_crystal = 2;
        GetItem(save_crystal);
    }


    //与えたアイテムIDのアイテム名と説明文をアイテムバッグ内のテキストボックスに表示する。
    public void ItemSet(int bagitem_id)
    {
        items = item_sobj.GetItemBaglist(); //各アイテムのリストを取得

        foreach (Item item in items)
        {

            if (item.itemid == bagitem_id)
            {
                //変数がnullならエラーになるので然るべきオブジェクトを設定する。
                if(itemname_display==null)
                {

                    itemname_display = GameObject.Find(itemname_panel);

                }
                if(itemdetail_display==null)
                {

                    itemdetail_display = GameObject.Find(item_inspectorpanel);

                }

                //名前，説明文表示
                itemname_display.GetComponent<Text>().text = item.itemname;
                itemdetail_display.GetComponent<Text>().text = item.itemdetail;
            }

        }

    }


    //アイテムＩＤで指定したアイテムの個数を返すメソッド
    protected int GetItemQuantity(int bagitem_id)
    {
        int numberofitem = 0;
        items = item_sobj.GetItemBaglist(); //各アイテムのリストを取得

        foreach (Item item in items)
        {
            if (item.itemid == bagitem_id)
            {
                //アイテム個数記録
                numberofitem = item.item_quantity;
            }

        }

        //アイテムの個数を返す。
        return numberofitem;

    }


    //アイテムIDで指定したアイテムをバッグの中に生成するメソッド
    private void GetItem(int item_id)
    {
        //各アイテムのリストを取得
        items = item_sobj.GetItemBaglist();

        foreach(Item item in items)
        {
            if(item.itemid==item_id)
            {

                //itemboardパネルを親に設定して生成
                GameObject bag_item=GameObject.Instantiate(item.itemimage,itemboardpanel.transform);
                bag_item.GetComponentInChildren<Text>().text = item.item_quantity.ToString();

            }

        }

    }



}
