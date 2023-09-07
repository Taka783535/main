using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターのステータス情報が定義されているクラス
/// Monstorlistクラス型のスクリプタブルオブジェクトで保存される。
/// </summary>
/// 

[System.Serializable]
public class Monstorstatus 
{
    public GameObject monstorimage;  //モンスターの3Dオブジェクト
    public string monstorname; //モンスターの名前
    public Battleinformation.Attribute attribute;   //モンスターの属性
    public int hp;             //HP
    public int attack;         //攻撃力
    public int defence;        //防御力
    public int dropitem1_id; //第1ドロップアイテムのID
    public int dropitem2_id; //第2ドロップアイテムのID

}
