using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����X�^�[�����i�[����X�N���v�^�u���I�u�W�F�N�g

[CreateAssetMenu]
public class Monstorlist : ScriptableObject
{
    //�����X�^�[���i�[�p�X�N���v�^�u���I�u�W�F�N�g�̍쐬
    public List<Monstorstatus> monstors = new List<Monstorstatus>();

    public List<Monstorstatus> GetMonstorstatuses()
    {
        return monstors;
    }

}
