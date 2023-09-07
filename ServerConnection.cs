using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerConnection : MonoBehaviour
{
    //PhotonServer�ւ̐ڑ�����ѓ������s���N���X
    //���Ƃ͊e����̎��s�t�@�C����Photon�̃r���[���擾���Ď����̂��̂����肵�ē���������
    //���[����ޏo����Ɗ�{GameObject�͎����Ŕj�������炵���B

    [SerializeField] private byte maxroomplayer = 10; //1���[���̍ő�ڑ��l��(�W����10�l�܂�)

    //����Ƀv���C���[�L�����N�^�[�̃I�����C�������p
    public GameObject networkobject;  //�I�����C���v���C���ɓ������s���Q�[���I�u�W�F�N�g,Resources�t�H���_���̃I�u�W�F�N�g�ł���K�v������



    // Start is called before the first frame update
    void Start()
    {
        //�ڑ��J�n
        Connection();

        //�I�����C����ɃC���X�^���X����(���g�̃v���C���[�L�����N�^�[�Ȃ�)
        SynchoronizeObject();

    }



    /********************************************************************************************
     * �T�[�o�[�E���[���ڑ����\�b�h
     * �����F����
     * �߂�l�F����
     * �T�v�F
     * �}�X�^�[�T�[�o�[���̃����_���ȃ��[���ɎQ������B���[����������ΐV�K�쐬���ĎQ������B
     *********************************************************************************************/
    public void Connection()
    {
        //���[����Room1,Room2,Room3�E�E�E�Ɣԍ������č쐬����Ă���

        int roomnumber = PhotonNetwork.CountOfRooms+1;  //���[���ԍ�
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxroomplayer;  //�ő�ڑ��l��
        roomOptions.PlayerTtl = 0; //�Ō�̃v���C���[���ޏo������̃��[����������


        //�ڑ�����Ă��Ȃ���΃}�X�^�[�T�[�o�[�֐ڑ�
        if(PhotonNetwork.IsConnected==false)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        

        //�f�t�H���g�̃��r�[�֐ڑ�
        PhotonNetwork.JoinLobby();

        //���r�[�ڑ���Ԕ���
        if(PhotonNetwork.InLobby==false)
        {
            Debug.Log("���r�[�ւ̓����Ɏ��s���܂����B");
        }


        //���[�����Ȃ���ΐV�K�Ƀ��[�����쐬
        if(PhotonNetwork.CountOfRooms==0)
        {
            PhotonNetwork.CreateRoom($"Room{roomnumber}",roomOptions,null);
        }

        //�����_���ȃ��[���֐ڑ�,
        if(PhotonNetwork.JoinRandomRoom()==false)
        {
            Debug.Log("���[���ڑ��Ɏ��s���܂����B");
        }
        
    }


    //���[���ؒf�����C���r�[�܂��̓}�X�^�[�T�[�o�[�֖߂�
    public void DisRoomconnection()
    {
        PhotonNetwork.LeaveRoom();
    }

    //�}�X�^�[�T�[�o�[�ؒf����
    public void DisMasterconnection()
    {
        PhotonNetwork.Disconnect();
    }

    //�I�u�W�F�N�g��������,�I�����C����̌��_�ɓ����I�u�W�F�N�g�𐶐�����
    public void SynchoronizeObject()
    {
        if (networkobject == null)
        {
            Debug.LogError("��������I�u�W�F�N�g���ݒ肳��Ă��܂���B");
        }
        else
        {
            PhotonNetwork.Instantiate(networkobject.name, Vector3.zero, Quaternion.identity);
        }
    }

}
