using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSkill : MonoBehaviour
{
    Animator warrioranimator;
    
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのアニメーション取得
        warrioranimator = gameObject.GetComponentInParent<Animator>();
        
    }

    



    //初期スキル：スラッシュ
    private void Slash()
    {
        warrioranimator.SetBool("attack01", true);
        //エフェクト発生
        ParticleSystem effect = gameObject.GetComponent<ParticleSystem>();
        effect.Play();
        //音鳴らす
    }

}
