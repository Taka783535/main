using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player; //プレイヤーのGameObject

    [SerializeField] private float camera_rotatespeed;  //カメラの回転スピード


    private void Update()
    {

        //カメラの回転
        if(Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.UpArrow)) //縦回転(前)
        {
            gameObject.transform.RotateAround(player.transform.localPosition, Vector3.right, camera_rotatespeed);
        }
        else if(Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.DownArrow)) //縦回転(後ろ)
        {
            gameObject.transform.RotateAround(player.transform.localPosition, Vector3.right, -camera_rotatespeed);
        }

    }

}
