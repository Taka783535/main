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
        //シーンが切り替わる時RunSaveメソッド実行
        //引数に前のシーンと次のシーンあるが移行と同時に前のシーンのSavedataが破棄されて呼ばれた時には参照できるものが無い？
        SceneManager.activeSceneChanged += Scenechange;
    }

    private void Scenechange(Scene currentscene,Scene newscene)
    {
        //RunSave();
    }

    //データセーブを実行するメソッド
    public void RunSave()
    {
        
        //現在のシーン名とプレイヤーの座標を取得
        SaveData data =gameObject.GetComponent<SaveData>();
        data.scenename = SceneManager.GetActiveScene().name;
        data.currentpoint = gameObject.transform.position;

        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

        //BinaryFormatterは旧型式であり，セキュリティ上の問題から禁止
        using (FileStream file = File.Create(Application.persistentDataPath))
        {
            //データ書き込み
            serializer.Serialize(file, data);
        }

    }

    //セーブデータをロードするメソッド
    public void DataLoad()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        using(FileStream file = File.OpenRead(Application.persistentDataPath)) 
        {
            //データ読み込み
            SaveData data=(SaveData)serializer.Deserialize(file);
            //前のデータに手に入れたデータを上書き，キャラクター配置
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
