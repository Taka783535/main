using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    //����𑕔�������q���[�}�m�C�h�p�[�c�B�ʏ�E��B
    public GameObject weaponequipparts;

    //������L�����N�^�[�ɑ���������B�������镐��������Ɏ��B
    public void EquipWeapon(GameObject weapon)
    {
        GameObject.Instantiate(weapon, weaponequipparts.transform);
    }
}
