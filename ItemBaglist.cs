using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************************
 * �A�C�e���o�b�O���̃A�C�e����ۑ�����X�N���v�^�u���I�u�W�F�N�g
 * �A�C�e���f�[�^��`�N���X�ł���Item�N���X�ƕ����Ďg���B
 ****************************************************************/

[CreateAssetMenu]
public class ItemBaglist : ScriptableObject
{
    //�A�C�e���o�b�O���A�C�e���i�[�p�X�N���v�^�u���I�u�W�F�N�g�̍쐬
    public List<Item> items = new List<Item>();


    public List<Item> GetItemBaglist()
    {
        return items;
    }

}
