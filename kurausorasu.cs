using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kurausorasu : BaseSword
{

    private void Start()
    {

        GameObject player = transform.root.gameObject; //プレイヤーの3Dモデル
        Setting set =player.transform.Find("property_object").GetComponent<Setting>();
        base.inspectorname = set.inspectorname;
        base.inspectortext = set.inspectortext;
        base.equipparts = set.equipparts;
        base.usebutton= set.usebutton;
        
    }



}
