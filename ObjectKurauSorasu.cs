using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectKurauSorasu : MonoBehaviour
{
    //ゲームオブジェクトのクラウ・ソラスそのものに付随させるクラス

    //プレイヤーのチャット欄(メッセージ表示用)
    [SerializeField] private Text chattxt;
    [SerializeField] private Canvas equip_canvas;     //装備UIの配置されたキャンバス
    [SerializeField] private GameObject equip_panel;  //装備アイコンが配置されるパネル

    [SerializeField] private WeaponList lists;    //武器の一覧が格納されたスクリプタブルオブジェクト
    [SerializeField] private int kurausorasu_id;  //聖剣クラウ・ソラスの武器ID

    
    private void OnCollisionEnter(Collision other)
    {
        PickUP_KurauSorasu(other);

    }


    //聖剣クラウソラスを拾った場合の処理
    private void PickUP_KurauSorasu(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            string specialweapon_gottext = "聖剣クラウ・ソラスを入手しました！";
            chattxt = other.transform.Find("Canvas").Find("chatpanel").Find("chattxt").GetComponent<Text>();

            chattxt.text = specialweapon_gottext;


            //装備格納パネル(装備バッグそのもの)取得
            GameObject equip_obj = other.gameObject.transform.Find("EquipCanvas").Find("itemboardpanel").gameObject;

            //装備リスト(装備を管理しているスクリプタブルオブジェクト，装備のデータベース)から聖剣クラウソラスのアイコンを取得して装備バッグにインスタンス化
            List<Weapon> weaponlists = lists.GetWeaponList();

            foreach (Weapon weapon in weaponlists)
            {
                if (weapon.weapon_id == kurausorasu_id)
                {
                    //装備バッグ内に対象の武器作成
                    Instantiate(weapon.weapon_icon, equip_obj.transform);
                }

            }

            Destroy(gameObject);
        }
    }



}
