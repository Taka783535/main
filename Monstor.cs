using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//最初の1匹はモンスターをシーンに残し,これを元に残りを生成
public class Monstor : BaseMonstor
{
    
    Animator monstoranimation = new Animator();
    Collider sphereCollider = new SphereCollider();
    Rigidbody monstorrigidbody;
    int monstor=1;
    HPMP charactorstatus;
    float charactordistance;
    public GameObject mob;

    public GameObject hpfiller;

    private float timecounter;    //現在秒数の保持，時間計測に使用。
    private Vector3 directionvector = new Vector3();

    private bool attackflag = false; //攻撃中を示すフラグ。ないと攻撃中でも移動や方向転換が起こる
    private System.Random random=new System.Random();
    private GameObject[] clonemonstor=new GameObject[5];  //生成したモンスターの参照

    public Monstorlist monstorobject; //モンスターのスクリプタブルオブジェクト(ステータス情報を含む)
    private List<Monstorstatus> monstorstatuses;　//取り出したモンスターのステータス
    

    protected override void Start()
    {
        base.Start();　//ナビメッシュが設定されるのみ
        monstoranimation=gameObject.GetComponent<Animator>();
        monstoranimation.SetBool("walk", true);

        //モンスターが5匹以下なら足りない頭数をジェネレート
        clonemonstor=MonstorGenerator(5);
        //for(int i=0;i<1;i++)
        //{
            //clonetransform[i] = clonemonstor[i].GetComponent<Transform>();
        //}

    }


    // Update is called once per frame
    new void Update()
    {
        //モンスターが攻撃中でないなら処理実行
        if (attackflag == false)
        {
            //deltaTimeが1フレーム0.0・・1秒として考えている。クライアント側のプログラムでない限り通信悪化などでフレーム間隔が空いてモンスターの動きが遅くなる。
            //モンスターの徘徊プログラム
            timecounter += Time.deltaTime;   //現在の時間(秒)


            //開始5秒で始まる，あまり早いと何も起こらない？
            if (timecounter >= 5.0f && timecounter <= 5.1f)
            {
                //キャラの向きが変わる
                MonstorDirectionChange();

            }
            else if (timecounter > 5.1f && timecounter < 9.0) //3秒歩く
            {
                Rigidbody mobrigid = gameObject.GetComponent<Rigidbody>();
                mobrigid.velocity = directionvector;
                mobrigid.AddForce(directionvector);
            }
            else if (timecounter >= 9.0f && timecounter <= 13.0f)  //4秒止まる
            {
                monstoranimation.SetBool("walk", false);

                //タイムカウンタ0クリア
                timecounter = 0.0f;
            }

        }
    }



    /**********************************************************************
     * モンスターの生成プログラム
     * 引数：生成するモンスターの数
     * 戻り値：生成したモンスターの参照が入った配列
     * 概要：
     * 変数Mobに登録したモンスターが引数で指定した数になるまで
     * モンスターをフィールド上に生成する。
     **********************************************************************/
    public GameObject[] MonstorGenerator(int monstornumber)
    {
        //モンスターが指定した数以下なら足りない頭数をジェネレート
        monstor = GameObject.FindGameObjectsWithTag("Monstor").Length;  //現在フィールドにいるモンスターの数
        int clonenumber = monstornumber - monstor;    //生成クローン数
        GameObject[] clone = new GameObject[clonenumber];  //生成クローン数分の配列，戻り値，別関数で個体ごとに割り当てを行う際に使用。
        
        if (monstor < monstornumber)
        {

            for (int i = monstor; i < monstornumber; i++)
            {
                //出現場所のランダム座標を取得
                Vector3 popout = new Vector3(random.Next(-30, 30), 0f, random.Next(-30, 30));
                clone[i-monstor]=Instantiate(mob, popout, Quaternion.identity);
            }
            
        }


        return clone;   //生成モンスターの参照が入った配列

    }
  

