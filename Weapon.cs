using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************
 * ����̃p�����[�^���`����N���X
 * Weaponlist(�X�N���v�^�u���I�u�W�F�N�g)�Ń��X�g���E�Ǘ������
 **************************************************************/

[System.Serializable]
public class Weapon
{
    public int weapon_id;  //�����ID�ԍ�
    public GameObject weapon; //�����GameObject
    public GameObject weapon_icon; //�o�b�O���ɕ\�����镐��̃A�C�R��
    public string weapon_name; //����̖��O
    public int attack; //����̍U����
    public Battleinformation.Attribute attribute; //����̑���
    public string weapon_detail; //����̐�����

}
