using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

namespace Boss
{
    public class BossStatesBase : StateBase
    {
        protected BossBase boss;

        public override void onstateEnter(params object[] objs)
        {

            base.onstateEnter(objs);
            boss = (BossBase)objs[0];
        }


    }

    public class BossStateInit : BossStatesBase
    {
        public override void onstateEnter(params object[] objs)
        {
            base.onstateEnter(objs);
            boss.startInitAnimation();
        }


        public override void onstateExit(object o = null)
        {
            base.onstateExit();
            boss.StopAllCoroutines();
        }
    }

    public class BossStateWalk : BossStatesBase
    {
        public override void onstateEnter(params object[] objs)
        {
            base.onstateEnter(objs);
            boss.GoToRandomPoint();
        }

        private void OnArride()
        {
            boss.SwitchState(BossAction.ATTACK);
        }

        public override void onstateExit(object o = null)
        {
            base.onstateExit();
            boss.StopAllCoroutines();
        }
    
    }

    public class BossStateAttack : BossStatesBase
    {
        public override void onstateEnter(params object[] objs)
        {
            base.onstateEnter(objs);
            boss.StartAttack();
        }

        private void EndAttacks()
        {
            boss.SwitchState(BossAction.WALK);
        }
        private void OnArride()
        {
            boss.SwitchState(BossAction.WALK);
        }

        public override void onstateExit(object o = null)
        {
            base.onstateExit();
            boss.StopAllCoroutines();
        }
    }

    public class BossStateDeath : BossStatesBase
    {
        public override void onstateEnter(params object[] objs)
        {
            base.onstateEnter(objs);
            //boss.startInitAnimation();
        }
    }

}
