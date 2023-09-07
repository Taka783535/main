using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Store_npc : BaseNPC
{
    //�ϐ�

    [SerializeField] private EventSystem eventsystem;   //�C�x���g�V�X�e��
    [SerializeField] private Itemlist list;�@�@ //�A�C�e���̈ꗗ���i�[���ꂽ�X�N���v�^�u���I�u�W�F�N�g

    private GameObject player;  //�v���C���[��GameObject
    private GameObject talkbutton;
    [SerializeField] private string itemcanvas;   //�A�C�e���o�b�O�̊e��UI����`���ꂽ�L�����o�X�̖��O
    [SerializeField] private string itemboardpanel;�@�@//�A�C�e���o�b�O���ɃA�C�e���̉摜���i�[����Ă���I�u�W�F�N�g�̖��O
    [SerializeField] private string item_number_text;   //�e�A�C�e���A�C�R���ɕt���Ă���A�C�e������\������I�u�W�F�N�g

    //���ݑI�𒆂̃A�C�e��UI
    private GameObject select_obj;

    //�A�C�e�������p��UI(�i���\���Ȃ�)
    [SerializeField] private Canvas itemstorecanvas;   //�X��NPC�݂̂����A�C�e�������p�L�����o�X
    [SerializeField] private GameObject itempanel;     //�����A�C�e�����`���ꂽ�p�l��
    [SerializeField] private Text player_moneytext;    //�����A�C�e�����`���ꂽ�p�l���ɕ\������鏊������
    [SerializeField] private GameObject countpanel;    //�A�C�e���̍w�����w��p�l��
    [SerializeField] private Text iteminputfield; //�A�C�e���w��������͂���InputField��Text
    [SerializeField] private GameObject buy_checkpanel;    //�w���m�F��� 
    [SerializeField] private GameObject decided_buyitempanel; //�w���m����
    [SerializeField] private GameObject errortext;     //�A�C�e�������w�肵�Ȃ��ꍇ�̃G���[���b�Z�[�W


    //buy_chechpanel�Edecided_buyitempanel�ɕt�������R���|�[�l���g
    [SerializeField] private Text b_itemname;      //buy_chechpanel�ɕ\������A�C�e����
    [SerializeField] private Text b_item_number;   //buy_chechpanel�ɕ\������w���A�C�e���̌�
    [SerializeField] private Image item_image;  //buy_chechpanel�ɍw�������A�C�e���̉摜
    [SerializeField] private Text b_item_price;    //buy_checkpanel�ɕ\�������w���A�C�e���̒l�i
    [SerializeField] private Text d_itemname;    //decided_buyitempanel�ɕ\������A�C�e����
    [SerializeField] private Text d_item_number;�@//decided_buyitempanel�ɕ\������w���A�C�e���̌�
    


    //�萔�@�}�W�b�N�i���o�[�E�}�W�b�N�X�g�����O��h�����߂̂���
    [SerializeField] private string actionbutton;   //NPC�Ƃ̉�b�{�^��

    private int player_money;   //�v���C���[�̌��݂̏�����
    private int price;   //�A�C�e���̒l�i



    //���\�b�h

    private void Start()
    {
        //�����ݒ�

        //NPC�̖��O��\������
        ShowNpcName(npc_name);
    }



    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[��NPC�ɐG�ꂽ��NPC�̏������������s
        Store_npcInitialize(other.gameObject);

    }





    //Store_npc�̏����������C�����̓v���C���[��GameObject
    private void Store_npcInitialize(GameObject other)
    {

        if (other.tag == "Player")
        {
            //�v���C���[���L�^
            player = other.gameObject;

            //��b�p�L�����o�X�Ȃǂ̏����ݒ���s��
            canvas = other.gameObject.transform.Find(Canvas_name).gameObject;
            npc_talkcanvas = other.gameObject.transform.Find(Npc_talkcanvas).gameObject;
            npc_comment_text = npc_talkcanvas.transform.Find(Npc_comment_panel).Find(Npc_commennt_text).gameObject;
            npc_talkcanvas.transform.Find(Next_button).gameObject.GetComponent<Button>().onClick.AddListener(ChoiceBuyItem);
            player_money = player.GetComponent<HPMP>().money;   //�v���C���[�̌��݂̏��������擾

            MoveUIManagement ui_management = itemstorecanvas.GetComponent<MoveUIManagement>();
            ui_management.set_canvas = canvas.GetComponent<Canvas>();
            ui_management.errortext = errortext;


            //�v���C���[������b�J�n�{�^����T���o��
            talkbutton = canvas.transform.Find(actionbutton).gameObject;
            talkbutton.GetComponent<Button>().onClick.AddListener(TalktoNPC);

        }

    }



    //�ʏ��UI�������C�A�C�e�������p��UI�ɐ؂芷���鏈��
    public void ChoiceBuyItem()
    {
        npc_talkcanvas.SetActive(false);
        itemstorecanvas.gameObject.SetActive(true);
        itempanel.SetActive(true);
        player_moneytext.text = player_money.ToString();
    }


    //�w���A�C�e�������������ɏo��A�C�e���w�����w�菈��
    public void CountBuyItem()
    {
        //�A�C�e���w����ʂ����, �A�C�e���w�����ݒ��ʂ��o���B
        select_obj = eventsystem.currentSelectedGameObject;
        itempanel.SetActive(false);
        countpanel.SetActive(true);

    }


    //�A�C�e���w�����ݒ��ʂ�End Edit�C�x���g(�A�C�e���w��������͂�����)�ŌĂ΂��    
    public void CheckBuyItem()
    {

        //�w�����ݒ��ʂ���C�w���m�F��ʂ��o���B
        //���͕������������m�F
        if(int.TryParse(iteminputfield.text,out int count))
        {
            //�w�����ݒ��ʂ���C�w���m�F��ʂ��o���B
            countpanel.SetActive(false);
            buy_checkpanel.SetActive(true);

            //�A�C�e���̖��O,�w�����C�摜��ݒ�
            b_itemname.text = select_obj.name;
            b_item_number.text = count.ToString();
            item_image.sprite = select_obj.GetComponent<Image>().sprite;

            //�A�C�e���̒l�i�擾
            string string_price=select_obj.transform.Find("money").gameObject.GetComponent<Text>().text;
            int.TryParse(string_price, out price);
            price = price * count;

            //�w���A�C�e���̒l�i��\��
            b_item_price.text = price.ToString();

            //�l�i���������I�[�o�[�̏ꍇ�͋����I��
            if(price>player_money)
            {
                itemstorecanvas.GetComponent<MoveUIManagement>().CloseItemStoreMenu();
            }

        }
        else
        {
            //�����ȊO�̓��͂����ꂽ�ꍇ�G���[���b�Z�[�W�\��
            errortext.SetActive(true);

        }

    }



    //�w���m�F��ʂŁu�͂��v�̃{�^�������������̏���
    public void BuyItem()
    {
        //���������z����
        player_money = player_money - price;
        player.GetComponent<HPMP>().money = player_money;

        //�A�C�e���o�b�O�̒����m�F����
        GameObject itembag=player.transform.Find(itemcanvas).Find(itemboardpanel).gameObject;

        Transform item = itembag.transform.Find(select_obj.name);

        //�A�C�e���o�b�O�̒��ɍw���A�C�e���Ɠ���̃A�C�e�������݂��邩����
        if (item!=null)
        {
            //���݂���ꍇ   ��+

            //�A�C�e���̌���\������e�L�X�g�{�b�N�X
            Text number_text = item.Find(item_number_text).gameObject.GetComponent<Text>();

            //�A�C�e���̐��X�V
            //�\���������e�L�X�g�X�V
            int addnumber = int.Parse(number_text.text) + int.Parse(b_item_number.text);
            string number = addnumber.ToString();
            number_text.text = number;

            //�A�C�e���̎��ۂ̌��X�V
            item.gameObject.GetComponent<Itemlost>().ItemNumber = addnumber;

            //�w���m�F��ʂ���C�w��������ʂ��o���B
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(true);
            d_itemname.text = b_itemname.text;
            d_item_number.text = b_item_number.text;

        }
        else
        {
            //���݂��Ȃ��ꍇ �A�C�e�����X�g���猟�����ĐV�K�쐬
            List<Item> itemlists = list.GetItemList();

            foreach(Item create_item in itemlists)
            {
                if(create_item.itemname==select_obj.name) 
                {

                    //�A�C�e���V�K�쐬�C���\��
                    GameObject obj=Instantiate(create_item.itemimage, itembag.transform);
                    obj.transform.Find(item_number_text).GetComponent<Text>().text = b_item_number.text;

                    obj.GetComponent<Itemlost>().ItemNumber = int.Parse(b_item_number.text);

                }
            }


            //�w���m�F��ʂ���C�w��������ʂ��o���B
            buy_checkpanel.SetActive(false);
            decided_buyitempanel.SetActive(true);
            d_itemname.text = b_itemname.text;
            d_item_number.text = b_item_number.text;

        }


    }
    



}
