using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
 * �A�C�e���̃p�����[�^���`����N���X
 * Itemlist(�X�N���v�^�u���I�u�W�F�N�g)�Ń��X�g�������
 *******************************************************/

[System.Serializable]
public class Item 
{
    public int itemid; //�A�C�e��ID
    public GameObject itemimage; //�A�C�e���摜
    public string itemname; //�A�C�e����
    public int item_quantity=0; //�A�C�e���̌�(�A�C�e���o�b�O�N���X�ł̂ݎg�p�B�����l0)
    public string itemdetail; //�A�C�e���̐�����
}
