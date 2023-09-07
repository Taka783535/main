using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//モンスター情報を格納するスクリプタブルオブジェクト

[CreateAssetMenu]
public class Monstorlist : ScriptableObject
{
    //モンスター情報格納用スクリプタブルオブジェクトの作成
    public List<Monstorstatus> monstors = new List<Monstorstatus>();

    public List<Monstorstatus> GetMonstorstatuses()
    {
        return monstors;
    }

}
