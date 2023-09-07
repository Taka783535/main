using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �N���X�T�v�F
/// �L�����N�^�[�����j���[���X�e�[�^�X�̃X�e�[�^�X��ʂŎg�p����N���X
/// ���݂̃v���C���[�̃X�e�[�^�X�\���Ȃǂ��s���B
/// </summary>

public class charactorstatus : MonoBehaviour
{
    [SerializeField] private Text leveltext; //�L�����N�^�[���x���̃e�L�X�g�\��
    [SerializeField] private Slider str; //str�̃X�e�[�^�X�o�[
    [SerializeField] private Slider magic; //magic�̃X�e�[�^�X�o�[
    [SerializeField] private Slider vit; //vit�̃X�e�[�^�X�o�[
    [SerializeField] private Slider agi; // agi�̃X�e�[�^�X�o�[
    [SerializeField] private Slider dex; //dex�̃X�e�[�^�X�o�[

    ///SaveandLoadManager saver = new SaveandLoadManager();

    // Start is called before the first frame update
    void Start()
    {
        //�X�e�[�^�X��ʏ����ݒ�
        SetStatus();
    }


    /********************************************************
     * �X�e�[�^�X��ʂ̐ݒ�
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v:�X�e�[�^�X��ʂɌ��݂̃X�e�[�^�X��Ԃ𔽉f������
     ********************************************************/
    internal void SetStatus()
    {
        SaveData save;

        //�Z�[�u�f�[�^��ǂݍ���
        save = SaveandLoadManager.DataLoad();

        if(save!=null)
        {
            //���x���\��
            leveltext.text = save.playerlevel.ToString();

            //str,int,vit�Ȃǂ̊�{�X�e�[�^�X�̏���l��100
            //�X���C�_�[�Ɋe�X�e�[�^�X�𔽉f
            str.value = (float)save.str/100;
            magic.value =(float) save.magic / 100;
            vit.value =(float) save.vit / 100;
            agi.value =(float) save.agi / 100;
            dex.value =(float) save.dex / 100;

        }
    }

}
