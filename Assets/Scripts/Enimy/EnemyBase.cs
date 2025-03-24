using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enimy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        //public FlashColor flashColor;
        public int StarLife = 10;
        private int _currentLife;
        protected bool _isDead = false;

        [Header("Animation")]
        public ScriptAnimation animationBase;
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithbornAnimation = true;
        public float timeDestroyed = 4f;
        public ParticleSystem particleDamage = null;


        public FlashColor _flashcolor;


        private void Awake()
        {
            Init();
            if (_flashcolor == null)
            {
                _flashcolor = GetComponentInChildren<FlashColor>();
            }
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startWithbornAnimation)
            {
                BornAnimation();
            }
        }

        public void ResetLife()
        {
            _isDead = false;
            _currentLife = StarLife;
        }

        public void OnDamage(int damage, Transform pos)
        {
            if (_flashcolor != null)
            {
                _flashcolor.Flash();
            }
            if (particleDamage != null)
            {
                particleDamage.Play();
            }
            if (_isDead) return;
            _currentLife -= damage;
            if (!_isDead)
            {

                if (_currentLife <= 0)
                {
                    kill();
                    _isDead = true;
                }
            }
        }


        protected virtual void kill()
        {
            if (_flashcolor != null)
            {
                OnKill();
            }
            if(collider != null)
            {
                collider.enabled = false;
            }
            if (animationBase != null)
                PlayAnimationByTrigger(AnimationType.DEATH);
        }


        public void OnKill()
        {
            StartCoroutine(OperaçãodeTempoSumir());
        }

        IEnumerator OperaçãodeTempoSumir()
        {
            yield return new WaitForSeconds(timeDestroyed);
            Destroy(gameObject, 0.001f);
        }

        /*public int damage = 10;

        public HealthBase healtBase;

        private void Awake()
        {
            if(healtBase != null)
            {
                healtBase.OnKill += OnEnemyKill;
            }
        }

        private void OnEnemyKill()
        {
            healtBase.OnKill -= OnEnemyKill;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            /*var health = collision.gameObject.GetComponent<HealthBasePlayer>();

            if (health != null)
            {
                health.Damage(damage);
            }*/
        /*}


         public void Damage(int dano)
         {
             healtBase.Damage(dano);
         }*/

        #region Animation

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationTipe)
        {
            animationBase.PlayAnimationByTrigger(animationTipe);
        }

        public void Damage(int damage, Transform pos)
        {
            OnDamage(damage, pos);               
        }
        #endregion
    }
}
