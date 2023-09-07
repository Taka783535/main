using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCdifinaition 
{

    //NPCの基本情報定義クラス
    public string npc_name;  //NPCの名前
    public int npc_level;　　//NPCのレベル
    public int hp = 0;     //HP
    public int mp = 0;     //MP
    public int str = 0;    //攻撃力
    public int magic = 0;   //魔法攻撃力
    public int vit = 0;    //体力・防御力
    public int agi = 0;    //敏捷性
    public int dex = 0;    //器用
    public string npc_comment; //NPCの会話内容
    public string npc_questcomment1; //クエストの会話内容(必要に応じて増やす)
    public int quest_experience1; //クエストの経験値
    public int quest_itemid1; //クエストの報酬アイテム

}
