using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneborder : MonoBehaviour
{
    //シーンを切り換えるコード
    //他ゲームでのマップの切り換えは予測できない為本作専用


    //プレイヤーのGameobject
    [SerializeField] private GameObject playercharactor;

    //ゲームスタート画面の遷移
    public void StartScene()
    {
        SceneManager.LoadScene("Base Village");


    }

    

    //ゲームクリア，ゲームオーバー画面の遷移
    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title Scene");
        
    }

    //ゲームオーバー画面への遷移
    private void GameOverScene()
    {
        SceneManager.LoadScene("GameOver Scene");
    }
    
    
    //シーン切り換えオブジェクトに当たると発動。シーンが切り替わる。
    private void OnTriggerEnter(Collider other)
    {
        
        
            //雑貨屋
            if (gameObject.name == "storeborder" && other.gameObject.tag == "Player") //村→店内
            {
                SceneManager.LoadScene("General store interior");
            }
            if (gameObject.name == "storeinteriorborder" && other.gameObject.tag == "Player")　//店内→村
            {
                SceneManager.LoadScene("Base Village");
            }

            //平原フィールド
            if (gameObject.name == "planeborder" && other.tag == "Player")　//村→平原
            {
                SceneManager.LoadScene("Field plane");
            }
            if (gameObject.name == "villageborder" && other.gameObject.tag == "Player")  //平原→村
            {
                SceneManager.LoadScene("Base Village");
            }

            //隠しエリア
            if (gameObject.name == "SecretWood" && other.gameObject.tag == "Player")　//平原→隠しエリア
            {
                SceneManager.LoadScene("Sanctuary");
            }
            if (gameObject.name == "sanctuaryborder" && other.gameObject.tag == "Player")　//隠しエリア→平原
            {
                SceneManager.LoadScene("Field plane");
            }

        

    }


}
