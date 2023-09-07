using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Slime : MonoBehaviour
{
    //スライム(モンスター)に取り付けるスクリプト
    //スライムはQuest:スライム退治！！の対象モンスターであるため専用メソッドあり

    private GameObject player;  //プレイヤーのGameObject



    private void OnTriggerEnter(Collider other)
    {
        //準備
        if(other.tag=="Player")
        {
            player = other.gameObject;
        }
    }


    public void SlimeQuest_Addition()
    {
        //スライムが倒されるモーションにつける
        //プレイヤーがスライム退治を受注していたら討伐数+1

        //プレイヤーがSlimeクエストを受けているか判定
        SlimeQuest slimeQuest = player.GetComponent<SlimeQuest>(); 

        if(slimeQuest!=null)
        {
            slimeQuest.slimecounter += 1;　　　　　//討伐数+1
            slimeQuest.counterchange = true;
        }

    }


}
