using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }

    public class BossBase : MonoBehaviour
    {
        [Header("Animation")]
        public float startAnimationDuration = 0.5f;
        public Ease StartAnimationEase = Ease.OutBack;


        [Header("Attack")]
        public int damageBoss = 5;
        public float attackAmount = 5f;
        public float timeBetweenAttack = 1f;
        public float rangeSpikes = 3f;
        public GameObject spikesGroup;
        private PlayerControl _player;
        public bool lookAtPlayer = false;

        public HealthBase healthBase;

        public float speed;
        public List<Transform> wayPoints;
        public StateMachine<BossAction> stateMachine;

        private int a = 0;

        public List<string> tagsToHit;
        public List<FlashColor> flashcolor;
        private bool kill = false;

        private void Awake()
        {
            Init();
            healthBase.onDamage += Damage;
            healthBase.onKill += OnBossKill;
        }



        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();
            stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());
            SwitchState(BossAction.INIT);
            _player = GameObject.FindObjectOfType<PlayerControl>();
        }

        public virtual void Update()
        {
            if (lookAtPlayer && (_player != null))
            {
                transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            }
        }

        #region Walk
        public void GoToRandomPoint(Action OnArrive = null)
        {
            
            StartCoroutine(GoToPointCorotine(wayPoints[a = UnityEngine.Random.Range(0, wayPoints.Count)], OnArrive));
        }

        IEnumerator GoToPointCorotine(Transform t, Action onArrive = null)
        {


            while (Vector3.Distance(transform.position, new Vector3(t.transform.position.x, transform.position.y, t.transform.position.z)) > 1f)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(t.transform.position.x, transform.position.y, t.transform.position.z), Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }

            SwitchState(BossAction.ATTACK);
        }
        #endregion

        #region Attack

        public void StartAttack()
        {
            StartCoroutine(AttackCoroutine());
        }

        IEnumerator AttackCoroutine()
        {
            int attacks = 0;
            while(attacks < attackAmount)
            {
                attacks++;
                transform.DOScale(1.5f, 1).SetLoops(2, LoopType.Yoyo);
                spikesGroup.transform.DOScale(rangeSpikes, 1).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(timeBetweenAttack);
            }
            SwitchState(BossAction.WALK);

        }
        #endregion

        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            SwitchState(BossAction.WALK);
        }
        [NaughtyAttributes.Button]
        private void SwitchAttack()
        {
            SwitchState(BossAction.ATTACK);
        }


        #region StateMachine
        public void SwitchState(BossAction state)
        {
            stateMachine.Switchstate(state, this);
        }
        #endregion

        #region Animation
        public void startInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(StartAnimationEase).From();
            Invoke(nameof(StopToAnimator), startAnimationDuration + 0.01f);
        }

        private void StopToAnimator()
        {
            SwitchState(BossAction.ATTACK);
        }
        #endregion

        private void OnTriggerStay(Collider collision)
        {

            foreach (var t in tagsToHit)
            {
                IDamageable p = collision.transform.GetComponent<IDamageable>();

                if (p != null)
                {
                    p.Damage(damageBoss, null, false, false);
                }
            }
        }


        public void Damage(HealthBase h)
        {
            if (flashcolor != null)
            {
                flashcolor.ForEach(i => i.Flash());
            }
        }

        private void OnBossKill(HealthBase h)
        {
            if (!kill)
            {
                //animator.SetTrigger("Death");
                OnKill();
                kill = true;
            }
            SwitchState(BossAction.DEATH);
        }
        public void OnKill()
        {
            Destroy(gameObject, 4f);
        }


    }
}
