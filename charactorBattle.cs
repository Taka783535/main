using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�����N�^�[���烂���X�^�[�ւ̍U������`���ꂽ�N���X
public class charactorBattle : MonoBehaviour
{

    

    [SerializeField] GameObject player; //�v���C���[��3D�I�u�W�F�N�g
    [SerializeField] Animator normalanim;  //�v���C���[��Animator
    [SerializeField] private string parameter_battlestandby; //�U���������[�V�����̐؂芷���t���O��(bool�l)
    [SerializeField] private string parameter_attack;        //�U�����[�V�����̐؂芷���t���O(bool�l)

    public GameObject weapon;           //���ݑ������̕���
    [SerializeField] GameObject charactorhand;    //�L�����N�^�[�̎�̃I�u�W�F�N�g�E������������鎞�Ɏg�p�B

    private Vector3 weapon_position; //����̏����ʒu�C��������܂����ɕK�v
    private Quaternion weapon_rotation; //����̏�����]���W�C��������܂����K�v
    [SerializeField] GameObject charactor_back; //��������܂������C����̐e�ƂȂ�I�u�W�F�N�g(�ʏ�̓v���C���[�̔w��)

    [SerializeField] GameObject normalui; //�ʏ��UI�L�����o�X

    private AudioSource weapon_audio;  //����̃T�E���h�̉���


    public AudioSource WeaponAudio { get { return weapon_audio; } set { weapon_audio = value; } }  //����̉����̐ݒ�






  
    void Start()
    {
        //����������

        //�A�j���[�V�����Z�b�g
        normalanim = player.GetComponent<Animator>();

        //����̃��[�J�����W�L�^�B��������܂����K�v�ɂȂ�B
        weapon_position = weapon.transform.localPosition;
        weapon_rotation = weapon.transform.localRotation;
    }


    private void Update()
    {
        //�����L�����N�^�[������͂�������
        if (Input.anyKeyDown&&normalui.activeInHierarchy==true)
        {
            //Enter�L�[�Ȃ�΍U���s���Ɉڂ�
            if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetMouseButtonDown(0))
            {
                PlayerAttack();

            }
            //Enter�L�[�ȊO�ł���΍U�����I�����Ēʏ탂�[�V�����ɖ߂�
            else
            {
             
                normalanim.SetBool(parameter_attack, false);
                normalanim.SetBool(parameter_battlestandby, false);

                //��������܂�+����̈ʒu����
                weapon.transform.SetParent(charactor_back.transform, false);
                weapon.transform.localPosition = weapon_position;
                weapon.transform.localRotation = weapon_rotation;

            }

        }

    }


   
    

    /**********************************************
     * �v���C���[���U������ׂ̃��\�b�h
     * ����:�U���Ώۂ̃R���C�_�[
     * �߂�l�F�Ȃ�
     * �T�v:
     * �v���C���[���퓬�ҋ@���[�V�����ֈڍs����
     * ���̏�ԂŎw��̃{�^������������
     * �v���C���[�����̏�Œʏ�U�����s��
     **********************************************/
    public void PlayerAttack()
    {
        
        //�퓬�ҋ@���[�V����(������\���Ă�����)�ֈڍs
        if(normalanim.GetBool(parameter_battlestandby)==false)
        {
            //������\����
            normalanim.SetBool(parameter_battlestandby, true);

            //����̈ʒu����
            weapon.transform.SetParent(charactorhand.transform,false);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }
        else
        {
            
            //���ɐ퓬�ҋ@���[�V�����ł������ꍇ�͍U�����J�n����B
            normalanim.SetBool(parameter_attack, true); //�U�����[�V�����ֈڍs
            

        }
        
        
    }



    //�U���J�n���ɌĂ΂�郁�\�b�h�B�L�����N�^�[�̍U���A�j���[�V����(�A�j���[�V�����C�x���g)�ŌĂяo�����B
    void PlayerAttackStart()
    {
        //����̓����蔻���ON�ɂ���B
        weapon.GetComponent<CapsuleCollider>().enabled = true;

        
        if (weapon_audio != null)
        {
            weapon_audio.enabled = true;
        }

    }

    //�U���I�����ɌĂ΂�郁�\�b�h�B�L�����N�^�[�̍U���A�j���[�V����(�A�j���[�V�����C�x���g)�ŌĂяo�����B
    void PlayerAttackEnd()
    {
        //����̓����蔻���OFF�ɂ��čU���ҋ@���[�V�����ɖ߂�B
        weapon.GetComponent<CapsuleCollider>().enabled = false;
        normalanim.SetBool(parameter_attack, false);

        if (weapon_audio != null)
        {
            weapon_audio.enabled = false;
        }

    }





}
