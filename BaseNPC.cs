using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クラス概要：
/// NPCの基本となるクラス
/// NPC運用に必要な機能がまとめられている
/// NPC系のクラスはこのクラスを継承して作られる。
/// </summary>

public class BaseNPC : MonoBehaviour
{

    //フィールド

    [SerializeField] private protected NPClist npclist; //NPCデータが格納されているスクリプタブルオブジェクト
    private List<NPCdifinaition> npcs; //スクリプタブルオブジェクトから取り出したデータ
    [SerializeField] protected GameObject npcnameboard; //NPCの名前が表示されるワールドUI

    //オブジェクト検索用文字列
    [SerializeField] protected string npc_name;  //アタッチするNPCの名前。各派生クラスで個別に値設定必要
    [SerializeField] protected string Canvas_name; // 通常表示されているUIキャンバスの名前
    [SerializeField] protected string Npc_talkcanvas;　//NPCと会話する時用のキャンバスの名前
    [SerializeField] protected string Npc_comment_panel; //会話表示用テキストボックスの親オブジェクト
    [SerializeField] protected string Npc_commennt_text; //NPCのコメントが表示されるテキストボックスの名前
    [SerializeField] protected string Next_button; //「次へ」の会話を進めるボタン名

    protected GameObject canvas;　　//通常表示されているUIキャンバス
    protected GameObject npc_talkcanvas;　　//NPCと会話する時用のキャンバス
    protected GameObject npc_comment_text;　//NPCのコメントが表示されるテキストボックス

    //NPCの会話フラグ，このフラグをtrueにするとトリガーが検知した瞬間会話始まる。
    [SerializeField] protected bool npc_talkflg;



    //メソッド

    /****************************************
     * NPCの名前をNPCの頭上に表示するメソッド
     * 引数：NPCの名前
     * 戻り値：なし
     ****************************************/
    protected void ShowNpcName(string npcname)
    {
        //NPCのリストを取得
        npcs = npclist.GetNPClist();
        foreach (NPCdifinaition param in npcs)
        {
            //目的のNPCを特定して
            if (param.npc_name == npcname)
            {
                //NPCの上に名前表示
                npcnameboard.GetComponent<Text>().text = param.npc_name;
            }
               
        }
    }





    



    //NPCと会話を開始するメソッド,Buttonに適用する為メソッド化している
    public void TalktoNPC()
    {
        npc_talkflg = true;
    }



    //NPCのトリガーに触れたら会話始まる
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Setup_Talk_NPC();
        }

    }


    /********************************************
     * NPCと会話を行うメソッド
     * 引数：なし
     * 戻り値：なし
     * 概要：
     * 指定したNPCの通常会話メッセージを表示する
     * ******************************************/
    private void Setup_Talk_NPC()
    {
        if (npc_talkflg)
        {
            //NPCのリストを取得
            List<NPCdifinaition> npc_list = npclist.GetNPClist(); 

            if (npc_name != null)
            {
                foreach (NPCdifinaition param in npc_list)
                {

                    //セリフを引き出すキャラクター特定
                    if (param.npc_name == npc_name)
                    {
                        canvas.SetActive(false);
                        npc_talkcanvas.SetActive(true);

                        //キャラクターの通常のセリフをUIに表示する。
                        npc_comment_text.GetComponent<Text>().text = param.npc_comment;
                    }


                }

            }
            else
            {
                //エラー：セリフを引き出すNPCが未設定

                string error_message = "NPCの名前をnpc_nameに割り当てて下さい";

                //NPCが割り当てられてなければ警告
                Debug.Log(error_message);
            }

            npc_talkflg = false;

        }


    }


   


}
