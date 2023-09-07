using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlimeQuest : BaseStory
{

    //本作独自
    //このスクリプトはクエストを受け付けるNPCに取り付ける。
    //クエスト概要：スライムを5体倒す

    //クエストの状況を表示するためプレイヤーのチャット欄を使用する。
    [SerializeField] private Text chattxt; //プレイヤーチャット欄のテキストボックス
    internal bool receive_quest = false;  //クエスト受諾を判別するフラグ(Trueで受諾)
    internal static bool clear_quest = false;    //クエスト完了を判別するフラグ(Trueで完了) シーン間共有必要


    //Normal_Slimeクラスから操作する変数
    internal int slimecounter = 0;　　//倒したスライムを数えるためのカウンター
    internal bool counterchange = false;　//カウンターの値が変更されたことを検知するフラグ(カウンターフラグ)



    //基底クラスのメソッドのオーバーライド
    //前のセリフの終了直後にストーリーIDを変更するか否か記述できる
    protected override void PromoteStory_ID()
    {
        //ストーリーIDの変更・つまりキャラクターのセリフの切り換えをこのメソッドをオーバーライドすることで制御できる
        //条件が整うまでセリフの進行を止めることもできるし，オーバーライドしない場合は止まらずにセリフが進行する
        
        //ストーリーID　0→1の処理
        if (story_progress == 0 && set_storyid < 1 && clear_quest == false)
        {
            set_storyid += 1;

            if (set_storyid == 1)
            {
                gameObject.GetComponent<SlimeQuest>().receive_quest = true;
            }
        }

        //クエスト達成判定
        if (set_storyid == 2 && dialog_counter == 2)
        {
            SceneManager.LoadScene("GameClear Scene");
        }
    }



    private void Start()
    {
        //初期設定
        chattxt = GameObject.Find("chattxt").GetComponent<Text>();
    }


    private void Update()
    {
        //スライムを討伐した時は現在のスライム討伐数を通知する。
        if(counterchange==true&&slimecounter<6)
        {
            //カウンターフラグをfalseに戻し，現在のスライム討伐数を表示する
            counterchange = false;
            chattxt.text = $"スライムを倒した{slimecounter}/5";
        }

        //スライム5体倒した時の処理
        if (slimecounter == 5)
        {
            //クエストで規定された討伐数までいったらメッセージを表示してslimecounter0クリア
            slimecounter = 0;
            chattxt.text = "討伐完了！村にいるリーンへ報告しよう！";
            clear_quest = true;
        }

        if (clear_quest == true)  //討伐成功したらストーリーIDが2になる部分
        {
            set_storyid = 2;
            clear_quest = false;
        }

    }


    //クエスト受諾ボタンが押された時のメソッド
    public void Receive_SlimeQuest()
    {
        receive_quest = true;
    }


    private void OnTriggerExit(Collider other)
    {
        //NPCのトリガーに触れている間にプレイヤーがクエストを受諾(receive_questをtrueに変更)すれば以下が実行される。
        if(other.tag=="Player")
        {
            Begin_SlimeQuest(other.gameObject);
            
        }
    }


    private void Begin_SlimeQuest(GameObject playercharactor)
    {
        //クエストが受諾された時の処理
        //クエストが受諾されたら受諾完了メッセージをチャット欄に表示
        if (receive_quest == true)
        {
            playercharactor.AddComponent<SlimeQuest>();
            chattxt.text = "Quest:「スライム退治!!」を受諾しました！";
        }
    }

    


}
