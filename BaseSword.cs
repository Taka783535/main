using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 武器の性能そのものを定義するクラス
/// </summary>

public class BaseSword : MonoBehaviour
{
    //フィールド
    [SerializeField]private string weaponname;  //武器の名前
    [SerializeField] private string inspector;   //武器の説明文
    [SerializeField] protected GameObject inspectorname;   //装備画面中にある装備アイテムの名前が表示されるテキストボックス
    [SerializeField] protected GameObject inspectortext;　　//装備画面中にある装備アイテムの詳細が表示されるテキストボックス
    [SerializeField] GameObject weapon;　　//武器の3Dオブジェクト
    [SerializeField] private int attack;  //武器の攻撃力
    [SerializeField] protected GameObject equipparts;  //武器を装備するパーツ(通常は腕)
    [SerializeField] protected Button usebutton;  //武器を装備する決定ボタン

    //プロパティ
    public string Weaponname { get { return weaponname; } set { weaponname = value; } }
    public string Inspector { get { return inspector; } set { inspector = value; } }
    //武器の攻撃力
    public int WeaponAttack { get { return attack; } set { if (value <= 999) { attack = value; } } }



    //メソッド

    //装備画面で各装備アイテムのアイコンを押した時に呼ばれる処理
    public void SelectWeapon()
    {
        inspectorname.GetComponent<Text>().text = weaponname;
        inspectortext.GetComponent<Text>().text = inspector;
        usebutton.onClick.AddListener(EquipWeapon);
    }


    //武器を装備する時の処理
    public void EquipWeapon()
    {
        if (inspectorname.GetComponent<Text>().text == weaponname)
        {
            //武器をインスタンス化し初期設定を行う
            GameObject blade = Instantiate(weapon, Vector3.zero, Quaternion.identity, equipparts.transform);
            blade.transform.SetParent(equipparts.transform);
            blade.transform.localPosition = Vector3.zero;
            blade.transform.localRotation = Quaternion.identity;
            blade.AddComponent<BaseWeapon>().attack = attack;

            //装備していた武器とインスタンス化した武器を付け替える
            blade.GetComponent<BaseWeapon>().player = equipparts.transform.root.gameObject;
            GameObject player_weapon = transform.root.gameObject.GetComponent<charactorBattle>().weapon;
            Destroy(player_weapon);
            transform.root.gameObject.GetComponent<charactorBattle>().weapon = blade;

        }
    }


}
