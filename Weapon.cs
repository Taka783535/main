using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************
 * 武器のパラメータを定義するクラス
 * Weaponlist(スクリプタブルオブジェクト)でリスト化・管理される
 **************************************************************/

[System.Serializable]
public class Weapon
{
    public int weapon_id;  //武器のID番号
    public GameObject weapon; //武器のGameObject
    public GameObject weapon_icon; //バッグ内に表示する武器のアイコン
    public string weapon_name; //武器の名前
    public int attack; //武器の攻撃力
    public Battleinformation.Attribute attribute; //武器の属性
    public string weapon_detail; //武器の説明文

}
