using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Store_npc : BaseNPC
{
    //変数

    [SerializeField] private EventSystem eventsystem;   //イベントシステム
    [SerializeField] private Itemlist list;　　 //アイテムの一覧が格納されたスクリプタブルオブジェクト

    private GameObject player;  //プレイヤーのGameObject
    private GameObject talkbutton;
    [SerializeField] private string itemcanvas;   //アイテムバッグの各種UIが定義されたキャンバスの名前
    [SerializeField] private string itemboardpanel;　　//アイテムバッグ内にアイテムの画像が格納されているオブジェクトの名前
    [SerializeField] private string item_number_text;   //各アイテムアイコンに付いているアイテム個数を表示するオブジェクト

    //現在選択中のアイテムUI
    private GameObject select_obj;

    //アイテム売買用のUI(品物表示など)
    [SerializeField] private Canvas itemstorecanvas;   //店員NPCのみがもつアイテム売買用キャンバス
    [SerializeField] private GameObject itempanel;     //売買アイテムが描かれたパネル
    [SerializeField] private Text player_moneytext;    //売買アイテムが描かれたパネルに表示される所持金欄
    [SerializeField] private GameObject countpanel;    //アイテムの購入個数指定パネル
    [SerializeField] private Text iteminputfield; //アイテム購入個数を入力するInputFieldのText
    [SerializeField] private GameObject buy_checkpanel;    //購入確認画面 
    [SerializeField] private GameObject decided_buyitempanel; //購入確定画面
    [SerializeField] private GameObject errortext;     //アイテム個数を指定しない場合のエラーメッセージ


    //buy_chechpanel・decided_buyitempanelに付随したコンポーネント
    [SerializeField] private Text b_itemname;      //buy_chechpanelに表示するアイテム名
    [SerializeField] private Text b_item_number;   //buy_chechpanelに表示する購入アイテムの個数
    [SerializeField] private Image item_image;  //buy_chechpanelに購入されるアイテムの画像
    [SerializeField] private Text b_item_price;    //buy_checkpanelに表示される購入アイテムの値段
    [SerializeField] private Text d_itemname;    //decided_buyitempanelに表示するアイテム名
    [SerializeField] private Text d_item_number;　//decided_buyitempanelに表示する購入アイテムの個数
    


    //定数　マジックナンバー・マジックストリングを防ぐためのもの
    [SerializeField] private string actionbutton;   //NPCとの会話ボタン

    private int player_money;   //プレイヤーの現在の所持金
    private int price;   //アイテムの値段



    //メソッド

    private void Start()
    {
        //初期設定

        //NPCの名前を表示する
        ShowNpcName(npc_name);
    }



    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがNPCに触れたらNPCの初期化処理実行
        Store_npcInitialize(other.gameObject);

    }





    //Store_npcの初期化処理，引数はプレイヤーのGameObject
    private void Store_npcInitialize(GameObject other)
    {

        if (other.tag == "Player")
        {
            //プレイヤーを記録
            player = other.gameObject;

            //会話用キャンバスなどの初期設定を行う
            canvas = other.gameObject.transform.Find(Canvas_name).gameObject;
            npc_talkcanvas = other.gameObject.transform.Find(Npc_talkcanvas).gameObject;
            npc_comment_text = npc_talkcanvas.transform.Find(Npc_comment_panel).Find(Npc_commennt_text).gameObject;
            npc_talkcanvas.transform.Find(Next_button).gameObject.GetComponent<Button>().onClick.AddListener(ChoiceBuyItem);
            player_money = player.GetComponent<HPMP>().money;   //プレイヤーの現在の所持金を取得

            MoveUIManagement ui_management = itemstorecanvas.GetComponent<MoveUIManagement>();
            ui_management.set_canvas = canvas.GetComponent<Canvas>();
            ui_management.errortext = errortext;


            //プレイヤーが持つ会話開始ボタンを探し出す
            talkbutton = canvas.transform.Find(actionbutton).gameObject;
            talkbutton.GetComponent<Button>().onClick.AddListener(TalktoNPC);

        }

    }



    //通常のUIを消し，アイテム売買用のUIに切り換える処理
    public void ChoiceBuyItem()
    {
        npc_talkcanvas.SetActive(false);
        itemstorecanvas.gameObject.SetActive(true);
        itempanel.SetActive(true);
        player_moneytext.text = player_money.ToString();
    }


    //購入アイテムを押した時に出るアイテム購入個数指定処理
    public void CountBuyItem()
    {
        //アイテム購入画面を閉じる, アイテム購入個数設定画面を出す。
        select_obj = eventsystem.currentSelectedGameObject;
        itempanel.SetActive(false);
        countpanel.SetActive(true);

    }


    //アイテム購入個数設定画面のEnd Editイベント(アイテム購入個数を入力した時)で呼ばれる    
    public void CheckBuyItem()
    {

        //購入個数設定画面を閉じ，購入確認画面を出す。
        //入力文字が整数か確認
        if(int.TryParse(iteminputfield.text,out int count))
        {
            //購入個数設定画面を閉じ，購入確認画面を出す。
            countpanel.SetActive(false);
            buy_checkpanel.SetActive(true);

            //アイテムの名前,購入個数，画像を設定
            b_itemname.text = select_obj.name;
            b_item_number.text = count.ToString();
            item_image.sprite = select_obj.GetComponent<Image>().sprite;

            //アイテムの値段取得
            string string_price=select_obj.transform.Find("money").gameObject.GetComponent<Text>().text;
            int.TryParse(string_price, out price);
            price = price * count;

            //購入アイテムの値段を表示
            b_item_price.text = price.ToString();

            //値段が所持金オーバーの場合は強制終了
            if(price>player_money)
            {
                itemstorecanvas.GetComponent<MoveUIManagement>().CloseItemStoreMenu();
            }

        }
        else
        {
            //数字以外の入力がされた場合エラーメッセージ表示
            errortext.SetActive(true);

        }

    }



    //購入確認画面で「はい」のボタンを押した時の処理
    public void BuyItem()
    {
        //所持金減額処理
        player_money = player_money - price;
        player.GetComponent<HPMP>().money = player_money;

        //アイテムバッグの中を確認する
        GameObject itembag=player.transform.Find(itemcanvas).Find(itemboardpanel).gameObject;

        Transform item = itembag.transform.Find(select_obj.name);

        //アイテムバッグの中に購入アイテムと同種のアイテムが存在するか判定
        if (item!=null)
        {
            //存在する場合   個数+

            //アイテムの個数を表示するテキストボックス
            Text number_text = item.Find(item_number_text).gameObject.GetComponent<Text>();

            //アイテムの数更新
            //表示される個数テキスト更新
            int addnumber = int.Parse(number_text.text) + int.Parse(b_item_number.text);
            string number = addnumber.ToString();
            number_text.text = number;

            //アイテムの実際の個数更新
            item.gameObject.GetComponent<Itemlost>().ItemNumber = addnumber;

            //購入確認画面を閉じ，購入完了画面を出す。
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(true);
            d_itemname.text = b_itemname.text;
            d_item_number.text = b_item_number.text;

        }
        else
        {
            //存在しない場合 アイテムリストから検索して新規作成
            List<Item> itemlists = list.GetItemList();

            foreach(Item create_item in itemlists)
            {
                if(create_item.itemname==select_obj.name) 
                {

                    //アイテム新規作成，個数表示
                    GameObject obj=Instantiate(create_item.itemimage, itembag.transform);
                    obj.transform.Find(item_number_text).GetComponent<Text>().text = b_item_number.text;

                    obj.GetComponent<Itemlost>().ItemNumber = int.Parse(b_item_number.text);

                }
            }


            //購入確認画面を閉じ，購入完了画面を出す。
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(true);
            d_itemname.text = b_itemname.text;
            d_item_number.text = b_item_number.text;

        }


    }
    



}
