using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIgenerate : MonoBehaviour
{

    //�A�C�e����UI���A�C�e���o�b�N���ɕ\������N���X
    GameObject itemobject;
    public GameObject itempanel;

    public ItemUIgenerate(GameObject uiprefab)
    {
        //uiprefab�ɂ͏o��������UI�̃v���n�u��ݒ�
        //�ݒ�ɂ�Resource�N���X��Load���\�b�h�Ńv���n�u�擾�CGameObject�ɕϊ����Ă��̃R���X�g���N�^�ɓ������ށB
        itemobject = uiprefab;
    }

    public void GenerateItemUI()
    {
        Transform parent = itempanel.transform;
        Instantiate(itemobject,parent,false);
    }

}
