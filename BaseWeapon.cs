using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クラス概要：
/// 武器の基本となるクラス
/// 武器運用に必要な機能がまとめられている
/// 武器系のクラスはこのクラスを継承して作られる。
/// </summary>

public class BaseWeapon : MonoBehaviour
{
    

    public GameObject player;  //武器の親オブジェクトであるプレイヤーのGameObject

    //武器の攻撃力
    public int attack;


    //触れたものにダメージを与える処理
    private void OnTriggerEnter(Collider other)
    {
        BattleInterface battleInterface = other.gameObject.GetComponent<BattleInterface>();

        if(battleInterface!=null)
        {
          
            battleInterface.IReceiveDamage(attack);

        }

    }
    

}
