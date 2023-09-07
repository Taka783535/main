using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera : MonoBehaviour
{
    [SerializeField] protected internal GameObject playercharactor; //キャラクター
    [SerializeField] protected internal GameObject camera_raycast_object;  //キャラクターへのレイを飛ばす始点となるオブジェクト

    [SerializeField] private float camera_rotate_speed;  //カメラの回転速度

    public float set_cameraspeed { get { return camera_rotate_speed; } set { camera_rotate_speed = value; } }


    /********************************************
     * 入力に応じてカメラの回転を行うメソッド
     * 引数：なし
     * 戻り値：なし
     * 概要：
     * プレイヤーの入力によりカメラを回転させる
     * ******************************************/
    private void RotateCamera()
    {
        //シフトキー+各種キーで決められた方向に回転する
        if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
        {
            //カメラの横回転
            if (Input.GetKey(KeyCode.R))
            {
                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.up, camera_rotate_speed);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                gameObject.transform.RotateAround(playercharactor.transform.position, Vector3.up, -camera_rotate_speed);
            }
            //カメラの縦回転
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
