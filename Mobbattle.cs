using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クラス概要：
/// モンスターからプレイヤーへの攻撃を行うクラス
/// </summary>

public class Mobbattle : BaseMonstor,BattleInterface
{

    //モンスターのAnimator
    private Animator monstoranimation;




    protected override void Start()
    {
        //ナビメッシュAIの設定
        base.Start();
        
    }

    private void OnTriggerStay(Collider other)
    {
        //モンスターがプレイヤーを攻撃する
        MonstorAttack(other);

    }




    //モンスターがダメージを受ける処理
    void BattleInterface.IReceiveDamage(int damage)
    {
        
        //モンスターの現在ステータスの取得,ダメージ処理
        CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();
        mobstatus.hp = mobstatus.hp - damage;


    }


    /******************************************
     * モンスターがプレイヤーを攻撃するメソッド
     * 引数：プレイヤーのコライダー
     * 戻り値：なし
     * 概要：
     * モンスターがプレイヤーを攻撃する。
     ******************************************/
    public void MonstorAttack(Collider player_collider)
    {
        //モンスターのAnimatorを取得
        monstoranimation = gameObject.GetComponent<Animator>();

        //モンスターのトリガーでプレイヤーを検知した時
        if (player_collider.tag == "Player")
        {
            //モンスター個体ごと(モンスターのインスタンスごと)のステータスを取得
            CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();

            //プレイヤーキャラクターのステータスを取得，キャラの現在ＨＰ管理はＨＰＭＰクラスがしている
            HPMP charactor_status = player_collider.GetComponent<HPMP>(); //キャラクターのステータス
            float distance = Vector3.Distance(gameObject.transform.position, player_collider.transform.position); //キャラクターとモンスターとの距離


            //キャラクターとモンスターのHPが0でない，かつ両者の距離が6ｍ以内
            if (mobstatus.hp != 0 && charactor_status.hp != 0 && distance < 6)
            {
                
                //距離3ｍ以内であれば戦闘開始
                if (distance < 3.0)
                {
                    //モンスターがキャラクターを攻撃する

                    monstoranimation.SetBool("walk", false);
                    monstoranimation.SetBool("attack01", true);
                    

                }
                else
                {
                    //モンスターがキャラクターを追いかける
                    base.ChaseTarget();
                    monstoranimation.SetBool("attack01", false);
                    monstoranimation.SetBool("walk", true);
                }

            }
            else if (6 < distance)
            {
                //戦闘終了
                monstoranimation.SetBool("walk", false);
            }

        }
    }




    /********************************************
     * モンスターの攻撃モーションに取り付ける関数
     * 引数：なし
     * 戻り値：なし
     * 概要：
     * モンスターがプレイヤーにダメージを与える
     * ******************************************/
    private void MonstorAttackStart()
    {
        //攻撃対象となるプレイヤーからダメージ処理のインターフェースを取得
        GameObject player = gameObject.GetComponent<Mobbattle>().target;
        BattleInterface player_hp = player.GetComponent<BattleInterface>();

        //プレイヤーにダメージを与える
        player_hp.IReceiveDamage(10);

    }

    

}
