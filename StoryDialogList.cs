using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ストーリーのセリフを管理するスクリプタブルオブジェクトを作成する。
/// </summary>

[CreateAssetMenu]
public class StoryDialogList : ScriptableObject
{
    [SerializeField] public List<StoryDialogDifinaition> storydialoglist = new List<StoryDialogDifinaition>();

    //セリフデータ一覧を返すメソッド
    public List<StoryDialogDifinaition> GetStoryDialogList()
    {
        return storydialoglist;
    }
}
