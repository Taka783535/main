using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera : MonoBehaviour
{
    [SerializeField] protected internal GameObject playercharactor; //�L�����N�^�[
    [SerializeField] protected internal GameObject camera_raycast_object;  //�L�����N�^�[�ւ̃��C���΂��n�_�ƂȂ�I�u�W�F�N�g

    [SerializeField] private float camera_rotate_speed;  //�J�����̉�]���x

    public float set_cameraspeed { get { return camera_rotate_speed; } set { camera_rotate_speed = value; } }


    /********************************************
     * ���͂ɉ����ăJ�����̉�]���s�����\�b�h
     * �����F�Ȃ�
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �v���C���[�̓��͂ɂ��J��������]������
     * ******************************************/
    private void RotateCamera()
    {
        //�V�t�g�L�[+�e��L�[�Ō��߂�ꂽ�����ɉ�]����
        if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
        {
            //�J�����̉���]
            if (Input.GetKey(KeyCode.R))
            {
                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.up, camera_rotate_speed);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.up, -camera_rotate_speed);
            }
            //�J�����̏c��]
            else if (Input.GetKey(KeyCode.U))
            {

                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.right, camera_rotate_speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {

                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.right, -camera_rotate_speed);

            }

        }


    }

}
