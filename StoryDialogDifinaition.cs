using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�g�[���[�̃Z���t����`����Ă���N���X
/// StoryDialogList�N���X�ŃX�N���v�^�u���I�u�W�F�N�g�Ɋi�[�����B
/// </summary>

[System.Serializable]
public class StoryDialogDifinaition 
{
    public int story_id;  //�X�g�[���[��ID
    public story_kinds story_kind;�@//�X�g�[���[�̎��
    public string[] story_dialog = new string[10]; //�X�g�[���[�̃Z���t�╶��

    //�X�g�[���[�̎��
    public enum story_kinds
    {
        tutrial, //�`���[�g���A��
        story1, //1��
        story2  //2��
    }
}
