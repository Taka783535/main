using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion
{

    //回復ポーションの仕様が定義されたクラス


    private int max_hp = 1000;    //最大HP
    private int max_mp = 500;     //最大MP

    private int heal_point = 100;　　//ポーションの回復量

    private const int hp_potion = 0;
    private const int mp_potion = 1;

    public int Set_maxhp { get { return max_hp; } set { max_hp = value; } }  //最大HPの設定
    public int Set_maxmp { get { return max_mp; } set { max_mp = value; } }　//最大MPの設定



    //ポーション(回復アイテム)の使用をアイテムIDで切り換える処理
    public void Usepotion(GameObject player,int item_id)
    {
        
        switch(item_id)
        {
            case hp_potion:   //HPポーションを使用した時の処理

                UseHPpotion(player);
                break;

            case mp_potion:  //MPポーションを使用した時の処理

                UseMPpotion(player);
                break;
        }
       
    }


    /// <summary>
    /// HPポーションを使用した時の処理
    /// 引数：プレイヤーのGameObject
    /// 戻り値：なし
    /// 概要：最大で100のHPを回復する。
    /// </summary>
    public void UseHPpotion(GameObject player)
    {
        HPMP characterhp = player.GetComponent<HPMP>();

        if (characterhp.hp != 0)
        {
            //最大HPの範囲内において
            if (characterhp.hp <= max_hp)
            {
                //最大HPと現在のHPの値の差
                int incrementhp = max_hp - characterhp.hp;

                //差がポーションの回復量以内の時は差分だけ増やす
                if (incrementhp <= heal_point)
                {
                    characterhp.hp += incrementhp;
                    characterhp.Heal(characterhp.DefaultHP());
                }
                else
                {
                    //差がポーションの回復量以上の時はポーション回復分を増やす
                    characterhp.hp += heal_point;
                    characterhp.Heal(characterhp.DefaultHP());
                }
            }

        }
        
    }


    /// <summary>
    /// MPのポーションを使用した時の処理
    /// 引数：プレイヤーのGameObject
    /// 戻り値：なし
    /// 概要：最大で100のMpを回復する。
    /// </summary>
    public void UseMPpotion(GameObject player)
    {
        HPMP charactermp = player.GetComponent<HPMP>();
        if (charactermp.hp != 0)
        {
            //最大MPの範囲内において
            if (charactermp.mp <= max_mp)
            {
                //最大MPと現在のMPの値の差
                int incrementmp = max_mp - charactermp.mp;

                //差がポーションの回復量以内の時は差分だけ増やす
                if (incrementmp <= heal_point)
                {
                    charactermp.mp += incrementmp;
                }
                else
                {
                    //差がポーションの回復量以上の時はポーションの回復分増やす
                    charactermp.mp += heal_point;
                }
            }

        }

    }



}
