using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�g�[���[�̃Z���t���Ǘ�����X�N���v�^�u���I�u�W�F�N�g���쐬����B
/// </summary>

[CreateAssetMenu]
public class StoryDialogList : ScriptableObject
{
    [SerializeField] public List<StoryDialogDifinaition> storydialoglist = new List<StoryDialogDifinaition>();

    //�Z���t�f�[�^�ꗗ��Ԃ����\�b�h
    public List<StoryDialogDifinaition> GetStoryDialogList()
    {
        return storydialoglist;
    }
}
