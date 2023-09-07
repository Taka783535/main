using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//継承先でストーリーIDを設定してください
//ストーリーID=set_storyid

public class BaseStory : MonoBehaviour
{

    /**************************************************************************************
     * クラス概要
     * ストーリーの各セリフを格納・管理するスクリプタブルオブジェクト(データベース)があり，
     * 初めにそのスクリプタブルオブジェクトから用意したリストへデータをコピーする。
     * 以後，そのリストを中心に操作する
     * 
     * 用語
     * セリフ：
     * ここではリストの1つ1つのデータのこと。各キャラクターの発言の1塊のこと。
     **************************************************************************************/


    [SerializeField] private protected StoryDialogList story_daialog_list; //ストーリーのセリフが定義されたスクリプタブルオブジェクト
    private List<StoryDialogDifinaition> story_dialog; //スクリプタブルオブジェクトから取り出したリスト形式のセリフデータ
    [SerializeField] protected bool story_flg = true; //ストーリーフラグ(ストーリーと通常のセリフを切り換える,主にNPCで使う)
    [SerializeField] public static int set_storyid=0; //継承先で設定するストーリーID, リストから任意のセリフの引き出しに使用。
    protected int story_progress=0; //ストーリーの進行状況(ストーリーID(set_storyidの値)が保存されている)

    
    //通常とNPC用の各種UIキャンバス
    private GameObject canvas;   //プレイヤーの通常のキャンバス
    private GameObject npc_talkcanvas;    //NPCと会話する用のUIが配置されているキャンバス
    private GameObject npc_comment_text;  //NPCの会話が表示されるUI

    protected int dialog_counter = 0; //リストの中のセリフが格納されている配列にアクセスするためのカウンタ

    private int all_dialog_counter; //1つのリストに入っているセリフの最大数


    private bool callonce=false; //1度しか呼ばれないメソッドに使うフラグ

    protected bool clear_slime_quest = false;  //今回受注するスライム討伐クエストのクリアを判別するフラグ

    private bool search_button=false; //クエストNPCに話かける時押すボタン

    private GameObject actionbutton;



    public void StoryReset()
    {
        //ストーリーの進行状況のリセット
        set_storyid = 0;
        dialog_counter = 0;
        all_dialog_counter = 0;
        callonce = false;
    }


    //Button(UI)に適用。クエストNPCに話かける時に近くで押すとストーリーの会話が始まる
    public void PushSearchButton()
    {
        search_button = true;
    }


    //クエスト表示ボードなどの検索・登録処理
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "NPC")
        {

            if (other.gameObject.tag== "Player")
            {
                canvas = other.gameObject.transform.Find("Canvas").gameObject;
                actionbutton = canvas.transform.Find("actionbutton").gameObject;
                npc_talkcanvas = other.gameObject.transform.Find("NPCTalkCanvas").gameObject;
                npc_comment_text = npc_talkcanvas.transform.Find("npc_comment_panel").Find("npc_comment_text").gameObject;

                //アクションボタンにイベントを設定
                Button[] buttons = GameObject.FindObjectsOfType<Button>();

                foreach (Button btn in buttons)
                {
                    if (btn.name == "actionbutton")
                    {
                        btn.onClick.AddListener(PushSearchButton);
                    }

                }

            }

        }

    }


    //クエストNPCに話かける処理とスライム討伐クエストのクリア判定の処理
    private void OnTriggerStay(Collider other)
    {

        //クエストNPCの近くでボタンを押すと会話が始まる
        if (callonce == false && search_button == true&&gameObject.tag== "NPC")
        {
            if (other.tag == "Player" && story_flg == true)
            {
                Show_Story(set_storyid);

                //次へボタンイベントの登録処理
                Button[] butt = GameObject.FindObjectsOfType<Button>();

                foreach(Button btn in butt)
                {
                    if(btn.name== "next_button")
                    {
                        btn.onClick.AddListener(Next_Story_Comment);
                    }
                }
            }

            search_button = false;
            callonce = true;
        }

        

    }


    private void OnTriggerExit(Collider other)
    {

        if (gameObject.tag == "NPC")
        {
            //フラグの値リセット処理
            callonce = false;
        }

    }


    protected virtual void PromoteStory_ID()
    {
        //オーバーライド用メソッド
        //継承先のクラスでこのメソッドを書き換えない場合はセリフが終了後次のセリフへ切り替わる
        //つまりNPCは同じセリフを言うことなく新しいセリフに切り替わる。

        set_storyid += 1;
        
    }




    /*****************************************
     * ストーリーの会話を開始するメソッド
     * 引数：表示するストーリーのストーリーID
     * 戻り値：なし
     * 概要：
     * 引数で指定したストーリーを表示する
     * ***************************************/
    private void Show_Story(int story_id)
    {
        //ストーリーの会話を表示する場合
        if (story_flg)
        {

            if(story_dialog==null)
            {
                //ストーリーのセリフデータを用意したリストに取得
                story_dialog = story_daialog_list.GetStoryDialogList();
            }
            

            foreach (StoryDialogDifinaition serifu in story_dialog)
            {
                
                //取得したリストから任意のセリフを引き出し特定(セリフの指定は引数)
                if (serifu.story_id == story_id)
                {
                    canvas.SetActive(false);
                    
                    npc_talkcanvas.SetActive(true);
                    

                    //インデックスに取り出したセリフ-1の長さを記録しておく(セリフの文字数。後で使う)
                    all_dialog_counter = serifu.story_dialog.Length-1;

                    //特定したストーリーのセリフをUIに表示する。
                    npc_comment_text.GetComponent<Text>().text = serifu.story_dialog[dialog_counter];


                }


            }


        }
    }

   
    /************************************
    *次へ　ボタンがクリックされた時の処理
    *引数：なし
    *戻り値：なし
    *概要：セリフを1つ進める。
    *************************************/
    public void Next_Story_Comment()
    {
        if (story_flg)
        {
            //セリフが途中の場合
            if (dialog_counter < all_dialog_counter )
            {
                //セリフを進める
                dialog_counter += 1;
                Show_Story(set_storyid);

            }
            //セリフが終わった場合
            else
            {
                npc_talkcanvas.SetActive(false);
              
                canvas.SetActive(true);
               

                //ゲームクリアをした時の処理。dialog_counterの初期化前に実行する必要がある為ここに配置
                if (set_storyid == 2 && dialog_counter == 2)
                {
                    SceneManager.LoadScene("GameClear Scene");
                }


                PromoteStory_ID();

                //セリフカウンター0クリア
                dialog_counter = 0;

                
            }

        }
    }



}
