using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion
{

    //�񕜃|�[�V�����̎d�l����`���ꂽ�N���X


    private int max_hp = 1000;    //�ő�HP
    private int max_mp = 500;     //�ő�MP

    private int heal_point = 100;�@�@//�|�[�V�����̉񕜗�

    private const int hp_potion = 0;
    private const int mp_potion = 1;

    public int Set_maxhp { get { return max_hp; } set { max_hp = value; } }  //�ő�HP�̐ݒ�
    public int Set_maxmp { get { return max_mp; } set { max_mp = value; } }�@//�ő�MP�̐ݒ�



    //�|�[�V����(�񕜃A�C�e��)�̎g�p���A�C�e��ID�Ő؂芷���鏈��
    public void Usepotion(GameObject player,int item_id)
    {
        
        switch(item_id)
        {
            case hp_potion:   //HP�|�[�V�������g�p�������̏���

                UseHPpotion(player);
                break;

            case mp_potion:  //MP�|�[�V�������g�p�������̏���

                UseMPpotion(player);
                break;
        }
       
    }


    /// <summary>
    /// HP�|�[�V�������g�p�������̏���
    /// �����F�v���C���[��GameObject
    /// �߂�l�F�Ȃ�
    /// �T�v�F�ő��100��HP���񕜂���B
    /// </summary>
    public void UseHPpotion(GameObject player)
    {
        HPMP characterhp = player.GetComponent<HPMP>();

        if (characterhp.hp != 0)
        {
            //�ő�HP�͈͓̔��ɂ�����
            if (characterhp.hp <= max_hp)
            {
                //�ő�HP�ƌ��݂�HP�̒l�̍�
                int incrementhp = max_hp - characterhp.hp;

                //�����|�[�V�����̉񕜗ʈȓ��̎��͍����������₷
                if (incrementhp <= heal_point)
                {
                    characterhp.hp += incrementhp;
                    characterhp.Heal(characterhp.DefaultHP());
                }
                else
                {
                    //�����|�[�V�����̉񕜗ʈȏ�̎��̓|�[�V�����񕜕��𑝂₷
                    characterhp.hp += heal_point;
                    characterhp.Heal(characterhp.DefaultHP());
                }
            }

        }
        
    }


    /// <summary>
    /// MP�̃|�[�V�������g�p�������̏���
    /// �����F�v���C���[��GameObject
    /// �߂�l�F�Ȃ�
    /// �T�v�F�ő��100��Mp���񕜂���B
    /// </summary>
    public void UseMPpotion(GameObject player)
    {
        HPMP charactermp = player.GetComponent<HPMP>();
        if (charactermp.hp != 0)
        {
            //�ő�MP�͈͓̔��ɂ�����
            if (charactermp.mp <= max_mp)
            {
                //�ő�MP�ƌ��݂�MP�̒l�̍�
                int incrementmp = max_mp - charactermp.mp;

                //�����|�[�V�����̉񕜗ʈȓ��̎��͍����������₷
                if (incrementmp <= heal_point)
                {
                    charactermp.mp += incrementmp;
                }
                else
                {
                    //�����|�[�V�����̉񕜗ʈȏ�̎��̓|�[�V�����̉񕜕����₷
                    charactermp.mp += heal_point;
                }
            }

        }

    }



}
