using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ストーリーのセリフが定義されているクラス
/// StoryDialogListクラスでスクリプタブルオブジェクトに格納される。
/// </summary>

[System.Serializable]
public class StoryDialogDifinaition 
{
    public int story_id;  //ストーリーのID
    public story_kinds story_kind;　//ストーリーの種類
    public string[] story_dialog = new string[10]; //ストーリーのセリフや文言

    //ストーリーの種類
    public enum story_kinds
    {
        tutrial, //チュートリアル
        story1, //1章
        story2  //2章
    }
}
