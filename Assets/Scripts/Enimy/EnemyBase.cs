using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        //public FlashColor flashColor;
        public int StarLife = 10;
        private int _currentLife;
        protected bool _isDead = false;
        public bool lookAtPlayer = false;

        [Header("Effect Recoil")]
        public bool activeRecoil = true;
        public float forceRecoil = 1;

        [Header("Animation")]
        public ScriptAnimation animationBase;
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithbornAnimation = true;
        public float timeDestroyed = 4f;
        public ParticleSystem particleDamage = null;

        private PlayerControl _player;
        public FlashColor _flashcolor;

        public List<string> tagsToHit;

        public HealthBase healthBase;

        private void OnValidate()
        {
            if (healthBase == null) healthBase = GetComponent<HealthBase>();
            if (_flashcolor == null)
            {
                _flashcolor = GetComponentInChildren<FlashColor>();
            }
        }

        private void Awake()
        {
            OnValidate();
            Init();
        }



        private void Start()
        {
            _player = GameObject.FindObjectOfType<PlayerControl>();
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



        public void OnDamage(int damage, Transform pos, bool recoil)
        {
            if (_flashcolor != null)
            {
                _flashcolor.Flash();
            }
            if (recoil && activeRecoil)
            {
                Vector3 dir = transform.position - pos.transform.position;
                dir = -dir.normalized;
                transform.position -= dir * forceRecoil;
            }
            if (particleDamage != null)
            {
                particleDamage.transform.position = pos.position;
                particleDamage.transform.rotation = Quaternion.Euler(pos.rotation.x + 180, pos.rotation.y, pos.rotation.z);
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

        public void Damage(int damage)
        {

        }
        public void Damage(int damage, Transform pos)
        {

        }

        public void Damage(int damage, Transform pos, bool recoil, bool constant)
        {
            OnDamage(damage, pos, recoil);               
        }
        #endregion

        private void OnTriggerStay(Collider collision)
        {
            foreach (var t in tagsToHit)
            {
                IDamageable p = collision.transform.GetComponent<IDamageable>();

                if (p != null)
                {
                    p.Damage(1, null, false, false);
                }
            }
        }


        public virtual void Update()
        {
            if (lookAtPlayer && (_player != null))
            {
                transform.LookAt(new Vector3(_player.transform.position.x, _player.transform.position.y - 3,  _player.transform.position.z));
            }
        }

    }

}
