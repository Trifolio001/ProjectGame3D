using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class StateBase 
    {
        public virtual void onstateEnter(params object[] objs)
        {

        }
        public virtual void onstateStay(object o = null)
        {

        }
        public virtual void onstateExit(object o = null)
        {

        }
    }
}
