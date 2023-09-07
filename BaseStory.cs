using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//�p����ŃX�g�[���[ID��ݒ肵�Ă�������
//�X�g�[���[ID=set_storyid

public class BaseStory : MonoBehaviour
{

    /**************************************************************************************
     * �N���X�T�v
     * �X�g�[���[�̊e�Z���t���i�[�E�Ǘ�����X�N���v�^�u���I�u�W�F�N�g(�f�[�^�x�[�X)������C
     * ���߂ɂ��̃X�N���v�^�u���I�u�W�F�N�g����p�ӂ������X�g�փf�[�^���R�s�[����B
     * �Ȍ�C���̃��X�g�𒆐S�ɑ��삷��
     * 
     * �p��
     * �Z���t�F
     * �����ł̓��X�g��1��1�̃f�[�^�̂��ƁB�e�L�����N�^�[�̔�����1��̂��ƁB
     **************************************************************************************/


    [SerializeField] private protected StoryDialogList story_daialog_list; //�X�g�[���[�̃Z���t����`���ꂽ�X�N���v�^�u���I�u�W�F�N�g
    private List<StoryDialogDifinaition> story_dialog; //�X�N���v�^�u���I�u�W�F�N�g������o�������X�g�`���̃Z���t�f�[�^
    [SerializeField] protected bool story_flg = true; //�X�g�[���[�t���O(�X�g�[���[�ƒʏ�̃Z���t��؂芷����,���NPC�Ŏg��)
    [SerializeField] public static int set_storyid=0; //�p����Őݒ肷��X�g�[���[ID, ���X�g����C�ӂ̃Z���t�̈����o���Ɏg�p�B
    protected int story_progress=0; //�X�g�[���[�̐i�s��(�X�g�[���[ID(set_storyid�̒l)���ۑ�����Ă���)

    
    //�ʏ��NPC�p�̊e��UI�L�����o�X
    private GameObject canvas;   //�v���C���[�̒ʏ�̃L�����o�X
    private GameObject npc_talkcanvas;    //NPC�Ɖ�b����p��UI���z�u����Ă���L�����o�X
    private GameObject npc_comment_text;  //NPC�̉�b���\�������UI

    protected int dialog_counter = 0; //���X�g�̒��̃Z���t���i�[����Ă���z��ɃA�N�Z�X���邽�߂̃J�E���^

    private int all_dialog_counter; //1�̃��X�g�ɓ����Ă���Z���t�̍ő吔


    private bool callonce=false; //1�x�����Ă΂�Ȃ����\�b�h�Ɏg���t���O

    protected bool clear_slime_quest = false;  //����󒍂���X���C�������N�G�X�g�̃N���A�𔻕ʂ���t���O

    private bool search_button=false; //�N�G�X�gNPC�ɘb�����鎞�����{�^��

    private GameObject actionbutton;



    public void StoryReset()
    {
        //�X�g�[���[�̐i�s�󋵂̃��Z�b�g
        set_storyid = 0;
        dialog_counter = 0;
        all_dialog_counter = 0;
        callonce = false;
    }


    //Button(UI)�ɓK�p�B�N�G�X�gNPC�ɘb�����鎞�ɋ߂��ŉ����ƃX�g�[���[�̉�b���n�܂�
    public void PushSearchButton()
    {
        search_button = true;
    }


