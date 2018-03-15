using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;

public class PlayerInputControl:MonoBehaviour {

    public static event del_PlayerControlWithStr evePlayerControl;


    void Update()
    {
        //按键参数传入
        if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            }
        }
        else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A))
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
            }
        }
        else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B))
        {
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
            }
        }
    }
}
