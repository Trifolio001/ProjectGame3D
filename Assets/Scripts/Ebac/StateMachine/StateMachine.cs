using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NaughtyAttributes;


namespace Ebac.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dictionarystate;

        private StateBase _currentState;
        public float timeTostartGame = 1f;

        public StateBase currentstate
        {
            get { return _currentState; }
        }

        public void Init()
        {
            dictionarystate = new Dictionary<T, StateBase>();
        }


        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionarystate.Add(typeEnum, state);
        }

        public void Switchstate(T state, params object[] objs)
        {
            if (_currentState != null) _currentState.onstateExit();

            _currentState = dictionarystate[state];
            _currentState.onstateEnter(objs);
        }

        public void update()
        {
            if (_currentState != null) _currentState.onstateStay();
        }
    }
}