    //�N�G�X�g�\���{�[�h�Ȃǂ̌����E�o�^����
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "NPC")
        {

            if (other.gameObject.tag== "Player")
            {
                canvas = other.gameObject.transform.Find("Canvas").gameObject;
                actionbutton = canvas.transform.Find("actionbutton").gameObject;
                npc_talkcanvas = other.gameObject.transform.Find("NPCTalkCanvas").gameObject;
                npc_comment_text = npc_talkcanvas.transform.Find("npc_comment_panel").Find("npc_comment_text").gameObject;

                //�A�N�V�����{�^���ɃC�x���g��ݒ�
                Button[] buttons = GameObject.FindObjectsOfType<Button>();

                foreach (Button btn in buttons)
                {
                    if (btn.name == "actionbutton")
                    {
                        btn.onClick.AddListener(PushSearchButton);
                    }

                }

            }

        }

    }


    //�N�G�X�gNPC�ɘb�����鏈���ƃX���C�������N�G�X�g�̃N���A����̏���
    private void OnTriggerStay(Collider other)
    {

        //�N�G�X�gNPC�̋߂��Ń{�^���������Ɖ�b���n�܂�
        if (callonce == false && search_button == true&&gameObject.tag== "NPC")
        {
            if (other.tag == "Player" && story_flg == true)
            {
                Show_Story(set_storyid);

                //���փ{�^���C�x���g�̓o�^����
                Button[] butt = GameObject.FindObjectsOfType<Button>();

                foreach(Button btn in butt)
                {
                    if(btn.name== "next_button")
                    {
                        btn.onClick.AddListener(Next_Story_Comment);
                    }
                }
            }

            search_button = false;
            callonce = true;
        }

        

    }


    private void OnTriggerExit(Collider other)
    {

        if (gameObject.tag == "NPC")
        {
            //�t���O�̒l���Z�b�g����
            callonce = false;
        }

    }


    protected virtual void PromoteStory_ID()
    {
        //�I�[�o�[���C�h�p���\�b�h
        //�p����̃N���X�ł��̃��\�b�h�����������Ȃ��ꍇ�̓Z���t���I���㎟�̃Z���t�֐؂�ւ��
        //�܂�NPC�͓����Z���t���������ƂȂ��V�����Z���t�ɐ؂�ւ��B

        set_storyid += 1;
        
    }




    /*****************************************
     * �X�g�[���[�̉�b���J�n���郁�\�b�h
     * �����F�\������X�g�[���[�̃X�g�[���[ID
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �����Ŏw�肵���X�g�[���[��\������
     * ***************************************/
    private void Show_Story(int story_id)
    {
        //�X�g�[���[�̉�b��\������ꍇ
        if (story_flg)
        {

            if(story_dialog==null)
            {
                //�X�g�[���[�̃Z���t�f�[�^��p�ӂ������X�g�Ɏ擾
                story_dialog = story_daialog_list.GetStoryDialogList();
            }
            

            foreach (StoryDialogDifinaition serifu in story_dialog)
            {
                
                //�擾�������X�g����C�ӂ̃Z���t�������o������(�Z���t�̎w��͈���)
                if (serifu.story_id == story_id)
                {
                    canvas.SetActive(false);
                    
                    npc_talkcanvas.SetActive(true);
                    

                    //�C���f�b�N�X�Ɏ��o�����Z���t-1�̒������L�^���Ă���(�Z���t�̕������B��Ŏg��)
                    all_dialog_counter = serifu.story_dialog.Length-1;

                    //���肵���X�g�[���[�̃Z���t��UI�ɕ\������B
                    npc_comment_text.GetComponent<Text>().text = serifu.story_dialog[dialog_counter];


                }


            }


        }
    }

   
    /************************************
    *���ց@�{�^�����N���b�N���ꂽ���̏���
    *�����F�Ȃ�
    *�߂�l�F�Ȃ�
    *�T�v�F�Z���t��1�i�߂�B
    *************************************/
    public void Next_Story_Comment()
    {
        if (story_flg)
        {
            //�Z���t���r���̏ꍇ
            if (dialog_counter < all_dialog_counter )
            {
                //�Z���t��i�߂�
                dialog_counter += 1;
                Show_Story(set_storyid);

            }
            //�Z���t���I������ꍇ
            else
            {
                npc_talkcanvas.SetActive(false);
              
                canvas.SetActive(true);
               

                //�Q�[���N���A���������̏����Bdialog_counter�̏������O�Ɏ��s����K�v������ׂ����ɔz�u
                if (set_storyid == 2 && dialog_counter == 2)
                {
                    SceneManager.LoadScene("GameClear Scene");
                }


                PromoteStory_ID();

                //�Z���t�J�E���^�[0�N���A
                dialog_counter = 0;

                
            }

        }
    }



}
