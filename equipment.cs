using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    //武器を装備させるヒューマノイドパーツ。通常右手。
    public GameObject weaponequipparts;

    //武器をキャラクターに装備させる。装備する武器を引数に持つ。
    public void EquipWeapon(GameObject weapon)
    {
        GameObject.Instantiate(weapon, weaponequipparts.transform);
    }
}
