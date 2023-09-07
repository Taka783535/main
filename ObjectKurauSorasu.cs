using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectKurauSorasu : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g�̃N���E�E�\���X���̂��̂ɕt��������N���X

    //�v���C���[�̃`���b�g��(���b�Z�[�W�\���p)
    [SerializeField] private Text chattxt;
    [SerializeField] private Canvas equip_canvas;     //����UI�̔z�u���ꂽ�L�����o�X
    [SerializeField] private GameObject equip_panel;  //�����A�C�R�����z�u�����p�l��

    [SerializeField] private WeaponList lists;    //����̈ꗗ���i�[���ꂽ�X�N���v�^�u���I�u�W�F�N�g
    [SerializeField] private int kurausorasu_id;  //�����N���E�E�\���X�̕���ID

    
    private void OnCollisionEnter(Collision other)
    {
        PickUP_KurauSorasu(other);

    }


    //�����N���E�\���X���E�����ꍇ�̏���
    private void PickUP_KurauSorasu(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            string specialweapon_gottext = "�����N���E�E�\���X����肵�܂����I";
            chattxt = other.transform.Find("Canvas").Find("chatpanel").Find("chattxt").GetComponent<Text>();

            chattxt.text = specialweapon_gottext;


            //�����i�[�p�l��(�����o�b�O���̂���)�擾
            GameObject equip_obj = other.gameObject.transform.Find("EquipCanvas").Find("itemboardpanel").gameObject;

            //�������X�g(�������Ǘ����Ă���X�N���v�^�u���I�u�W�F�N�g�C�����̃f�[�^�x�[�X)���琹���N���E�\���X�̃A�C�R�����擾���đ����o�b�O�ɃC���X�^���X��
            List<Weapon> weaponlists = lists.GetWeaponList();

            foreach (Weapon weapon in weaponlists)
            {
                if (weapon.weapon_id == kurausorasu_id)
                {
                    //�����o�b�O���ɑΏۂ̕���쐬
                    Instantiate(weapon.weapon_icon, equip_obj.transform);
                }

            }

            Destroy(gameObject);
        }
    }



}
