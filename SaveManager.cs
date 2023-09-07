using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //�V�[�����؂�ւ�鎞RunSave���\�b�h���s
        //�����ɑO�̃V�[���Ǝ��̃V�[�����邪�ڍs�Ɠ����ɑO�̃V�[����Savedata���j������ČĂ΂ꂽ���ɂ͎Q�Ƃł�����̂������H
        SceneManager.activeSceneChanged += Scenechange;
    }

    private void Scenechange(Scene currentscene,Scene newscene)
    {
        //RunSave();
    }

    //�f�[�^�Z�[�u�����s���郁�\�b�h
    public void RunSave()
    {
        
        //���݂̃V�[�����ƃv���C���[�̍��W���擾
        SaveData data =gameObject.GetComponent<SaveData>();
        data.scenename = SceneManager.GetActiveScene().name;
        data.currentpoint = gameObject.transform.position;

        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

        //BinaryFormatter�͋��^���ł���C�Z�L�����e�B��̖�肩��֎~
        using (FileStream file = File.Create(Application.persistentDataPath))
        {
            //�f�[�^��������
            serializer.Serialize(file, data);
        }

    }

    //�Z�[�u�f�[�^�����[�h���郁�\�b�h
    public void DataLoad()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        using(FileStream file = File.OpenRead(Application.persistentDataPath)) 
        {
            //�f�[�^�ǂݍ���
            SaveData data=(SaveData)serializer.Deserialize(file);
            //�O�̃f�[�^�Ɏ�ɓ��ꂽ�f�[�^���㏑���C�L�����N�^�[�z�u
            SaveData fowardsave=gameObject.GetComponent<SaveData>();
            fowardsave.hp = data.hp;
            fowardsave.mp = data.mp;
            fowardsave.str = data.str;
            fowardsave.magic = data.magic;
            fowardsave.agi = data.agi;
            fowardsave.dex = data.dex;
            fowardsave.vit = data.vit;
            fowardsave.money = data.money;
            SceneManager.LoadScene(data.scenename);
            gameObject.transform.position = data.currentpoint;
        }
    }
}
