using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecretSlime : BaseMonstor
{

    //本作独自要素
    //隠しモンスター
    //このモンスターは攻撃してこないがプレイヤーが近付くとある木に向かって逃げる
    //一見普通に見える木だが実は遷移オブジェクトになっていて隠しエリアに繋がる

    //モンスターのアニメーター
    [SerializeField] private Animator monstor_animator;

    //モンスターの歩行モーション名
    private const string walk_motion = "walk";




    protected override void Start()
    {
        //元クラスではデフォルトでプレイヤーが追跡対象となる設定のため書き換え
        mynavmesh = gameObject.GetComponent<NavMeshAgent>();
    }


    protected override void Update()
    {
        
        MonstorDead();

        //木とモンスターの距離が適切な距離になった場合はモンスターが消える
        if (1<=(mynavmesh.destination - transform.position).sqrMagnitude && (mynavmesh.destination - transform.position).sqrMagnitude <= 2)
        {
            Destroy(gameObject);
        }

    }



    //プレイヤーが近付くと木に向かって逃げる
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChaseTarget();
            monstor_animator.SetBool(walk_motion, true);
        }

    }


}
