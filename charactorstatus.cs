using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クラス概要：
/// キャラクター→メニュー→ステータスのステータス画面で使用するクラス
/// 現在のプレイヤーのステータス表示などを行う。
/// </summary>

public class charactorstatus : MonoBehaviour
{
    [SerializeField] private Text leveltext; //キャラクターレベルのテキスト表示
    [SerializeField] private Slider str; //strのステータスバー
    [SerializeField] private Slider magic; //magicのステータスバー
    [SerializeField] private Slider vit; //vitのステータスバー
    [SerializeField] private Slider agi; // agiのステータスバー
    [SerializeField] private Slider dex; //dexのステータスバー

    ///SaveandLoadManager saver = new SaveandLoadManager();

    // Start is called before the first frame update
    void Start()
    {
        //ステータス画面初期設定
        SetStatus();
    }


    /********************************************************
     * ステータス画面の設定
     * 引数：なし
     * 戻り値：なし
     * 概要:ステータス画面に現在のステータス状態を反映させる
     ********************************************************/
    internal void SetStatus()
    {
        SaveData save;

        //セーブデータを読み込む
        save = SaveandLoadManager.DataLoad();

        if(save!=null)
        {
            //レベル表示
            leveltext.text = save.playerlevel.ToString();

            //str,int,vitなどの基本ステータスの上限値は100
            //スライダーに各ステータスを反映
            str.value = (float)save.str/100;
            magic.value =(float) save.magic / 100;
            vit.value =(float) save.vit / 100;
            agi.value =(float) save.agi / 100;
            dex.value =(float) save.dex / 100;

        }
    }

}
