using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC�̃��X�g���Ǘ�����X�N���v�^�u���I�u�W�F�N�g���쐬����B
/// </summary>

[CreateAssetMenu]
public class NPClist : ScriptableObject
{

    //NPC�̒�`���i�[�p�X�N���v�^�u���I�u�W�F�N�g�𐶐�
    [SerializeField] public List<NPCdifinaition> npcs = new List<NPCdifinaition>();
   

    //NPC�̃��X�g��Ԃ�
    public List<NPCdifinaition> GetNPClist()
    {
        return npcs;
    }

}
