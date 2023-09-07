using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;


public class SaveandLoadManager : MonoBehaviour
{
    /*********************************************************************************
     * �Z�[�u�f�[�^�̃Z�[�u�E���[�h�@�\��񋟂���N���X
     * 
     * �����̕⑫���
     * �Z�[�u�f�[�^��JSON�`���ŕۑ����Í������ꂽ�t�@�C���ɕۑ�����Ă���
     * �f�[�^�Z�[�u���FSaveData�N���X�^�̃f�[�^����xJSON�ɕϊ����Ă���t�@�C���֕ۑ�
     * �f�[�^���[�h���F�t�@�C��������o����JSON �f�[�^�������SaveData�N���X�֕ϊ�
     *********************************************************************************/


    /*************************************************************
     * �f�[�^�Z�[�u���s�����\�b�h
     * �����F�ۑ����邽�߂̃Z�[�u�f�[�^(SaveData�^�̃C���X�^���X)
     * �߂�l�F�Ȃ�
     * �T�v�F
     * �Z�[�u�f�[�^�t�@�C���ɃZ�[�u�f�[�^��JSON�`���ŕۑ��B
     **************************************************************/
    public static void DataSave(SaveData data)
    {
        //�V���A���C�Y�����ăt�@�C���ɕۑ�����B
        string jsondata=JsonUtility.ToJson(data);  //�Z�[�u�f�[�^��JSON�ɕϊ�
        string filepath = Application.persistentDataPath + "/savedata"+".json"; //�Z�[�u�f�[�^�̃p�X
        string copypath = Application.persistentDataPath + "/savedatacopy" + ".json";
        StreamWriter streamWriter = new StreamWriter(filepath); //�Z�[�u�f�[�^�������ݗp
        StreamWriter streamWriter1 = new StreamWriter(copypath); //�X�V�Z�[�u�f�[�^�������ݗp


        if (File.Exists(Application.persistentDataPath)==false) 
        {
            //�Z�[�u�f�[�^�t�@�C���������������̏���
            //�t�H���_�[�ɃZ�[�u�t�@�C�����Ȃ���ΐV�K�쐬
            try
            {
                //�������ݏ���
                streamWriter.Write(jsondata);
                
                
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                //�t�@�C�������
                streamWriter.Close();
                File.Encrypt(filepath);   //�t�@�C���̈Í���
            }
        }
        else
        {
            //�Z�[�u�f�[�^�t�@�C�������݂��鎞�̏���
            //�Z�[�u�f�[�^�t�@�C�������݂���Ȃ�ΐV�����t�@�C�����쐬���ē��e���������݃t�@�C���u�����s���B
            try
            {
                streamWriter1.Write(jsondata);  //�V�K�t�@�C���쐬�C�X�V�Z�[�u�f�[�^��������
                File.Decrypt(filepath);   //�㏑������t�@�C���̈Í�������
                File.Copy(copypath, filepath, true);  //�t�@�C���㏑��
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                streamWriter1.Close();
                File.Encrypt(filepath);�@//�t�@�C���Í���
                File.Delete(copypath);   //�㏑���p�Ŏg�����t�@�C���͕s�v�Ȃ̂ō폜
            }

            

        }

        streamWriter.Close();
        streamWriter1.Close();
        
    }



    /**************************************************************
     * �Z�[�u�f�[�^�����[�h���郁�\�b�h
     * �����F�Ȃ�
     * �߂�l�F���[�h�����Z�[�u�f�[�^
     * �T�v�F
     * �Z�[�u�t�@�C���ɕۑ�����Ă���Z�[�u�f�[�^��ǂݍ���ŕԂ��B
     * ���s�����null���Ԃ��Ă���B
     **************************************************************/
    public static SaveData DataLoad()
    {
        SaveData loaddata=null; //���[�h�����Z�[�u�f�[�^
        string data=null;  //JSON�Z�[�u�f�[�^�̈ꎞ�ۊǗp�o�b�t�@
        string filepath = Application.persistentDataPath + "/savedata.json"; //�t�@�C���p�X
        StreamReader streamReader = new StreamReader(filepath);

        //JSON�ŕۑ����Ă���Z�[�u�f�[�^��ǂ݂���ŕԂ�
        try
        {
            File.Decrypt(filepath);   //�Z�[�u�t�@�C���̕�����
            data = streamReader.ReadToEnd();  //�Z�[�u�f�[�^���J���ēǂݍ���
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            streamReader.Close();�@�@//�Z�[�u�t�@�C�������
            File.Encrypt(filepath);  //�Z�[�u�t�@�C���̈Í���
        }

        //�ǂݍ��񂾃f�[�^��JSON����SaveData�N���X�^�֖߂�
        if (data == null)
        {
            //data�o�b�t�@��null�̂܂܂Ȃ�Z�[�u�f�[�^�̓ǂݍ��ݎ��s
            Debug.Log("�Z�[�u�f�[�^�̃��[�h�Ɏ��s���܂����B");
        }
        else
        {
            loaddata = JsonUtility.FromJson<SaveData>(data);
        }

        return loaddata;
    }



    /******************************************
     * �����Z�[�u�f�[�^�쐬���\�b�h
     * �����F�v���C���[��
     * �߂�l�F���������ꂽ�Z�[�u�f�[�^
     * �T�v�F�v���C���[���ȊO�̃X�e�[�^�X������������
     ******************************************/
    public static SaveData CreateSaveData(string playername)
    {
        //�v���C���[���ȊO�����l�ŐV�K�̃Z�[�u�f�[�^���쐬����
        SaveData savedata = new SaveData();
        savedata.playername = playername;
        return savedata;
    }


    

}
