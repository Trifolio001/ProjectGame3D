using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth {
    public class ClothItemSpeed : ClothItemBase
    {
        public float targetSpeed = 2f;
        public override void Collect(PlayerControl p)
        {
            base.Collect(p);
            p.ChangeSpeed(targetSpeed, duration);
        }
    }
}
