using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************
 * プレイヤーのセーブデータ
****************************/

[System.Serializable]
public class SaveData 
{
    internal string playername;  //プレイヤー名
    internal int playerlevel = 1; //プレイヤーのレベル
    internal int hp = 0;     //HP
    internal int mp = 0;     //MP
    internal int str = 0;    //攻撃力
    internal int magic = 0;   //魔法攻撃力
    internal int vit = 0;    //体力・防御力
    internal int agi = 0;    //敏捷性
    internal int dex = 0;    //器用
    internal int money = 1000;　　//所持金
    internal Vector3 currentpoint;   //現在のプレイヤー座標
    internal string scenename;   //現在プレイヤーが存在するシーン(マップ)
}
