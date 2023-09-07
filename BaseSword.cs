using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����̐��\���̂��̂��`����N���X
/// </summary>

public class BaseSword : MonoBehaviour
{
    //�t�B�[���h
    [SerializeField]private string weaponname;  //����̖��O
    [SerializeField] private string inspector;   //����̐�����
    [SerializeField] protected GameObject inspectorname;   //������ʒ��ɂ��鑕���A�C�e���̖��O���\�������e�L�X�g�{�b�N�X
    [SerializeField] protected GameObject inspectortext;�@�@//������ʒ��ɂ��鑕���A�C�e���̏ڍׂ��\�������e�L�X�g�{�b�N�X
    [SerializeField] GameObject weapon;�@�@//�����3D�I�u�W�F�N�g
    [SerializeField] private int attack;  //����̍U����
    [SerializeField] protected GameObject equipparts;  //����𑕔�����p�[�c(�ʏ�͘r)
    [SerializeField] protected Button usebutton;  //����𑕔����錈��{�^��

    //�v���p�e�B
    public string Weaponname { get { return weaponname; } set { weaponname = value; } }
    public string Inspector { get { return inspector; } set { inspector = value; } }
    //����̍U����
    public int WeaponAttack { get { return attack; } set { if (value <= 999) { attack = value; } } }



    //���\�b�h

    //������ʂŊe�����A�C�e���̃A�C�R�������������ɌĂ΂�鏈��
    public void SelectWeapon()
    {
        inspectorname.GetComponent<Text>().text = weaponname;
        inspectortext.GetComponent<Text>().text = inspector;
        usebutton.onClick.AddListener(EquipWeapon);
    }


    //����𑕔����鎞�̏���
    public void EquipWeapon()
    {
        if (inspectorname.GetComponent<Text>().text == weaponname)
        {
            //������C���X�^���X���������ݒ���s��
            GameObject blade = Instantiate(weapon, Vector3.zero, Quaternion.identity, equipparts.transform);
            blade.transform.SetParent(equipparts.transform);
            blade.transform.localPosition = Vector3.zero;
            blade.transform.localRotation = Quaternion.identity;
            blade.AddComponent<BaseWeapon>().attack = attack;

            //�������Ă�������ƃC���X�^���X�����������t���ւ���
            blade.GetComponent<BaseWeapon>().player = equipparts.transform.root.gameObject;
            GameObject player_weapon = transform.root.gameObject.GetComponent<charactorBattle>().weapon;
            Destroy(player_weapon);
            transform.root.gameObject.GetComponent<charactorBattle>().weapon = blade;

        }
    }


}
