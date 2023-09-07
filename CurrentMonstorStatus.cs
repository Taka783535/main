using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲーム中モンスターのステータス情報をリアルタイムで管理するクラス
//モンスターごとにアタッチして使う。

public class CurrentMonstorStatus : MonoBehaviour
{

    [SerializeField] private Monstorlist monstorlist;
    private List<Monstorstatus> monstorstatus;

    public string monstorname; //モンスターの名前
    public Battleinformation.Attribute attribute;   //モンスターの属性
    public int hp = 100;             //HP
    public int attack = 10;         //攻撃力
    public int defence = 5;        //防御力
    public int dropitem1_id; //第1ドロップアイテムのID
    public int dropitem2_id; //第2ドロップアイテムのID


    private void Start()
    {
        Setup_Monstorstatus();
    }


    //モンスターのステータス情報の初期化を行うメソッド
    private void Setup_Monstorstatus()
    {
        //モンスタ―用スクリプタブルオブジェクトからモンスターのリスト取り出す。
        monstorstatus = monstorlist.GetMonstorstatuses();

        //取得したモンスターリストからさらに個々のモンスターのステータスを取り出す
        foreach(Monstorstatus mobstatus in monstorstatus)
        {
            //各ステータスの値をコピーし，モンスターのステータス値を初期化
            if(mobstatus.monstorname==gameObject.name)
            {
                this.monstorname = mobstatus.monstorname;
                this.attribute = mobstatus.attribute;
                this.hp = mobstatus.hp;
                this.attack = mobstatus.attack;
                this.defence = mobstatus.defence;
                this.dropitem1_id = mobstatus.dropitem1_id;
                this.dropitem2_id = mobstatus.dropitem2_id;
            }

        }

    }

    


}
