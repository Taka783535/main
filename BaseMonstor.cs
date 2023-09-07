using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// �N���X�T�v�F
/// �����X�^�[�̊�{�ƂȂ�N���X�B
/// �����X�^�[�ɕt���Ă���AI��|���ꂽ���̏����Ȃǃ����X�^�[�̊�{�I�ȍs������`�E�ݒ肳��Ă���B
/// �����X�^�[�n�̃N���X�͂��̃N���X���p�����č����B
/// </summary>

public class BaseMonstor : MonoBehaviour
{


    public GameObject target;        //�����X�^�[�̒ǐՑΏ�
    protected NavMeshAgent mynavmesh;   //�i�r���b�V��

    [SerializeField] private string walkflg;     //�����X�^�[�̕��s���[�V�����̖��O
    [SerializeField] private string attackflg;   //�����X�^�[�̍U�����[�V�����̖��O
    [SerializeField] private string deadflg;     //�����X�^�[���|����郂�[�V�����̖��O




    // Start is called before the first frame update
    protected virtual void Start()
    {
        //navimesh(AI)�̐ݒ�
        mynavmesh = gameObject.GetComponent<NavMeshAgent>();
        target = charactermove.player;
        
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        //�����X�^�[��HP��0�ɂȂ�����|�����
        MonstorDead();
    }



    /*****************************************************
     * �����X�^�[���|���ꂽ���̃��\�b�h
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �����X�^�[��HP0�Ń����X�^�[���|��郂�[�V�������Đ�
     *****************************************************/
    protected void MonstorDead()
    {
        //HP��0�ɂȂ�����|��郂�[�V�������s��
        if(gameObject.GetComponent<CurrentMonstorStatus>().hp<=0)
        {
            Animator mobanim=gameObject.GetComponent<Animator>();
            mobanim.SetBool(walkflg, false);
            mobanim.SetBool(attackflg, false);
            mobanim.SetBool(deadflg, true); 
            
        }
    }



    /****************************************************************
     * �����X�^�[���|���ꂽ���A�j���[�V�����C�x���g�ŌĂ΂�郁�\�b�h
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �����X�^�[���|�����A�j���[�V�����ɑ������C
     * �Ώۂ̃����X�^�[��j�󂷂�B
     * **************************************************************/
    void MonstorBrake()
    {

        //�����X�^�[��j�󂷂�B
        Destroy(gameObject);

    }


    //�����X�^�[��AI�ɒǐՑΏۂ�ݒ肷��B
    protected void ChaseTarget()
    {

        //�ǐՑΏۂ̐ݒ�
        mynavmesh.SetDestination(target.transform.position);
        
    }


   

}
