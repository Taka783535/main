using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************
 * アイテムバッグ内のアイテムを保存するスクリプタブルオブジェクト
 * アイテムデータ定義クラスであるItemクラスと併せて使う。
 ****************************************************************/

[CreateAssetMenu]
public class ItemBaglist : ScriptableObject
{
    //アイテムバッグ内アイテム格納用スクリプタブルオブジェクトの作成
    public List<Item> items = new List<Item>();


    public List<Item> GetItemBaglist()
    {
        return items;
    }

}
