using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;


public class SaveandLoadManager : MonoBehaviour
{
    /*********************************************************************************
     * セーブデータのセーブ・ロード機能を提供するクラス
     * 
     * 処理の補足解説
     * セーブデータはJSON形式で保存し暗号化されたファイルに保存されている
     * データセーブ時：SaveDataクラス型のデータを一度JSONに変換してからファイルへ保存
     * データロード時：ファイルから取り出したJSON データをさらにSaveDataクラスへ変換
     *********************************************************************************/


    /*************************************************************
     * データセーブを行うメソッド
     * 引数：保存するためのセーブデータ(SaveData型のインスタンス)
     * 戻り値：なし
     * 概要：
     * セーブデータファイルにセーブデータをJSON形式で保存。
     **************************************************************/
    public static void DataSave(SaveData data)
    {
        //シリアライズ化してファイルに保存する。
        string jsondata=JsonUtility.ToJson(data);  //セーブデータをJSONに変換
        string filepath = Application.persistentDataPath + "/savedata"+".json"; //セーブデータのパス
        string copypath = Application.persistentDataPath + "/savedatacopy" + ".json";
        StreamWriter streamWriter = new StreamWriter(filepath); //セーブデータ書き込み用
        StreamWriter streamWriter1 = new StreamWriter(copypath); //更新セーブデータ書き込み用


        if (File.Exists(Application.persistentDataPath)==false) 
        {
            //セーブデータファイルが無かった時の処理
            //フォルダーにセーブファイルがなければ新規作成
            try
            {
                //書き込み処理
                streamWriter.Write(jsondata);
                
                
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                //ファイルを閉じる
                streamWriter.Close();
                File.Encrypt(filepath);   //ファイルの暗号化
            }
        }
        else
        {
            //セーブデータファイルが存在する時の処理
            //セーブデータファイルが存在するならば新しいファイルを作成して内容を書き込みファイル置換を行う。
            try
            {
                streamWriter1.Write(jsondata);  //新規ファイル作成，更新セーブデータ書き込み
                File.Decrypt(filepath);   //上書きするファイルの暗号化解除
                File.Copy(copypath, filepath, true);  //ファイル上書き
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                streamWriter1.Close();
                File.Encrypt(filepath);　//ファイル暗号化
                File.Delete(copypath);   //上書き用で使ったファイルは不要なので削除
            }

            

        }

        streamWriter.Close();
        streamWriter1.Close();
        
    }



    /**************************************************************
     * セーブデータをロードするメソッド
     * 引数：なし
     * 戻り値：ロードしたセーブデータ
     * 概要：
     * セーブファイルに保存されているセーブデータを読み込んで返す。
     * 失敗するとnullが返ってくる。
     **************************************************************/
    public static SaveData DataLoad()
    {
        SaveData loaddata=null; //ロードしたセーブデータ
        string data=null;  //JSONセーブデータの一時保管用バッファ
        string filepath = Application.persistentDataPath + "/savedata.json"; //ファイルパス
        StreamReader streamReader = new StreamReader(filepath);

        //JSONで保存してあるセーブデータを読みこんで返す
        try
        {
            File.Decrypt(filepath);   //セーブファイルの復号化
            data = streamReader.ReadToEnd();  //セーブデータを開いて読み込む
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            streamReader.Close();　　//セーブファイルを閉じる
            File.Encrypt(filepath);  //セーブファイルの暗号化
        }

        //読み込んだデータをJSONからSaveDataクラス型へ戻す
        if (data == null)
        {
            //dataバッファがnullのままならセーブデータの読み込み失敗
            Debug.Log("セーブデータのロードに失敗しました。");
        }
        else
        {
            loaddata = JsonUtility.FromJson<SaveData>(data);
        }

        return loaddata;
    }



    /******************************************
     * 初期セーブデータ作成メソッド
     * 引数：プレイヤー名
     * 戻り値：初期化されたセーブデータ
     * 概要：プレイヤー名以外のステータスを初期化する
     ******************************************/
    public static SaveData CreateSaveData(string playername)
    {
        //プレイヤー名以外初期値で新規のセーブデータを作成する
        SaveData savedata = new SaveData();
        savedata.playername = playername;
        return savedata;
    }


    

}
