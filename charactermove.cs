using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************************
*キャラクター移動用のクラス
*アニメーターコントローラーはunitychanlocomotion
*************************************************/

public class charactermove : MonoBehaviour
{
    //グローバル変数

    private Animator move;   //プレイヤーのAnimator
    private Rigidbody rb;　　//プレイヤーのRigidBody

    //必要となるシーンの名前
    [SerializeField] private string player_start_scene;
    private const string game_clear_scene = "GameClear Scene";
    private const string game_over_scene = "GameOver Scene";

    [SerializeField] private GameObject searchbutton; //NPCに話しかける時のボタン
    [SerializeField] private string appear_actionbutton_tag; //オブジェクトのタグ名。設定したタグに触れるとactionbuttonが出現する。


    public GameObject backobject = null;  //キャラクターが振り向くときのオブジェクト

    private static bool dontdestroy_flg = false;

    public static GameObject player;

    [SerializeField] private float player_walk_speed;    //プレイヤーの歩行速度
    [SerializeField] private float player_rotate_speed;  //プレイヤーを回転させる場合のプレイヤーの回転速度
 
    //プロパティ
    //プレイヤーの歩行速度を設定する。
    public float set_walkspeed { get { return player_walk_speed; } set { player_walk_speed = value; } }
　　//プレイヤーの回転速度を設定する。
    public float set_rotatespeed { get { return player_rotate_speed; } set { player_rotate_speed = value; } }
    //actionbutton(調べるや攻撃ボタン)を出現させるタグを設定する。
    public string set_appear_actionbutton_tag { get { return appear_actionbutton_tag; } set { appear_actionbutton_tag = value; } }




    // メソッド

    void Start()
    {
        //メンバー変数初期化
        move = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward*3;

        if(dontdestroy_flg==false)
        {
            //キャラクターが破壊されないようにする
            DontDestroyOnLoad(gameObject);
            player = gameObject;
            dontdestroy_flg =true;
        }

        SceneManager.sceneLoaded += Sceneloaded;
    }

    

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの入力に応じて移動を行う
        movecontrol();
        
    }


    //シーンが切り替わった時呼ばれる必要な処理。切り換え元にある不要オブジェクトの破壊など
    void Sceneloaded(Scene next_scene,LoadSceneMode mode)
    {

        if (next_scene.name != "Title Scene")
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Animator>().SetFloat("Speed", 0f);
        }

        //DontdestroyOnloadのコピー元はいらないので破壊する
        if(next_scene.name== player_start_scene)
        {
            //切り換え元マップから全てのルートオブジェクトを取得し，プレイヤーを削除
            GameObject[] village_object = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach(GameObject obj in village_object)
            {
                if(obj.name==gameObject.name)
                {
                    Destroy(obj);
                }
            }
        }
        else if(next_scene.name== game_clear_scene|| next_scene.name==game_over_scene)
        {
            //ゲームクリア又はゲームオーバーシーンではプレイヤー自体いないのでプレイヤーそのものを破壊する
            Destroy(gameObject);
            
        }
    }


    /*******************************************************
     * キャラクターの移動を行うメソッド
     * 引数：なし
     * 戻り値：なし
     * 概要：入力されたキーによってキャラクターの移動を行う
     *******************************************************/
    private void movecontrol()
    {

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))   //前方移動
        {
            move.SetFloat("Speed", player_walk_speed);
            Rigidbody v = gameObject.GetComponent<Rigidbody>();
            v.velocity = transform.forward * 3;
            v.AddForce(transform.forward * 5);

        }
        if(Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.W))　　
        {
            float walk_stopspeed = 0f;
            move.SetFloat("Speed", walk_stopspeed);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)||Input.GetKeyUp(KeyCode.S))　　//後方移動
        {
           
            gameObject.transform.LookAt(backobject.transform);
            
        }
        if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))　　//右回転
        {
            transform.RotateAround(transform.position, transform.up, player_rotate_speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))    //左回転
        {
            transform.RotateAround(transform.position, transform.up, -player_rotate_speed);
        }

    }


    //以下2つはNPCに近付いた時会話ボタンを出現させる・消去する処理
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== appear_actionbutton_tag)
        {
            searchbutton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == appear_actionbutton_tag)
        {
            searchbutton.SetActive(false);
        }
    }
}
