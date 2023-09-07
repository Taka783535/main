using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemlost : MonoBehaviour
{
    //使い切ったアイテムを削除する処理



    //アイテムの残り個数
    private int num_item = 3;

    internal int ItemNumber { get { return num_item; } set { num_item = value; } }

    //UIとして表示するアイテムの残り個数
    [SerializeField] private GameObject number_text;
    

    // Update is called once per frame
    void Update()
    {
        //アイテムを使い切ったらアイテム表示を消す
        if(num_item==0)
        {
            Destroy(gameObject);
        }
    }

    //アイテムが使用された時の更新処理
    public void ItemNumberUpdate()
    {
        num_item -= 1;
        number_text.GetComponent<Text>().text = num_item.ToString();
    }

}
