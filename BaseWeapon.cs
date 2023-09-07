using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �N���X�T�v�F
/// ����̊�{�ƂȂ�N���X
/// ����^�p�ɕK�v�ȋ@�\���܂Ƃ߂��Ă���
/// ����n�̃N���X�͂��̃N���X���p�����č����B
/// </summary>

public class BaseWeapon : MonoBehaviour
{
    

    public GameObject player;  //����̐e�I�u�W�F�N�g�ł���v���C���[��GameObject

    //����̍U����
    public int attack;


    //�G�ꂽ���̂Ƀ_���[�W��^���鏈��
    private void OnTriggerEnter(Collider other)
    {
        BattleInterface battleInterface = other.gameObject.GetComponent<BattleInterface>();

        if(battleInterface!=null)
        {
          
            battleInterface.IReceiveDamage(attack);

        }

    }
    

}
