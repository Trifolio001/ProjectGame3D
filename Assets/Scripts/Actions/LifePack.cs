using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class LifePack : MonoBehaviour
{
     
    private void RecoverLife()
    {
        Item_manager.Instance.RemoveByType(ItemType.LIFE_PACK);
        Item_manager.Instance.player.healthBase.ResetLife();
    }

}
