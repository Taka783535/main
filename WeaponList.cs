using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************
 * 全ての武器を保存するスクリプタブルオブジェクト
 * パラメーター定義クラスであるWeaponクラスと併せて使用する。
 *********************************************************/

[CreateAssetMenu]
public class WeaponList : ScriptableObject
{
    //武器格納用スクリプタブルオブジェクト(通称：武器リスト)の作成
    public List<Weapon> weapons = new List<Weapon>();

    //武器リストを返す
    public List<Weapon> GetWeaponList()
    {
        return weapons;
    }

}