    //モンスター用のクラス,モンスターにくっつけて使う，collisionはプレイヤー。
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            attackflag = true;
            monstorrigidbody = gameObject.GetComponent<Rigidbody>();
            //接触がプレイヤーならモンスターをキャラの方向かせる，歩かせる
            //gameobject=アタッチされているモンスター
            gameObject.transform.LookAt(collision.transform);
            monstorrigidbody.AddForce(collision.transform.position); //機能不全？
            monstoranimation.SetBool("walk", true); //
            //ゲームオブジェクト間の距離
            charactordistance = Vector3.Distance(gameObject.transform.position, collision.transform.position);
            if (charactordistance==1f)
            {
                charactorstatus = collision.gameObject.GetComponent<HPMP>();
                monstoranimation.SetBool("walk", false);
                //1回は処理を行うループないっけ？
                /*while(charactorstatus.hp!=0&charactordistance==1)
                {
                    monstoranimation.SetBool("attack01", true);
                    charactorstatus.hp = -10;
                }*/
            }
            
        }

    }

    //コライダーが触れてる間ダメージ？
    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {
            
            monstoranimation.SetBool("walk", false);
            charactorstatus =collision.gameObject.GetComponent<HPMP>();
            if(charactorstatus.hp!=0)
            {
                monstoranimation.SetBool("attack01", true);
                //Vector3 xscalepoint = hpfiller.transform.localScale;
                //xscalepoint.x = (float)1.8 / 1000 * 500;
                //charactorstatus.ReciveDamage(100, 1.8 / 1000);
            }
            
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            monstoranimation.SetBool("attack01", false);
        }

        attackflag = false;
    }

    public void Damage()
    {
        //charactorstatus.ReciveDamage(100, 1.8 / 1000);
    }


  

    //モンスターの向きをランダムに変える。
    private void  MonstorDirectionChange()
    {
        
        
        Vector3 vector = new Vector3();
        int[] charactordirection = new int[5];  //モンスター個体ごとの方向を示す乱数を記録
        

        //モンスター個体ごとの方向
        for(int i=0; i<5; i++)
        {
            charactordirection[i] = random.Next(0, 4);
        }
        
        //現在，clonemonstor[0～3]まで参照あり，これに方向乱数割り当てて参照

        //int point = random.Next(0, 4);  //方向を示す乱数
        Vector3 currentpoint = gameObject.transform.position;  //モンスターの現在座標

        for (int j = 0; j < 3; j++)    //今回mob生成5回なので暫定でループ5回,あとでグローバル変数に変更か
        {
            //ランダムな方向を向く
            switch (charactordirection[j])
            {
                case 0:
                    vector = currentpoint + Vector3.forward;
                    directionvector = Vector3.forward;
                    break;

                case 1:
                    vector = currentpoint + Vector3.right;
                    directionvector = Vector3.right;
                    break;

                case 2:
                    vector = currentpoint + Vector3.left;
                    directionvector = Vector3.left;
                    break;

                case 3:
                    vector = currentpoint + Vector3.back;
                    directionvector = Vector3.back;
                    break;

                default:
                    break;

            }


            //最初の1ループだけは配列の中身があるが，それ以後のループで中身なし，配列が宣言時に戻ってしまう
            //clonemonstor[j].transform.LookAt(vector);
            //clonetransform[j].transform.LookAt(vector);
            gameObject.transform.LookAt(vector);
        }
            monstoranimation.SetBool("walk", true);
        
        
            //Rigidbody mobrig = mob.GetComponent<Rigidbody>();
            //mobrig.velocity =directionvector*10;
            //mobrig.AddForce(directionvector);

    }

    //未使用メソッド　いらないなら消去
    private void Monstor_attack(int monstorid)
    {
        //モンスターのリストをスクリプタブルオブジェクトから取り出す。
        monstorstatuses = monstorobject.GetMonstorstatuses();

        //int monstorhp; //現在のモンスターのHP

        foreach(Monstorstatus mobstatus in monstorstatuses)
        {
            
        }
    }



    /*private void OnTriggerStay(Collider other)
    {
        //トリガーでプレイヤーを検知した時
        if(other.tag=="Player")
        {
            CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();

            //キャラの現在ＨＰ管理はＨＰＭＰクラスが暫定でしている
            HPMP charactor_status = other.GetComponent<HPMP>(); //キャラクターのステータス
            float distance = Vector3.Distance(gameObject.transform.position, other.transform.position);　//キャラクターとモンスターとの距離

            //キャラクターもしくはモンスターのHPが0でない，かつキャラクターとモンスターとの距離が1.5ｍ以内の時
            if (mobstatus.hp!=0||charactor_status.hp!=0&&distance<=1.5)
            {
                //モンスターがキャラクターを攻撃する

                monstoranimation.SetBool("walk", false);
                monstoranimation.SetBool("attack01", true);

                //キャラクターのHPからモンスターの攻撃力分のダメージが引かれる
                //charactor_status.hp -= mobstatus.attack;

            }
            //キャラクターとモンスターのHPが0でない，かつ両者の距離が10ｍ以内までなら
            else if(mobstatus.hp!=0||charactor_status.hp!=0&&10>=distance)
            {
                 //モンスターがキャラクターを追いかける
                 base.ChaseTarget();
               
            }
            else
            {
                //戦闘終了

            }

        }

    }*/
   


    
}
