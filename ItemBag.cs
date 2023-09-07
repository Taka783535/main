using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�A�C�e���o�b�O���Ǘ�����N���X

public class ItemBag : MonoBehaviour
{
    private GameObject inspectorname;
    private GameObject inspector;


    //�����F�A�C�e�����C�A�C�e���̐���
    //�A�C�e���I����ʂɂāC�����Ŏw�肵�����e���A�C�e���ڍ׃E�B���h�E�֕\������B
    public void SelectItem(string itemname,string iteminspector)
    {
        inspectorname = GameObject.Find("Itemname");
        inspector = GameObject.Find("ItemInspectorText");
        inspectorname.GetComponent<Text>().text = itemname;
        inspector.GetComponent<Text>().text = iteminspector;
    }


    //�A�C�e���g�p�̃��\�b�h
    //�����F�A�C�e��ID�C�w�肵���A�C�e�����g�p����B
    public void UseItem(int itemid)
    {

        //�A�C�e��ID�Ŏg�p����A�C�e���𔻕�
        switch(itemid)
        {
            case 1:    //�|�[�V����
                Potion potion = new Potion();
                potion.Usepotion(gameObject,itemid);
                break;

            case 2:   //�]�ڃN���X�^��
                Savecrystal savecrystal = new Savecrystal();
                savecrystal.UseSavecrystal();
                break;

            default:
                break;
        }
    }



}
