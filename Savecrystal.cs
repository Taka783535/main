using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Savecrystal : MonoBehaviour
{
    //�A�C�e���F�Z�[�u�N���X�^�����g�������̏���
    //���_�ɖ߂�
    private const string responescene = "Base Village";


    public void UseSavecrystal()
    {
       
        SceneManager.LoadScene(responescene);

    }


}
