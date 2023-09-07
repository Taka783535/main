using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[���������X�^�[�̃X�e�[�^�X�������A���^�C���ŊǗ�����N���X
//�����X�^�[���ƂɃA�^�b�`���Ďg���B

public class CurrentMonstorStatus : MonoBehaviour
{

    [SerializeField] private Monstorlist monstorlist;
    private List<Monstorstatus> monstorstatus;

    public string monstorname; //�����X�^�[�̖��O
    public Battleinformation.Attribute attribute;   //�����X�^�[�̑���
    public int hp = 100;             //HP
    public int attack = 10;         //�U����
    public int defence = 5;        //�h���
    public int dropitem1_id; //��1�h���b�v�A�C�e����ID
    public int dropitem2_id; //��2�h���b�v�A�C�e����ID


    private void Start()
    {
        Setup_Monstorstatus();
    }


    //�����X�^�[�̃X�e�[�^�X���̏��������s�����\�b�h
    private void Setup_Monstorstatus()
    {
        //�����X�^�\�p�X�N���v�^�u���I�u�W�F�N�g���烂���X�^�[�̃��X�g���o���B
        monstorstatus = monstorlist.GetMonstorstatuses();

        //�擾���������X�^�[���X�g���炳��ɌX�̃����X�^�[�̃X�e�[�^�X�����o��
        foreach(Monstorstatus mobstatus in monstorstatus)
        {
            //�e�X�e�[�^�X�̒l���R�s�[���C�����X�^�[�̃X�e�[�^�X�l��������
            if(mobstatus.monstorname==gameObject.name)
            {
                this.monstorname = mobstatus.monstorname;
                this.attribute = mobstatus.attribute;
                this.hp = mobstatus.hp;
                this.attack = mobstatus.attack;
                this.defence = mobstatus.defence;
                this.dropitem1_id = mobstatus.dropitem1_id;
                this.dropitem2_id = mobstatus.dropitem2_id;
            }

        }

    }

    


}
