using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
 * アイテムのパラメータを定義するクラス
 * Itemlist(スクリプタブルオブジェクト)でリスト化される
 *******************************************************/

[System.Serializable]
public class Item 
{
    public int itemid; //アイテムID
    public GameObject itemimage; //アイテム画像
    public string itemname; //アイテム名
    public int item_quantity=0; //アイテムの個数(アイテムバッグクラスでのみ使用。初期値0)
    public string itemdetail; //アイテムの説明文
}
