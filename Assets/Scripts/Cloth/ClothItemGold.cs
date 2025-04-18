using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


namespace Cloth
{
    public class ClothItemGold : ClothItemBase
    {
        public int CoinMultiply = 2;
        public override void Collect(PlayerControl p)
        {
            base.Collect(p);
            Item_manager.Instance.ChangeCoinvalue(CoinMultiply, duration);
        }

    }
}


