using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************************
*�L�����N�^�[�ړ��p�̃N���X
*�A�j���[�^�[�R���g���[���[��unitychanlocomotion
*************************************************/

public class charactermove : MonoBehaviour
{
    //�O���[�o���ϐ�

    private Animator move;   //�v���C���[��Animator
    private Rigidbody rb;�@�@//�v���C���[��RigidBody

    //�K�v�ƂȂ�V�[���̖��O
    [SerializeField] private string player_start_scene;
    private const string game_clear_scene = "GameClear Scene";
    private const string game_over_scene = "GameOver Scene";

    [SerializeField] private GameObject searchbutton; //NPC�ɘb�������鎞�̃{�^��
    [SerializeField] private string appear_actionbutton_tag; //�I�u�W�F�N�g�̃^�O���B�ݒ肵���^�O�ɐG����actionbutton���o������B


    public GameObject backobject = null;  //�L�����N�^�[���U������Ƃ��̃I�u�W�F�N�g

    private static bool dontdestroy_flg = false;

    public static GameObject player;

    [SerializeField] private float player_walk_speed;    //�v���C���[�̕��s���x
    [SerializeField] private float player_rotate_speed;  //�v���C���[����]������ꍇ�̃v���C���[�̉�]���x
 
    //�v���p�e�B
    //�v���C���[�̕��s���x��ݒ肷��B
    public float set_walkspeed { get { return player_walk_speed; } set { player_walk_speed = value; } }
�@�@//�v���C���[�̉�]���x��ݒ肷��B
    public float set_rotatespeed { get { return player_rotate_speed; } set { player_rotate_speed = value; } }
    //actionbutton(���ׂ��U���{�^��)���o��������^�O��ݒ肷��B
    public string set_appear_actionbutton_tag { get { return appear_actionbutton_tag; } set { appear_actionbutton_tag = value; } }




    // ���\�b�h

    void Start()
    {
        //�����o�[�ϐ�������
        move = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward*3;

        if(dontdestroy_flg==false)
        {
            //�L�����N�^�[���j�󂳂�Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);
            player = gameObject;
            dontdestroy_flg =true;
        }

        SceneManager.sceneLoaded += Sceneloaded;
    }

    

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̓��͂ɉ����Ĉړ����s��
        movecontrol();
        
    }


    //�V�[�����؂�ւ�������Ă΂��K�v�ȏ����B�؂芷�����ɂ���s�v�I�u�W�F�N�g�̔j��Ȃ�
    void Sceneloaded(Scene next_scene,LoadSceneMode mode)
    {

        if (next_scene.name != "Title Scene")
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Animator>().SetFloat("Speed", 0f);
        }

        //DontdestroyOnload�̃R�s�[���͂���Ȃ��̂Ŕj�󂷂�
        if(next_scene.name== player_start_scene)
        {
            //�؂芷�����}�b�v����S�Ẵ��[�g�I�u�W�F�N�g���擾���C�v���C���[���폜
            GameObject[] village_object = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach(GameObject obj in village_object)
            {
                if(obj.name==gameObject.name)
                {
                    Destroy(obj);
                }
            }
        }
        else if(next_scene.name== game_clear_scene|| next_scene.name==game_over_scene)
        {
            //�Q�[���N���A���̓Q�[���I�[�o�[�V�[���ł̓v���C���[���̂��Ȃ��̂Ńv���C���[���̂��̂�j�󂷂�
            Destroy(gameObject);
            
        }
    }


    /*******************************************************
     * �L�����N�^�[�̈ړ����s�����\�b�h
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F���͂��ꂽ�L�[�ɂ���ăL�����N�^�[�̈ړ����s��
     *******************************************************/
    private void movecontrol()
    {

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))   //�O���ړ�
        {
            move.SetFloat("Speed", player_walk_speed);
            Rigidbody v = gameObject.GetComponent<Rigidbody>();
            v.velocity = transform.forward * 3;
            v.AddForce(transform.forward * 5);

        }
        if(Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.W))�@�@
        {
            float walk_stopspeed = 0f;
            move.SetFloat("Speed", walk_stopspeed);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)||Input.GetKeyUp(KeyCode.S))�@�@//����ړ�
        {
           
            gameObject.transform.LookAt(backobject.transform);
            
        }
        if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))�@�@//�E��]
        {
            transform.RotateAround(transform.position, transform.up, player_rotate_speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))    //����]
        {
            transform.RotateAround(transform.position, transform.up, -player_rotate_speed);
        }

    }


    //�ȉ�2��NPC�ɋߕt��������b�{�^�����o��������E�������鏈��
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== appear_actionbutton_tag)
        {
            searchbutton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == appear_actionbutton_tag)
        {
            searchbutton.SetActive(false);
        }
    }
}
