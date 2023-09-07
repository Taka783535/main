using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーをコピーする
public class Player_copy : MonoBehaviour
{

    //プレイヤーのGameObject
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(player);
    }

    
}
