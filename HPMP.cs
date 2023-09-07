using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPMP : MonoBehaviour,BattleInterface
{
    
    
    //HP�EMP�E�\�͒l
    public int hp = 1000;
    public int mp = 500;
    public int str = 0;
    public int magic = 0;
    public int vit = 0;
    public int agi = 0;
    public int dex = 0;
    public int money = 1000;

    private double defaulthpscale;  //����HP�ł̂g�o�X�P�[��
    public GameObject hpbar;

    [SerializeField] private string parameter_battlestandby;  //�U���������[�V�����̃t���O(bool�l)
    [SerializeField] private string parameter_attack;�@//�U�����[�V�����̃t���O(bool�l)
    [SerializeField] private string parameter_gameover;  //�Q�[���I�[�o�[���[�V�����̃t���O(bool�l)

    [SerializeField] private string gameover_scene;  //�Q�[���I�[�o�[�������ɑJ�ڂ���V�[����


    
    void Start()
    {
        defaulthpscale = DefaultHP();
    }


    private void Update()
    {
        //�v���C���[��HP��0�ɂȂ������̏���
        if (this.hp <= 0)
        {
            Animator player_animator = gameObject.GetComponent<Animator>();
            player_animator.SetBool(parameter_attack, false);
            player_animator.SetBool(parameter_battlestandby, false);
            player_animator.SetBool(parameter_gameover, true);
        }
    }


    //�K���HP�ݒ胁�\�b�h,HP�̏����l��1000,HP�o�[�ɂ�����HP1���̃X�P�[���l(x)��Ԃ�
    public double DefaultHP()
    {
        //HP�������l��1000�Ƃ��Čv�Z
        return 1.8 / 1000;
    }



    //�_���[�W�󂯂����̏���
    void BattleInterface.IReceiveDamage(int damage)
    {
        hp -= damage;
        Vector3 hitpoint = new Vector3((float)defaulthpscale*hp, 1f, 1f);

        //HP0�̎�HP�o�[���U��؂�Ȃ��悤�ݒ�
        if (hpbar.transform.localScale != new Vector3(0, 1, 1))
        {
            hpbar.transform.localScale = hitpoint;
        }
    }


    //HP�񕜏���
    public void Heal(double hpscaleX)
    {
        Vector3 hitpoint = new Vector3((float)hpscaleX * hp, 1f, 1f);

        //�ő�HP�̎�HP�o�[���U��؂�Ȃ��悤�ݒ�
        if (hpbar.transform.localScale != new Vector3((float)1.8, 1, 1))
        {
            hpbar.transform.localScale = hitpoint;
        }
    }


    //�v���C���[��HP��0�ɂȂ������̃��\�b�h,�v���C���[�̓|����郂�[�V�����ɕt����
    public void PlayerDown(GameObject player)
    {
        if(player.GetComponent<HPMP>().hp<=0)
        {
            SceneManager.LoadScene(gameover_scene);
        }

    }
    
    

}
