using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Slime : MonoBehaviour
{
    //�X���C��(�����X�^�[)�Ɏ��t����X�N���v�g
    //�X���C����Quest:�X���C���ގ��I�I�̑Ώۃ����X�^�[�ł��邽�ߐ�p���\�b�h����

    private GameObject player;  //�v���C���[��GameObject



    private void OnTriggerEnter(Collider other)
    {
        //����
        if(other.tag=="Player")
        {
            player = other.gameObject;
        }
    }


    public void SlimeQuest_Addition()
    {
        //�X���C�����|����郂�[�V�����ɂ���
        //�v���C���[���X���C���ގ����󒍂��Ă����瓢����+1

        //�v���C���[��Slime�N�G�X�g���󂯂Ă��邩����
        SlimeQuest slimeQuest = player.GetComponent<SlimeQuest>(); 

        if(slimeQuest!=null)
        {
            slimeQuest.slimecounter += 1;�@�@�@�@�@//������+1
            slimeQuest.counterchange = true;
        }

    }


}
