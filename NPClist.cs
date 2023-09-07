using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPCのリストを管理するスクリプタブルオブジェクトを作成する。
/// </summary>

[CreateAssetMenu]
public class NPClist : ScriptableObject
{

    //NPCの定義情報格納用スクリプタブルオブジェクトを生成
    [SerializeField] public List<NPCdifinaition> npcs = new List<NPCdifinaition>();
   

    //NPCのリストを返す
    public List<NPCdifinaition> GetNPClist()
    {
        return npcs;
    }

}
