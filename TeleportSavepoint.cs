using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSavepoint : MonoBehaviour
{
    //�L�����N�^�[�܂��̓A�C�e���ɂ��Ďg��
    //�Z�[�u�A�C�e���g�p�ŌĂ΂��
    
    private GameObject playercharactor;

    public void TeleportSave()
    {
        SceneManager.LoadScene("Base Village");
        //playercharactor = gameObject.transform.root.gameObject;
        //playercharactor = GameObject.Find("unitychan");
        //playercharactor.transform.position = Vector3.zero;
    }


}
