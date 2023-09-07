using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************
 * �v���C���[�̃Z�[�u�f�[�^
****************************/

[System.Serializable]
public class SaveData 
{
    internal string playername;  //�v���C���[��
    internal int playerlevel = 1; //�v���C���[�̃��x��
    internal int hp = 0;     //HP
    internal int mp = 0;     //MP
    internal int str = 0;    //�U����
    internal int magic = 0;   //���@�U����
    internal int vit = 0;    //�̗́E�h���
    internal int agi = 0;    //�q����
    internal int dex = 0;    //��p
    internal int money = 1000;�@�@//������
    internal Vector3 currentpoint;   //���݂̃v���C���[���W
    internal string scenename;   //���݃v���C���[�����݂���V�[��(�}�b�v)
}
