using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����X�^�[�̃X�e�[�^�X��񂪒�`����Ă���N���X
/// Monstorlist�N���X�^�̃X�N���v�^�u���I�u�W�F�N�g�ŕۑ������B
/// </summary>
/// 

[System.Serializable]
public class Monstorstatus 
{
    public GameObject monstorimage;  //�����X�^�[��3D�I�u�W�F�N�g
    public string monstorname; //�����X�^�[�̖��O
    public Battleinformation.Attribute attribute;   //�����X�^�[�̑���
    public int hp;             //HP
    public int attack;         //�U����
    public int defence;        //�h���
    public int dropitem1_id; //��1�h���b�v�A�C�e����ID
    public int dropitem2_id; //��2�h���b�v�A�C�e����ID

}
