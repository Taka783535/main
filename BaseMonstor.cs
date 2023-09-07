using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// クラス概要：
/// モンスターの基本となるクラス。
/// モンスターに付いているAIや倒された時の処理などモンスターの基本的な行動が定義・設定されている。
/// モンスター系のクラスはこのクラスを継承して作られる。
/// </summary>

public class BaseMonstor : MonoBehaviour
{


    public GameObject target;        //モンスターの追跡対象
    protected NavMeshAgent mynavmesh;   //ナビメッシュ

    [SerializeField] private string walkflg;     //モンスターの歩行モーションの名前
    [SerializeField] private string attackflg;   //モンスターの攻撃モーションの名前
    [SerializeField] private string deadflg;     //モンスターが倒されるモーションの名前




    // Start is called before the first frame update
    protected virtual void Start()
    {
        //navimesh(AI)の設定
        mynavmesh = gameObject.GetComponent<NavMeshAgent>();
        target = charactermove.player;
        
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        //モンスターのHPが0になったら倒される
        MonstorDead();
    }



    /*****************************************************
     * モンスターが倒された時のメソッド
     * 引数：なし
     * 戻り値：なし
     * 概要：
     * モンスターのHP0でモンスターが倒れるモーションを再生
     *****************************************************/
    protected void MonstorDead()
    {
        //HPが0になったら倒れるモーションを行う
        if(gameObject.GetComponent<CurrentMonstorStatus>().hp<=0)
        {
            Animator mobanim=gameObject.GetComponent<Animator>();
            mobanim.SetBool(walkflg, false);
            mobanim.SetBool(attackflg, false);
            mobanim.SetBool(deadflg, true); 
            
        }
    }



    /****************************************************************
     * モンスターが倒された時アニメーションイベントで呼ばれるメソッド
     * 引数：なし
     * 戻り値：なし
     * 概要：
     * モンスターが倒されるアニメーションに装着し，
     * 対象のモンスターを破壊する。
     * **************************************************************/
    void MonstorBrake()
    {

        //モンスターを破壊する。
        Destroy(gameObject);

    }


    //モンスターのAIに追跡対象を設定する。
    protected void ChaseTarget()
    {

        //追跡対象の設定
        mynavmesh.SetDestination(target.transform.position);
        
    }


   

}
