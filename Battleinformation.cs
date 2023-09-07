using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦闘に使われる情報が定義されているクラス
/// </summary>

public class Battleinformation : MonoBehaviour
{
    /****************************
     * 戦闘中や武器に使われる属性
     ****************************/
    public enum Attribute
    {
        Fire,     //火
        Water,　　//水
        Wind,     //風
        ground,    //土

        shine,    //神聖
        dark      //暗黒
    }


}
