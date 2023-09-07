using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : MonoBehaviour
{
    [SerializeField] private GameObject hppotion;
    [SerializeField] private GameObject mppotion;
    [SerializeField] private GameObject savecrystal;



    //使用するアイテムのGameObject
    public GameObject inspectorname;

    //アイテムバッグ内で「使用」ボタンを押した時に対象アイテムの使用を切り替える処理
    public void SelectItem()
    {
        string itemname = inspectorname.GetComponent<Text>().text;

        Potion potion = new Potion();

        if (itemname!=null)
        {
           
            switch(itemname)
            {
                case "HPポーション":
                    potion.Usepotion(transform.root.gameObject,0);
                    hppotion.GetComponent<Itemlost>().ItemNumberUpdate();
                    break;

                case "MPポーション":
                    potion.Usepotion(transform.root.gameObject,1);
                    mppotion.GetComponent<Itemlost>().ItemNumberUpdate();
                    break;

                case "セーブクリスタル":
                    savecrystal.GetComponent<Savecrystal>().UseSavecrystal();
                    break;
            }

        }

    }


}
