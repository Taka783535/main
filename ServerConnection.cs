using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerConnection : MonoBehaviour
{
    //PhotonServerへの接続および同期を行うクラス
    //あとは各動作の実行ファイルでPhotonのビューを取得して自分のものか判定して動かす処理
    //ルームを退出すると基本GameObjectは自動で破棄されるらしい。

    [SerializeField] private byte maxroomplayer = 10; //1ルームの最大接続人数(標準で10人まで)

    //↓主にプレイヤーキャラクターのオンライン生成用
    public GameObject networkobject;  //オンラインプレイ時に同期を行うゲームオブジェクト,Resourcesフォルダ内のオブジェクトである必要がある



    // Start is called before the first frame update
    void Start()
    {
        //接続開始
        Connection();

        //オンライン上にインスタンス生成(自身のプレイヤーキャラクターなど)
        SynchoronizeObject();

    }



    /********************************************************************************************
     * サーバー・ルーム接続メソッド
     * 引数：無し
     * 戻り値：無し
     * 概要：
     * マスターサーバー内のランダムなルームに参加する。ルームが無ければ新規作成して参加する。
     *********************************************************************************************/
    public void Connection()
    {
        //ルームはRoom1,Room2,Room3・・・と番号をつけて作成されていく

        int roomnumber = PhotonNetwork.CountOfRooms+1;  //ルーム番号
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxroomplayer;  //最大接続人数
        roomOptions.PlayerTtl = 0; //最後のプレイヤーが退出した後のルーム持続時間


        //接続されていなければマスターサーバーへ接続
        if(PhotonNetwork.IsConnected==false)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        

        //デフォルトのロビーへ接続
        PhotonNetwork.JoinLobby();

        //ロビー接続状態判定
        if(PhotonNetwork.InLobby==false)
        {
            Debug.Log("ロビーへの入室に失敗しました。");
        }


        //ルームがなければ新規にルームを作成
        if(PhotonNetwork.CountOfRooms==0)
        {
            PhotonNetwork.CreateRoom($"Room{roomnumber}",roomOptions,null);
        }

        //ランダムなルームへ接続,
        if(PhotonNetwork.JoinRandomRoom()==false)
        {
            Debug.Log("ルーム接続に失敗しました。");
        }
        
    }


    //ルーム切断処理，ロビーまたはマスターサーバーへ戻る
    public void DisRoomconnection()
    {
        PhotonNetwork.LeaveRoom();
    }

    //マスターサーバー切断処理
    public void DisMasterconnection()
    {
        PhotonNetwork.Disconnect();
    }

    //オブジェクト同期処理,オンライン上の原点に同期オブジェクトを生成する
    public void SynchoronizeObject()
    {
        if (networkobject == null)
        {
            Debug.LogError("同期するオブジェクトが設定されていません。");
        }
        else
        {
            PhotonNetwork.Instantiate(networkobject.name, Vector3.zero, Quaternion.identity);
        }
    }

}
