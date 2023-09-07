using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecretSlime : BaseMonstor
{

    //�{��Ǝ��v�f
    //�B�������X�^�[
    //���̃����X�^�[�͍U�����Ă��Ȃ����v���C���[���ߕt���Ƃ���؂Ɍ������ē�����
    //�ꌩ���ʂɌ�����؂������͑J�ڃI�u�W�F�N�g�ɂȂ��Ă��ĉB���G���A�Ɍq����

    //�����X�^�[�̃A�j���[�^�[
    [SerializeField] private Animator monstor_animator;

    //�����X�^�[�̕��s���[�V������
    private const string walk_motion = "walk";




    protected override void Start()
    {
        //���N���X�ł̓f�t�H���g�Ńv���C���[���ǐՑΏۂƂȂ�ݒ�̂��ߏ�������
        mynavmesh = gameObject.GetComponent<NavMeshAgent>();
    }


    protected override void Update()
    {
        
        MonstorDead();

        //�؂ƃ����X�^�[�̋������K�؂ȋ����ɂȂ����ꍇ�̓����X�^�[��������
        if (1<=(mynavmesh.destination - transform.position).sqrMagnitude && (mynavmesh.destination - transform.position).sqrMagnitude <= 2)
        {
            Destroy(gameObject);
        }

    }



    //�v���C���[���ߕt���Ɩ؂Ɍ������ē�����
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChaseTarget();
            monstor_animator.SetBool(walk_motion, true);
        }

    }


}
