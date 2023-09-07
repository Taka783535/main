using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIgenerate : MonoBehaviour
{

    //アイテムのUIをアイテムバック内に表示するクラス
    GameObject itemobject;
    public GameObject itempanel;

    public ItemUIgenerate(GameObject uiprefab)
    {
        //uiprefabには出現させるUIのプレハブを設定
        //設定にはResourceクラスのLoadメソッドでプレハブ取得，GameObjectに変換してこのコンストラクタに投げ込む。
        itemobject = uiprefab;
    }

    public void GenerateItemUI()
    {
        Transform parent = itempanel.transform;
        Instantiate(itemobject,parent,false);
    }

}
