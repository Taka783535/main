using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerchat : MonoBehaviour
{
    //�`���b�g���͏ꏊ,�`���b�g�\���ꏊ
    public GameObject chatfield;
    public GameObject chatpaneltxt;


    //�`���b�g�{�^���N���b�N������Ă΂��
    //�`���b�g�t�B�[���h�o��,�K��ł�50�����܂�
    public void Getchatfield()
    {
        if (chatfield.activeInHierarchy == false)
        {
            chatfield.SetActive(true);
        }
        else
        {
            chatfield.SetActive(false);
        }
    }

    //���͏���,EndEdit�C�x���g�ŌĂ΂��
    public void Getchatcharactor()
    {
      
        //chatxt==�`���b�g���͏ꏊ�ɓ��͂��ꂽ�l,chatpaneltx==�`���b�g�p�l���̃e�L�X�g�{�b�N�X
        Text chattext = chatfield.GetComponentInChildren<Text>();
        string fowardtext = chatpaneltxt.GetComponent<Text>().text;
        chatpaneltxt.GetComponent<Text>().text= fowardtext+gameObject.transform.parent.name+": "+ chattext.text+Environment.NewLine;
        chatfield.GetComponent<InputField>().text = "";
        chatfield.SetActive(false);
    }


}
