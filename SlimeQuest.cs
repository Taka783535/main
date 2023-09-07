using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlimeQuest : BaseStory
{

    //�{��Ǝ�
    //���̃X�N���v�g�̓N�G�X�g���󂯕t����NPC�Ɏ��t����B
    //�N�G�X�g�T�v�F�X���C����5�̓|��

    //�N�G�X�g�̏󋵂�\�����邽�߃v���C���[�̃`���b�g�����g�p����B
    [SerializeField] private Text chattxt; //�v���C���[�`���b�g���̃e�L�X�g�{�b�N�X
    internal bool receive_quest = false;  //�N�G�X�g����𔻕ʂ���t���O(True�Ŏ��)
    internal static bool clear_quest = false;    //�N�G�X�g�����𔻕ʂ���t���O(True�Ŋ���) �V�[���ԋ��L�K�v


    //Normal_Slime�N���X���瑀�삷��ϐ�
    internal int slimecounter = 0;�@�@//�|�����X���C���𐔂��邽�߂̃J�E���^�[
    internal bool counterchange = false;�@//�J�E���^�[�̒l���ύX���ꂽ���Ƃ����m����t���O(�J�E���^�[�t���O)



    //���N���X�̃��\�b�h�̃I�[�o�[���C�h
    //�O�̃Z���t�̏I������ɃX�g�[���[ID��ύX���邩�ۂ��L�q�ł���
    protected override void PromoteStory_ID()
    {
        //�X�g�[���[ID�̕ύX�E�܂�L�����N�^�[�̃Z���t�̐؂芷�������̃��\�b�h���I�[�o�[���C�h���邱�ƂŐ���ł���
        //�����������܂ŃZ���t�̐i�s���~�߂邱�Ƃ��ł��邵�C�I�[�o�[���C�h���Ȃ��ꍇ�͎~�܂炸�ɃZ���t���i�s����
        
        //�X�g�[���[ID�@0��1�̏���
        if (story_progress == 0 && set_storyid < 1 && clear_quest == false)
        {
            set_storyid += 1;

            if (set_storyid == 1)
            {
                gameObject.GetComponent<SlimeQuest>().receive_quest = true;
            }
        }

        //�N�G�X�g�B������
        if (set_storyid == 2 && dialog_counter == 2)
        {
            SceneManager.LoadScene("GameClear Scene");
        }
    }



    private void Start()
    {
        //�����ݒ�
        chattxt = GameObject.Find("chattxt").GetComponent<Text>();
    }


    private void Update()
    {
        //�X���C���𓢔��������͌��݂̃X���C����������ʒm����B
        if(counterchange==true&&slimecounter<6)
        {
            //�J�E���^�[�t���O��false�ɖ߂��C���݂̃X���C����������\������
            counterchange = false;
            chattxt.text = $"�X���C����|����{slimecounter}/5";
        }

        //�X���C��5�̓|�������̏���
        if (slimecounter == 5)
        {
            //�N�G�X�g�ŋK�肳�ꂽ�������܂ł������烁�b�Z�[�W��\������slimecounter0�N���A
            slimecounter = 0;
            chattxt.text = "���������I���ɂ��郊�[���֕񍐂��悤�I";
            clear_quest = true;
        }

        if (clear_quest == true)  //��������������X�g�[���[ID��2�ɂȂ镔��
        {
            set_storyid = 2;
            clear_quest = false;
        }

    }


    //�N�G�X�g����{�^���������ꂽ���̃��\�b�h
    public void Receive_SlimeQuest()
    {
        receive_quest = true;
    }


    private void OnTriggerExit(Collider other)
    {
        //NPC�̃g���K�[�ɐG��Ă���ԂɃv���C���[���N�G�X�g�����(receive_quest��true�ɕύX)����Έȉ������s�����B
        if(other.tag=="Player")
        {
            Begin_SlimeQuest(other.gameObject);
            
        }
    }


    private void Begin_SlimeQuest(GameObject playercharactor)
    {
        //�N�G�X�g��������ꂽ���̏���
        //�N�G�X�g��������ꂽ�����������b�Z�[�W���`���b�g���ɕ\��
        if (receive_quest == true)
        {
            playercharactor.AddComponent<SlimeQuest>();
            chattxt.text = "Quest:�u�X���C���ގ�!!�v��������܂����I";
        }
    }

    


}
