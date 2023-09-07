using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUIManagement : MonoBehaviour
{
    //UI�̉�ʑJ�ڂ𓝊�����N���X

    public GameObject canvas;�@�@�@�@//HP�o�[�����z�u���ꂽ�ʏ�̃L�����o�X
    public GameObject maincanvas;�@�@//������A�C�e�����̃��j���[�I���L�����o�X
    public GameObject itemcanvas;    //�A�C�e���o�b�O��UI���z�u���ꂽ�L�����o�X
    public GameObject equipcanvas;�@ //������ʂ̃L�����o�X
    public GameObject errortext;�@�@ //�A�C�e��������ʂł̃G���[���b�Z�[�W

    //�A�C�e�������֌W��UI
    [SerializeField] private Canvas itemstorecanvas;  //�A�C�e�������p�̃L�����o�X
    [SerializeField] private GameObject countpanel;   //�A�C�e���̍w�����w��p�l��
    [SerializeField] private GameObject buy_checkpanel;    //�w���m�F���
    [SerializeField] private GameObject decided_buyitempanel; //�w���m����

    public Canvas set_canvas {  set { canvas = value.gameObject; } }   //�ʏ�̃L�����o�X��ݒ肷��B



    //UI���z�u���ꂽ�L�����o�X�͕�������C�󋵂ɂ���čœK�ȃL�����o�X�ɐ؂�ւ��B
    //�ȉ��͊e�L�����o�X�̑J�ڃ��\�b�h

    //���C�����j���[
    public void OpenMainmenu()
    {
        canvas.SetActive(false);
        maincanvas.SetActive(true);
    }

    public void CloseMainmenu()
    {
        maincanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //�A�C�e���o�b�N
    public void OpenItembag()
    {
        maincanvas.SetActive(false);
        itemcanvas.SetActive(true);
    }

    public void CloseItembag()
    {
        itemcanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //�������
    public void OpenEquipment()
    {
        maincanvas.SetActive(false);
        equipcanvas.SetActive(true);
        
    }

    public void CloseEquipment()
    {
        equipcanvas.SetActive(false);
        canvas.SetActive(true);
    }


    //�A�C�e���������
    public void OpenItemStoreMenu()
    {
        try
        {
            canvas.SetActive(false);
            itemstorecanvas.gameObject.SetActive(true);
        }
        catch
        {
            Debug.LogError("�Q�ƃG���[�ł��B");
        }
        
    }

    public void CloseItemStoreMenu()
    {
        try
        {
            itemstorecanvas.gameObject.SetActive(false);
            countpanel.SetActive(false);
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(false);
            canvas.SetActive(true);
            errortext.SetActive(false);
        }
        catch
        {
            Debug.LogError("�Q�ƃG���[�ł��B");
        }
        
    }



}
