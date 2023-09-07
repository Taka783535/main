using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    //情報定義クラス

    //Serializefieldなどに登録しておけないデータを登録しておいてここから参照する

    //武器クラスのフィールド情報
    public GameObject inspectorname;  //装備画面で武器の名前を表示するGameObject
    public GameObject inspectortext;　//装備画面で武器の詳細を表示するGameObject
    public GameObject equipparts;  //武器を装備する手のオブジェクト
    public Button usebutton;       //武器装備を確定する決定ボタン
    

}
