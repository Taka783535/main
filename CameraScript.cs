using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player; //�v���C���[��GameObject

    [SerializeField] private float camera_rotatespeed;  //�J�����̉�]�X�s�[�h


    private void Update()
    {

        //�J�����̉�]
        if(Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.UpArrow)) //�c��](�O)
        {
            gameObject.transform.RotateAround(player.transform.localPosition, Vector3.right, camera_rotatespeed);
        }
        else if(Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.DownArrow)) //�c��](���)
        {
            gameObject.transform.RotateAround(player.transform.localPosition, Vector3.right, -camera_rotatespeed);
        }

    }

}
