using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[���R�s�[����
public class Player_copy : MonoBehaviour
{

    //�v���C���[��GameObject
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(player);
    }

    
}
