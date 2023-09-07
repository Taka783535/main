using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ŏ���1�C�̓����X�^�[���V�[���Ɏc��,��������Ɏc��𐶐�
public class Monstor : BaseMonstor
{
    
    Animator monstoranimation = new Animator();
    Collider sphereCollider = new SphereCollider();
    Rigidbody monstorrigidbody;
    int monstor=1;
    HPMP charactorstatus;
    float charactordistance;
    public GameObject mob;

    public GameObject hpfiller;

    private float timecounter;    //���ݕb���̕ێ��C���Ԍv���Ɏg�p�B
    private Vector3 directionvector = new Vector3();

    private bool attackflag = false; //�U�����������t���O�B�Ȃ��ƍU�����ł��ړ�������]�����N����
    private System.Random random=new System.Random();
    private GameObject[] clonemonstor=new GameObject[5];  //�������������X�^�[�̎Q��

    public Monstorlist monstorobject; //�����X�^�[�̃X�N���v�^�u���I�u�W�F�N�g(�X�e�[�^�X�����܂�)
    private List<Monstorstatus> monstorstatuses;�@//���o���������X�^�[�̃X�e�[�^�X
    

    protected override void Start()
    {
        base.Start();�@//�i�r���b�V�����ݒ肳���̂�
        monstoranimation=gameObject.GetComponent<Animator>();
        monstoranimation.SetBool("walk", true);

        //�����X�^�[��5�C�ȉ��Ȃ瑫��Ȃ��������W�F�l���[�g
        clonemonstor=MonstorGenerator(5);
        //for(int i=0;i<1;i++)
        //{
            //clonetransform[i] = clonemonstor[i].GetComponent<Transform>();
        //}

    }


    // Update is called once per frame
    new void Update()
    {
        //�����X�^�[���U�����łȂ��Ȃ珈�����s
        if (attackflag == false)
        {
            //deltaTime��1�t���[��0.0�E�E1�b�Ƃ��čl���Ă���B�N���C�A���g���̃v���O�����łȂ�����ʐM�����ȂǂŃt���[���Ԋu���󂢂ă����X�^�[�̓������x���Ȃ�B
            //�����X�^�[�̜p�j�v���O����
            timecounter += Time.deltaTime;   //���݂̎���(�b)


            //�J�n5�b�Ŏn�܂�C���܂葁���Ɖ����N����Ȃ��H
            if (timecounter >= 5.0f && timecounter <= 5.1f)
            {
                //�L�����̌������ς��
                MonstorDirectionChange();

            }
            else if (timecounter > 5.1f && timecounter < 9.0) //3�b����
            {
                Rigidbody mobrigid = gameObject.GetComponent<Rigidbody>();
                mobrigid.velocity = directionvector;
                mobrigid.AddForce(directionvector);
            }
            else if (timecounter >= 9.0f && timecounter <= 13.0f)  //4�b�~�܂�
            {
                monstoranimation.SetBool("walk", false);

                //�^�C���J�E���^0�N���A
                timecounter = 0.0f;
            }

        }
    }



    /**********************************************************************
     * �����X�^�[�̐����v���O����
     * �����F�������郂���X�^�[�̐�
     * �߂�l�F�������������X�^�[�̎Q�Ƃ��������z��
     * �T�v�F
     * �ϐ�Mob�ɓo�^���������X�^�[�������Ŏw�肵�����ɂȂ�܂�
     * �����X�^�[���t�B�[���h��ɐ�������B
     **********************************************************************/
    public GameObject[] MonstorGenerator(int monstornumber)
    {
        //�����X�^�[���w�肵�����ȉ��Ȃ瑫��Ȃ��������W�F�l���[�g
        monstor = GameObject.FindGameObjectsWithTag("Monstor").Length;  //���݃t�B�[���h�ɂ��郂���X�^�[�̐�
        int clonenumber = monstornumber - monstor;    //�����N���[����
        GameObject[] clone = new GameObject[clonenumber];  //�����N���[�������̔z��C�߂�l�C�ʊ֐��Ō̂��ƂɊ��蓖�Ă��s���ۂɎg�p�B
        
        if (monstor < monstornumber)
        {

            for (int i = monstor; i < monstornumber; i++)
            {
                //�o���ꏊ�̃����_�����W���擾
                Vector3 popout = new Vector3(random.Next(-30, 30), 0f, random.Next(-30, 30));
                clone[i-monstor]=Instantiate(mob, popout, Quaternion.identity);
            }
            
        }


        return clone;   //���������X�^�[�̎Q�Ƃ��������z��

    }
  

    //�����X�^�[�p�̃N���X,�����X�^�[�ɂ������Ďg���Ccollision�̓v���C���[�B
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            attackflag = true;
            monstorrigidbody = gameObject.GetComponent<Rigidbody>();
            //�ڐG���v���C���[�Ȃ烂���X�^�[���L�����̕���������C��������
            //gameobject=�A�^�b�`����Ă��郂���X�^�[
            gameObject.transform.LookAt(collision.transform);
            monstorrigidbody.AddForce(collision.transform.position); //�@�\�s�S�H
            monstoranimation.SetBool("walk", true); //
            //�Q�[���I�u�W�F�N�g�Ԃ̋���
            charactordistance = Vector3.Distance(gameObject.transform.position, collision.transform.position);
            if (charactordistance==1f)
            {
                charactorstatus = collision.gameObject.GetComponent<HPMP>();
                monstoranimation.SetBool("walk", false);
                //1��͏������s�����[�v�Ȃ������H
                /*while(charactorstatus.hp!=0&charactordistance==1)
                {
                    monstoranimation.SetBool("attack01", true);
                    charactorstatus.hp = -10;
                }*/
            }
            
        }

    }

    //�R���C�_�[���G��Ă�ԃ_���[�W�H
    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag=="Player")
        {
            
            monstoranimation.SetBool("walk", false);
            charactorstatus =collision.gameObject.GetComponent<HPMP>();
            if(charactorstatus.hp!=0)
            {
                monstoranimation.SetBool("attack01", true);
                //Vector3 xscalepoint = hpfiller.transform.localScale;
                //xscalepoint.x = (float)1.8 / 1000 * 500;
                //charactorstatus.ReciveDamage(100, 1.8 / 1000);
            }
            
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            monstoranimation.SetBool("attack01", false);
        }

        attackflag = false;
    }

    public void Damage()
    {
        //charactorstatus.ReciveDamage(100, 1.8 / 1000);
    }


  

    //�����X�^�[�̌����������_���ɕς���B
    private void  MonstorDirectionChange()
    {
        
        
        Vector3 vector = new Vector3();
        int[] charactordirection = new int[5];  //�����X�^�[�̂��Ƃ̕����������������L�^
        

        //�����X�^�[�̂��Ƃ̕���
        for(int i=0; i<5; i++)
        {
            charactordirection[i] = random.Next(0, 4);
        }
        
        //���݁Cclonemonstor[0�`3]�܂ŎQ�Ƃ���C����ɕ����������蓖�ĂĎQ��

        //int point = random.Next(0, 4);  //��������������
        Vector3 currentpoint = gameObject.transform.position;  //�����X�^�[�̌��ݍ��W

        for (int j = 0; j < 3; j++)    //����mob����5��Ȃ̂Ŏb��Ń��[�v5��,���ƂŃO���[�o���ϐ��ɕύX��
        {
            //�����_���ȕ���������
            switch (charactordirection[j])
            {
                case 0:
                    vector = currentpoint + Vector3.forward;
                    directionvector = Vector3.forward;
                    break;

                case 1:
                    vector = currentpoint + Vector3.right;
                    directionvector = Vector3.right;
                    break;

                case 2:
                    vector = currentpoint + Vector3.left;
                    directionvector = Vector3.left;
                    break;

                case 3:
                    vector = currentpoint + Vector3.back;
                    directionvector = Vector3.back;
                    break;

                default:
                    break;

            }


            //�ŏ���1���[�v�����͔z��̒��g�����邪�C����Ȍ�̃��[�v�Œ��g�Ȃ��C�z�񂪐錾���ɖ߂��Ă��܂�
            //clonemonstor[j].transform.LookAt(vector);
            //clonetransform[j].transform.LookAt(vector);
            gameObject.transform.LookAt(vector);
        }
            monstoranimation.SetBool("walk", true);
        
        
            //Rigidbody mobrig = mob.GetComponent<Rigidbody>();
            //mobrig.velocity =directionvector*10;
            //mobrig.AddForce(directionvector);

    }

    //���g�p���\�b�h�@����Ȃ��Ȃ����
    private void Monstor_attack(int monstorid)
    {
        //�����X�^�[�̃��X�g���X�N���v�^�u���I�u�W�F�N�g������o���B
        monstorstatuses = monstorobject.GetMonstorstatuses();

        //int monstorhp; //���݂̃����X�^�[��HP

        foreach(Monstorstatus mobstatus in monstorstatuses)
        {
            
        }
    }



    /*private void OnTriggerStay(Collider other)
    {
        //�g���K�[�Ńv���C���[�����m������
        if(other.tag=="Player")
        {
            CurrentMonstorStatus mobstatus = gameObject.GetComponent<CurrentMonstorStatus>();

            //�L�����̌��݂g�o�Ǘ��͂g�o�l�o�N���X���b��ł��Ă���
            HPMP charactor_status = other.GetComponent<HPMP>(); //�L�����N�^�[�̃X�e�[�^�X
            float distance = Vector3.Distance(gameObject.transform.position, other.transform.position);�@//�L�����N�^�[�ƃ����X�^�[�Ƃ̋���

            //�L�����N�^�[�������̓����X�^�[��HP��0�łȂ��C���L�����N�^�[�ƃ����X�^�[�Ƃ̋�����1.5���ȓ��̎�
            if (mobstatus.hp!=0||charactor_status.hp!=0&&distance<=1.5)
            {
                //�����X�^�[���L�����N�^�[���U������

                monstoranimation.SetBool("walk", false);
                monstoranimation.SetBool("attack01", true);

                //�L�����N�^�[��HP���烂���X�^�[�̍U���͕��̃_���[�W���������
                //charactor_status.hp -= mobstatus.attack;

            }
            //�L�����N�^�[�ƃ����X�^�[��HP��0�łȂ��C�����҂̋�����10���ȓ��܂łȂ�
            else if(mobstatus.hp!=0||charactor_status.hp!=0&&10>=distance)
            {
                 //�����X�^�[���L�����N�^�[��ǂ�������
                 base.ChaseTarget();
               
            }
            else
            {
                //�퓬�I��

            }

        }

    }*/
   


    
}
