using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCdifinaition 
{

    //NPC�̊�{����`�N���X
    public string npc_name;  //NPC�̖��O
    public int npc_level;�@�@//NPC�̃��x��
    public int hp = 0;     //HP
    public int mp = 0;     //MP
    public int str = 0;    //�U����
    public int magic = 0;   //���@�U����
    public int vit = 0;    //�̗́E�h���
    public int agi = 0;    //�q����
    public int dex = 0;    //��p
    public string npc_comment; //NPC�̉�b���e
    public string npc_questcomment1; //�N�G�X�g�̉�b���e(�K�v�ɉ����đ��₷)
    public int quest_experience1; //�N�G�X�g�̌o���l
    public int quest_itemid1; //�N�G�X�g�̕�V�A�C�e��

}
