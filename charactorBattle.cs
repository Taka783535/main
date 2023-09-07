using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターからモンスターへの攻撃が定義されたクラス
public class charactorBattle : MonoBehaviour
{

    

    [SerializeField] GameObject player; //プレイヤーの3Dオブジェクト
    [SerializeField] Animator normalanim;  //プレイヤーのAnimator
    [SerializeField] private string parameter_battlestandby; //攻撃準備モーションの切り換えフラグ名(bool値)
    [SerializeField] private string parameter_attack;        //攻撃モーションの切り換えフラグ(bool値)

    public GameObject weapon;           //現在装備中の武器
    [SerializeField] GameObject charactorhand;    //キャラクターの手のオブジェクト・武器を持たせる時に使用。

    private Vector3 weapon_position; //武器の初期位置，武器をしまう時に必要
    private Quaternion weapon_rotation; //武器の初期回転座標，武器をしまう時必要
    [SerializeField] GameObject charactor_back; //武器をしまった時，武器の親となるオブジェクト(通常はプレイヤーの背中)

    [SerializeField] GameObject normalui; //通常のUIキャンバス

    private AudioSource weapon_audio;  //武器のサウンドの音源


    public AudioSource WeaponAudio { get { return weapon_audio; } set { weapon_audio = value; } }  //武器の音声の設定






  
    void Start()
    {
        //初期化処理

        //アニメーションセット
        normalanim = player.GetComponent<Animator>();

        //武器のローカル座標記録。武器をしまう時必要になる。
        weapon_position = weapon.transform.localPosition;
        weapon_rotation = weapon.transform.localRotation;
    }


    private void Update()
    {
        //何かキャラクターから入力が来た時
        if (Input.anyKeyDown&&normalui.activeInHierarchy==true)
        {
            //Enterキーならば攻撃行動に移る
            if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetMouseButtonDown(0))
            {
                PlayerAttack();

            }
            //Enterキー以外であれば攻撃を終了して通常モーションに戻る
            else
            {
             
                normalanim.SetBool(parameter_attack, false);
                normalanim.SetBool(parameter_battlestandby, false);

                //武器をしまう+武器の位置調整
                weapon.transform.SetParent(charactor_back.transform, false);
                weapon.transform.localPosition = weapon_position;
                weapon.transform.localRotation = weapon_rotation;

            }

        }

    }


   
    

    /**********************************************
     * プレイヤーが攻撃する為のメソッド
     * 引数:攻撃対象のコライダー
     * 戻り値：なし
     * 概要:
     * プレイヤーが戦闘待機モーションへ移行する
     * この状態で指定のボタンが押されると
     * プレイヤーがその場で通常攻撃を行う
     **********************************************/
    public void PlayerAttack()
    {
        
        //戦闘待機モーション(武器を構えている状態)へ移行
        if(normalanim.GetBool(parameter_battlestandby)==false)
        {
            //武器を構える
            normalanim.SetBool(parameter_battlestandby, true);

            //武器の位置調整
            weapon.transform.SetParent(charactorhand.transform,false);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }
        else
        {
            
            //既に戦闘待機モーションであった場合は攻撃を開始する。
            normalanim.SetBool(parameter_attack, true); //攻撃モーションへ移行
            

        }
        
        
    }



    //攻撃開始時に呼ばれるメソッド。キャラクターの攻撃アニメーション(アニメーションイベント)で呼び出される。
    void PlayerAttackStart()
    {
        //武器の当たり判定をONにする。
        weapon.GetComponent<CapsuleCollider>().enabled = true;

        
        if (weapon_audio != null)
        {
            weapon_audio.enabled = true;
        }

    }

    //攻撃終了時に呼ばれるメソッド。キャラクターの攻撃アニメーション(アニメーションイベント)で呼び出される。
    void PlayerAttackEnd()
    {
        //武器の当たり判定をOFFにして攻撃待機モーションに戻る。
        weapon.GetComponent<CapsuleCollider>().enabled = false;
        normalanim.SetBool(parameter_attack, false);

        if (weapon_audio != null)
        {
            weapon_audio.enabled = false;
        }

    }





}
