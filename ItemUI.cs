using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] protected ItemBaglist item_sobj; //�A�C�e���o�b�O�̃f�[�^�x�[�X(�X�N���v�^�u���I�u�W�F�N�g)
    private List<Item> items; //�f�[�^�x�[�X������o�����A�C�e��

    //�A�C�e���o�b�O����p�ϐ�
    [SerializeField] private Itemlist itemlist;
�@�@[SerializeField] private GameObject itemboardpanel;

    [SerializeField] private GameObject itemname_display;     //�A�C�e���o�b�O���ɂ����ăA�C�e���̖��O��\������UI
    [SerializeField] private GameObject itemdetail_display;�@ //�A�C�e���o�b�O���ɂ����ăA�C�e���̏ڍׂ�\������UI


    private const string itemname_panel = "Itemname";
    private const string item_inspectorpanel = "ItemInspectorText";


    private void Start()
    {
        int save_crystal = 2;
        GetItem(save_crystal);
    }


    //�^�����A�C�e��ID�̃A�C�e�����Ɛ��������A�C�e���o�b�O���̃e�L�X�g�{�b�N�X�ɕ\������B
    public void ItemSet(int bagitem_id)
    {
        items = item_sobj.GetItemBaglist(); //�e�A�C�e���̃��X�g���擾

        foreach (Item item in items)
        {

            if (item.itemid == bagitem_id)
            {
                //�ϐ���null�Ȃ�G���[�ɂȂ�̂őR��ׂ��I�u�W�F�N�g��ݒ肷��B
                if(itemname_display==null)
                {

                    itemname_display = GameObject.Find(itemname_panel);

                }
                if(itemdetail_display==null)
                {

                    itemdetail_display = GameObject.Find(item_inspectorpanel);

                }

                //���O�C�������\��
                itemname_display.GetComponent<Text>().text = item.itemname;
                itemdetail_display.GetComponent<Text>().text = item.itemdetail;
            }

        }

    }


    //�A�C�e���h�c�Ŏw�肵���A�C�e���̌���Ԃ����\�b�h
    protected int GetItemQuantity(int bagitem_id)
    {
        int numberofitem = 0;
        items = item_sobj.GetItemBaglist(); //�e�A�C�e���̃��X�g���擾

        foreach (Item item in items)
        {
            if (item.itemid == bagitem_id)
            {
                //�A�C�e�����L�^
                numberofitem = item.item_quantity;
            }

        }

        //�A�C�e���̌���Ԃ��B
        return numberofitem;

    }


    //�A�C�e��ID�Ŏw�肵���A�C�e�����o�b�O�̒��ɐ������郁�\�b�h
    private void GetItem(int item_id)
    {
        //�e�A�C�e���̃��X�g���擾
        items = item_sobj.GetItemBaglist();

        foreach(Item item in items)
        {
            if(item.itemid==item_id)
            {

                //itemboard�p�l����e�ɐݒ肵�Đ���
                GameObject bag_item=GameObject.Instantiate(item.itemimage,itemboardpanel.transform);
                bag_item.GetComponentInChildren<Text>().text = item.item_quantity.ToString();

            }

        }

    }



}
