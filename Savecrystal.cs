using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Savecrystal : MonoBehaviour
{
    //アイテム：セーブクリスタルを使った時の処理
    //拠点に戻る
    private const string responescene = "Base Village";


    public void UseSavecrystal()
    {
       
        SceneManager.LoadScene(responescene);

    }


}
