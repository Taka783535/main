using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************
 * �S�ẴA�C�e����ۑ�����X�N���v�^�u���I�u�W�F�N�g
 * �p�����[�^�[��`�N���X�ł���Item�N���X�ƕ����Ďg�p����B
 *********************************************************/

[CreateAssetMenu]
public class Itemlist : ScriptableObject
{
    //�A�C�e���ۑ��p�X�N���v�^�u���I�u�W�F�N�g�̍쐬
    public List<Item> items = new List<Item>();

    public List<Item> GetItemList()
    {
        return items;
    }

}
