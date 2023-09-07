using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPMP : MonoBehaviour,BattleInterface
{
    
    
    //HP・MP・能力値
    public int hp = 1000;
    public int mp = 500;
    public int str = 0;
    public int magic = 0;
    public int vit = 0;
    public int agi = 0;
    public int dex = 0;
    public int money = 1000;

    private double defaulthpscale;  //初期HPでのＨＰスケール
    public GameObject hpbar;

    [SerializeField] private string parameter_battlestandby;  //攻撃準備モーションのフラグ(bool値)
    [SerializeField] private string parameter_attack;　//攻撃モーションのフラグ(bool値)
    [SerializeField] private string parameter_gameover;  //ゲームオーバーモーションのフラグ(bool値)

    [SerializeField] private string gameover_scene;  //ゲームオーバーした時に遷移するシーン名


    
    void Start()
    {
        defaulthpscale = DefaultHP();
    }


    private void Update()
    {
        //プレイヤーのHPが0になった時の処理
        if (this.hp <= 0)
        {
            Animator player_animator = gameObject.GetComponent<Animator>();
            player_animator.SetBool(parameter_attack, false);
            player_animator.SetBool(parameter_battlestandby, false);
            player_animator.SetBool(parameter_gameover, true);
        }
    }


    //規定のHP設定メソッド,HPの初期値は1000,HPバーにおいてHP1分のスケール値(x)を返す
    public double DefaultHP()
    {
        //HPを初期値の1000として計算
        return 1.8 / 1000;
    }



    //ダメージ受けた時の処理
    void BattleInterface.IReceiveDamage(int damage)
    {
        hp -= damage;
        Vector3 hitpoint = new Vector3((float)defaulthpscale*hp, 1f, 1f);

        //HP0の時HPバーが振り切らないよう設定
        if (hpbar.transform.localScale != new Vector3(0, 1, 1))
        {
            hpbar.transform.localScale = hitpoint;
        }
    }


    //HP回復処理
    public void Heal(double hpscaleX)
    {
        Vector3 hitpoint = new Vector3((float)hpscaleX * hp, 1f, 1f);

        //最大HPの時HPバーが振り切らないよう設定
        if (hpbar.transform.localScale != new Vector3((float)1.8, 1, 1))
        {
            hpbar.transform.localScale = hitpoint;
        }
    }


    //プレイヤーのHPが0になった時のメソッド,プレイヤーの倒されるモーションに付ける
    public void PlayerDown(GameObject player)
    {
        if(player.GetComponent<HPMP>().hp<=0)
        {
            SceneManager.LoadScene(gameover_scene);
        }

    }
    
    

}
