using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �N���X�T�v�F
/// NPC�̊�{�ƂȂ�N���X
/// NPC�^�p�ɕK�v�ȋ@�\���܂Ƃ߂��Ă���
/// NPC�n�̃N���X�͂��̃N���X���p�����č����B
/// </summary>

public class BaseNPC : MonoBehaviour
{

    //�t�B�[���h

    [SerializeField] private protected NPClist npclist; //NPC�f�[�^���i�[����Ă���X�N���v�^�u���I�u�W�F�N�g
    private List<NPCdifinaition> npcs; //�X�N���v�^�u���I�u�W�F�N�g������o�����f�[�^
    [SerializeField] protected GameObject npcnameboard; //NPC�̖��O���\������郏�[���hUI

    //�I�u�W�F�N�g�����p������
    [SerializeField] protected string npc_name;  //�A�^�b�`����NPC�̖��O�B�e�h���N���X�Ōʂɒl�ݒ�K�v
    [SerializeField] protected string Canvas_name; // �ʏ�\������Ă���UI�L�����o�X�̖��O
    [SerializeField] protected string Npc_talkcanvas;�@//NPC�Ɖ�b���鎞�p�̃L�����o�X�̖��O
    [SerializeField] protected string Npc_comment_panel; //��b�\���p�e�L�X�g�{�b�N�X�̐e�I�u�W�F�N�g
    [SerializeField] protected string Npc_commennt_text; //NPC�̃R�����g���\�������e�L�X�g�{�b�N�X�̖��O
    [SerializeField] protected string Next_button; //�u���ցv�̉�b��i�߂�{�^����

    protected GameObject canvas;�@�@//�ʏ�\������Ă���UI�L�����o�X
    protected GameObject npc_talkcanvas;�@�@//NPC�Ɖ�b���鎞�p�̃L�����o�X
    protected GameObject npc_comment_text;�@//NPC�̃R�����g���\�������e�L�X�g�{�b�N�X

    //NPC�̉�b�t���O�C���̃t���O��true�ɂ���ƃg���K�[�����m�����u�ԉ�b�n�܂�B
    [SerializeField] protected bool npc_talkflg;



    //���\�b�h

    /****************************************
     * NPC�̖��O��NPC�̓���ɕ\�����郁�\�b�h
     * �����FNPC�̖��O
     * �߂�l�F�Ȃ�
     ****************************************/
    protected void ShowNpcName(string npcname)
    {
        //NPC�̃��X�g���擾
        npcs = npclist.GetNPClist();
        foreach (NPCdifinaition param in npcs)
        {
            //�ړI��NPC����肵��
            if (param.npc_name == npcname)
            {
                //NPC�̏�ɖ��O�\��
                npcnameboard.GetComponent<Text>().text = param.npc_name;
            }
               
        }
    }





    



    //NPC�Ɖ�b���J�n���郁�\�b�h,Button�ɓK�p����׃��\�b�h�����Ă���
    public void TalktoNPC()
    {
        npc_talkflg = true;
    }



    //NPC�̃g���K�[�ɐG�ꂽ���b�n�܂�
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Setup_Talk_NPC();
        }

    }


    /********************************************
     * NPC�Ɖ�b���s�����\�b�h
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �w�肵��NPC�̒ʏ��b���b�Z�[�W��\������
     * ******************************************/
    private void Setup_Talk_NPC()
    {
        if (npc_talkflg)
        {
            //NPC�̃��X�g���擾
            List<NPCdifinaition> npc_list = npclist.GetNPClist(); 

            if (npc_name != null)
            {
                foreach (NPCdifinaition param in npc_list)
                {

                    //�Z���t�������o���L�����N�^�[����
                    if (param.npc_name == npc_name)
                    {
                        canvas.SetActive(false);
                        npc_talkcanvas.SetActive(true);

                        //�L�����N�^�[�̒ʏ�̃Z���t��UI�ɕ\������B
                        npc_comment_text.GetComponent<Text>().text = param.npc_comment;
                    }


                }

            }
            else
            {
                //�G���[�F�Z���t�������o��NPC�����ݒ�

                string error_message = "NPC�̖��O��npc_name�Ɋ��蓖�Ăĉ�����";

                //NPC�����蓖�Ă��ĂȂ���Όx��
                Debug.Log(error_message);
            }

            npc_talkflg = false;

        }


    }


   


}
