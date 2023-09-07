using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemlost : MonoBehaviour
{
    //�g���؂����A�C�e�����폜���鏈��



    //�A�C�e���̎c���
    private int num_item = 3;

    internal int ItemNumber { get { return num_item; } set { num_item = value; } }

    //UI�Ƃ��ĕ\������A�C�e���̎c���
    [SerializeField] private GameObject number_text;
    

    // Update is called once per frame
    void Update()
    {
        //�A�C�e�����g���؂�����A�C�e���\��������
        if(num_item==0)
        {
            Destroy(gameObject);
        }
    }

    //�A�C�e�����g�p���ꂽ���̍X�V����
    public void ItemNumberUpdate()
    {
        num_item -= 1;
        number_text.GetComponent<Text>().text = num_item.ToString();
    }

}
