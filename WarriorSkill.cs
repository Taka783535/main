using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSkill : MonoBehaviour
{
    Animator warrioranimator;
    
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃A�j���[�V�����擾
        warrioranimator = gameObject.GetComponentInParent<Animator>();
        
    }

    



    //�����X�L���F�X���b�V��
    private void Slash()
    {
        warrioranimator.SetBool("attack01", true);
        //�G�t�F�N�g����
        ParticleSystem effect = gameObject.GetComponent<ParticleSystem>();
        effect.Play();
        //���炷
    }

}
