using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************
 * �S�Ă̕����ۑ�����X�N���v�^�u���I�u�W�F�N�g
 * �p�����[�^�[��`�N���X�ł���Weapon�N���X�ƕ����Ďg�p����B
 *********************************************************/

[CreateAssetMenu]
public class WeaponList : ScriptableObject
{
    //����i�[�p�X�N���v�^�u���I�u�W�F�N�g(�ʏ́F���탊�X�g)�̍쐬
    public List<Weapon> weapons = new List<Weapon>();

    //���탊�X�g��Ԃ�
    public List<Weapon> GetWeaponList()
    {
        return weapons;
    }

}
