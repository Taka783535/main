using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************
 * 全てのアイテムを保存するスクリプタブルオブジェクト
 * パラメーター定義クラスであるItemクラスと併せて使用する。
 *********************************************************/

[CreateAssetMenu]
public class Itemlist : ScriptableObject
{
    //アイテム保存用スクリプタブルオブジェクトの作成
    public List<Item> items = new List<Item>();

    public List<Item> GetItemList()
    {
        return items;
    }

}
