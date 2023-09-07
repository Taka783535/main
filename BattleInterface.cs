using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//戦闘システムで使用するインタフェースが定義されている。
public interface BattleInterface 
{
    //ダメージ処理用のインターフェース
    //プレイヤーやモンスターに付けてそれぞれダメージ処理を定義する。
    void IReceiveDamage(int damage);

}
