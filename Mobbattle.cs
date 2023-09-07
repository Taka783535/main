using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �N���X�T�v�F
/// �����X�^�[����v���C���[�ւ̍U�����s���N���X
/// </summary>

public class Mobbattle : BaseMonstor,BattleInterface
{

    //�����X�^�[��Animator
    private Animator monstoranimation;




    protected override void Start()
    {
        //�i�r���b�V��AI�̐ݒ�
        base.Start();
        
    }

    private void OnTriggerStay(Collider other)
    {
        //�����X�^�[���v���C���[���U������
        MonstorAttack(other);

    }




    //�����X�^�[���_���[�W���󂯂鏈��
    void BattleInterface.IReceiveDamage(int damage)
    {
        
        //�����X�^�[�̌��݃X�e�[�^�X�̎擾,�_���[�W����
        CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();
        mobstatus.hp = mobstatus.hp - damage;


    }


    /******************************************
     * �����X�^�[���v���C���[���U�����郁�\�b�h
     * �����F�v���C���[�̃R���C�_�[
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �����X�^�[���v���C���[���U������B
     ******************************************/
    public void MonstorAttack(Collider player_collider)
    {
        //�����X�^�[��Animator���擾
        monstoranimation = gameObject.GetComponent<Animator>();

        //�����X�^�[�̃g���K�[�Ńv���C���[�����m������
        if (player_collider.tag == "Player")
        {
            //�����X�^�[�̂���(�����X�^�[�̃C���X�^���X����)�̃X�e�[�^�X���擾
            CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();

            //�v���C���[�L�����N�^�[�̃X�e�[�^�X���擾�C�L�����̌��݂g�o�Ǘ��͂g�o�l�o�N���X�����Ă���
            HPMP charactor_status = player_collider.GetComponent<HPMP>(); //�L�����N�^�[�̃X�e�[�^�X
            float distance = Vector3.Distance(gameObject.transform.position, player_collider.transform.position); //�L�����N�^�[�ƃ����X�^�[�Ƃ̋���


            //�L�����N�^�[�ƃ����X�^�[��HP��0�łȂ��C�����҂̋�����6���ȓ�
            if (mobstatus.hp != 0 && charactor_status.hp != 0 && distance < 6)
            {
                
                //����3���ȓ��ł���ΐ퓬�J�n
                if (distance < 3.0)
                {
                    //�����X�^�[���L�����N�^�[���U������

                    monstoranimation.SetBool("walk", false);
                    monstoranimation.SetBool("attack01", true);
                    

                }
                else
                {
                    //�����X�^�[���L�����N�^�[��ǂ�������
                    base.ChaseTarget();
                    monstoranimation.SetBool("attack01", false);
                    monstoranimation.SetBool("walk", true);
                }

            }
            else if (6 < distance)
            {
                //�퓬�I��
                monstoranimation.SetBool("walk", false);
            }

        }
    }




    /********************************************
     * �����X�^�[�̍U�����[�V�����Ɏ��t����֐�
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �����X�^�[���v���C���[�Ƀ_���[�W��^����
     * ******************************************/
    private void MonstorAttackStart()
    {
        //�U���ΏۂƂȂ�v���C���[����_���[�W�����̃C���^�[�t�F�[�X���擾
        GameObject player = gameObject.GetComponent<Mobbattle>().target;
        BattleInterface player_hp = player.GetComponent<BattleInterface>();

        //�v���C���[�Ƀ_���[�W��^����
        player_hp.IReceiveDamage(10);

    }

    

}
