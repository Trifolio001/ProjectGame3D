using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class FSMexemple : MonoBehaviour
{
    public enum Exampleenum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }

    public StateMachine<Exampleenum> stateMachine;

    public void Start()
    {
        stateMachine = new StateMachine<Exampleenum>();
        stateMachine.Init();
        stateMachine.RegisterStates(Exampleenum.STATE_ONE, new StateBase());
        stateMachine.RegisterStates(Exampleenum.STATE_TWO, new StateBase());

        stateMachine.Switchstate(Exampleenum.STATE_ONE);
    }
}
