using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using Ebac.StateMachine;
using Player;



public class AnimatorManagerPlayer : Singleton<AnimatorManagerPlayer>
{
    public enum AnimationType
    {
        START,
        IDLE,
        RUN,
        JUMPUP,
        JUMPDOWN,
        DEAD,
        FLY,
        MAGNETIC
    }

    public Animator animator;
    public StateMachine<AnimationType> stateMachines;
    public List<AnimatorSetup> stateAnimator;


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachines = new StateMachine<AnimationType>();
        stateMachines.Init();
        stateMachines.RegisterStates(AnimationType.IDLE, new GMAnimatorIdle());
        stateMachines.RegisterStates(AnimationType.RUN, new GMAnimatorRun());
        stateMachines.RegisterStates(AnimationType.JUMPUP, new GMAnimatorJumpUp());
        stateMachines.RegisterStates(AnimationType.JUMPDOWN, new GMAnimatorJumpDown());
        stateMachines.RegisterStates(AnimationType.DEAD, new GMAnimatorDead());

        stateMachines.Switchstate(AnimationType.IDLE);
    }


    public void Update()
    {
        if (stateMachines.currentstate != null)
        {
            //stateMachines.currentstate;
        }
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
        {
            foreach (var animation in stateAnimator)
            {
                if (animation.type == type)
                {
                    animator.SetTrigger(animation.trigger);
                    animator.speed = animation.speed * currentSpeedFactor;
                    break;
                }
            }
        }



        [System.Serializable]
        public class AnimatorSetup
        {
            public AnimatorManagerPlayer.AnimationType type;
            public string trigger;
            public float speed = 1f;
        }
     
}
