using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : MonoBehaviour
{
    [SerializeField] private GameObject hppotion;
    [SerializeField] private GameObject mppotion;
    [SerializeField] private GameObject savecrystal;



    //�g�p����A�C�e����GameObject
    public GameObject inspectorname;

    //�A�C�e���o�b�O���Łu�g�p�v�{�^�������������ɑΏۃA�C�e���̎g�p��؂�ւ��鏈��
    public void SelectItem()
    {
        string itemname = inspectorname.GetComponent<Text>().text;

        Potion potion = new Potion();

        if (itemname!=null)
        {
           
            switch(itemname)
            {
                case "HP�|�[�V����":
                    potion.Usepotion(transform.root.gameObject,0);
                    hppotion.GetComponent<Itemlost>().ItemNumberUpdate();
                    break;

                case "MP�|�[�V����":
                    potion.Usepotion(transform.root.gameObject,1);
                    mppotion.GetComponent<Itemlost>().ItemNumberUpdate();
                    break;

                case "�Z�[�u�N���X�^��":
                    savecrystal.GetComponent<Savecrystal>().UseSavecrystal();
                    break;
            }

        }

    }


}
