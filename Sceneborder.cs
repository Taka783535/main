using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneborder : MonoBehaviour
{
    //�V�[����؂芷����R�[�h
    //���Q�[���ł̃}�b�v�̐؂芷���͗\���ł��Ȃ��ז{���p


    //�v���C���[��Gameobject
    [SerializeField] private GameObject playercharactor;

    //�Q�[���X�^�[�g��ʂ̑J��
    public void StartScene()
    {
        SceneManager.LoadScene("Base Village");


    }

    

    //�Q�[���N���A�C�Q�[���I�[�o�[��ʂ̑J��
    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title Scene");
        
    }

    //�Q�[���I�[�o�[��ʂւ̑J��
    private void GameOverScene()
    {
        SceneManager.LoadScene("GameOver Scene");
    }
    
    
    //�V�[���؂芷���I�u�W�F�N�g�ɓ�����Ɣ����B�V�[�����؂�ւ��B
    private void OnTriggerEnter(Collider other)
    {
        
        
            //�G�݉�
            if (gameObject.name == "storeborder" && other.gameObject.tag == "Player") //�����X��
            {
                SceneManager.LoadScene("General store interior");
            }
            if (gameObject.name == "storeinteriorborder" && other.gameObject.tag == "Player")�@//�X������
            {
                SceneManager.LoadScene("Base Village");
            }

            //�����t�B�[���h
            if (gameObject.name == "planeborder" && other.tag == "Player")�@//��������
            {
                SceneManager.LoadScene("Field plane");
            }
            if (gameObject.name == "villageborder" && other.gameObject.tag == "Player")  //��������
            {
                SceneManager.LoadScene("Base Village");
            }

            //�B���G���A
            if (gameObject.name == "SecretWood" && other.gameObject.tag == "Player")�@//�������B���G���A
            {
                SceneManager.LoadScene("Sanctuary");
            }
            if (gameObject.name == "sanctuaryborder" && other.gameObject.tag == "Player")�@//�B���G���A������
            {
                SceneManager.LoadScene("Field plane");
            }

        

    }


}
