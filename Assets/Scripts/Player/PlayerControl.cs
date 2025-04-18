using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;
using DG.Tweening;

public class PlayerControl : MonoBehaviour  //, IDamageable
{
    public CharacterController characterController;
    public float aceleration = 1f;
    public float speed = 1f; 
    public float turnSpeed = 1f; 
    public float gravity = 9.8f;
    public float jumpSpeed = 15f;
    public Animator animator; 
    private float vSpeed = 0f;


    public KeyCode jumpKeycode = KeyCode.Space;
    [Header("Run Setup")] 
    public KeyCode keyRun = KeyCode.LeftShift; 
    public float speedRun = 1.5f;


    [Header("Damage Enimy")]
    public GameObject bossCamera;
    public float durationStopDamage = 0.2f;
    private float _currentTopSpeed;
    private float _currentNowSpeed;
    private bool ReferencetimeDamage = false;
    public HealthBase healthBase;
    public List<FlashColor> flashcolor;
    public float timeRevavel = 3f;

    [Space]
    [SerializeField] private ClothChanger _clothChanger;

    private bool kill = false;

    private float _speed = 1f;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();

        healthBase.onDamage += Damage;
        healthBase.onKill += OnKill;

        _speed = speed;
        InicialCloth(ClothType.NULL);
    }


    public void OnKill(HealthBase h)
    {
        if (!kill)
        {

            bossCamera.SetActive(false);
            EffectManager.Instance.ChangeColorGradingIn();
            characterController.enabled = false;
            animator.SetTrigger("Death");
            kill = true;
            StartCoroutine(Revive());
        }
    }

    public void Damage(HealthBase h)
    {
        if (flashcolor != null)
        {
            flashcolor.ForEach(i => i.Flash());
        }   
    }



    void Update()
    {


        if (!kill)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
            var inputAxisVertical = Input.GetAxis("Vertical");
            vSpeed -= gravity * Time.deltaTime;

            if (characterController.isGrounded)
            {
                animator.SetBool("ground", true);
                vSpeed = -gravity;
                if (Input.GetKeyDown(jumpKeycode))
                {
                    vSpeed = jumpSpeed;
                }
            }
            else
            {
                animator.SetBool("ground", false);
                if (vSpeed > 0)
                {
                    AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.JUMPUP);
                    animator.SetBool("downjump", false);
                }
                else
                {
                    AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.JUMPDOWN);
                    animator.SetBool("downjump", true);
                }
            }


            //animator.SetBool("run", inputAxisVertical != 0);

            walkPlayer(inputAxisVertical);

            if ((aceleration <= 0) && _currentTopSpeed == 0)
            {
                _currentNowSpeed = 0;
            }
            else if (_currentTopSpeed > _currentNowSpeed)
            {
                _currentNowSpeed += aceleration * Time.deltaTime;
            }
            else if ((_currentTopSpeed < _currentNowSpeed))
            {
                _currentNowSpeed -= aceleration * Time.deltaTime;
            }
            var speedVector = transform.forward * inputAxisVertical * _currentNowSpeed;
            speedVector.y = vSpeed;
            characterController.Move(speedVector * Time.deltaTime);
        }
    }

    private void walkPlayer(float inputAxisVertical)
    {
        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        {
            if (characterController.isGrounded)
                AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.RUN);
            animator.SetBool("run", true);
            if (Input.GetKey(keyRun))
            {
                _currentTopSpeed = speed * speedRun;
                animator.speed = (speed * speedRun) / _speed;
                Debug.Log("anim " + (speedRun/ _speed));
            }
            else
            {
                _currentTopSpeed = speed;
                animator.speed =  speed / _speed;
            }

        }
        else
        {
            animator.SetBool("run", false);
            if (characterController.isGrounded)
                AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.IDLE);
            _currentTopSpeed = 0;
        }

    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(timeRevavel);
        Respaw();
        yield return new WaitForSeconds(timeRevavel);
        CheckPointManager.Instance.AnimatedCheckPoint();
        EffectManager.Instance.ChangeColorGradingOut();
        kill = false;
        healthBase.ResetLife();
        animator.SetTrigger("Revival");
        
    }

    [NaughtyAttributes.Button]
    public void Respaw()
    {
        if (CheckPointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckPointManager.Instance.GetPositionFromLastCheckPoint();
        }
        characterController.enabled = true;
    }



        #region IDamage
        /*public void Damage(int damage)
        {
            ConfirmDamage();
        }
        
        public void Damage(int damage, Transform pos)
        {
            ConfirmDamage();
        }

        public void Damage(int damage, Transform pos, bool recoil)
        {
            ConfirmDamage();
        }
        #endregion

        private void ConfirmDamage()
        {
            if (!ReferencetimeDamage)
            {
                ReferencetimeDamage = true;
                FeedBackDamage();
                Invoke(nameof(OperaçãodeTempoDamage), durationStopDamage + 0.1f);
            }
        }

        public void OperaçãodeTempoDamage()
        {
            ReferencetimeDamage = false;
        }*/
        #endregion

    private void InicialCloth(ClothType Type)
    {
        ClothSetup setup = ClothManager.Instance.GetSetupByType(Type);
        _clothChanger.ChangeTexture(setup); 
        foreach (var child in gameObject.GetComponentsInChildren<ClothChanger>())
        {
            child.DefaultTextureSave();
        }        
    }

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCourotine(speed, duration));
    }

    IEnumerator ChangeSpeedCourotine(float localSpeed, float duration)
    {
        var defaultspeed = speed;
        var defaultspeedRun = speedRun;
        speed = localSpeed;
        speedRun = localSpeed;
        walkPlayer(Input.GetAxis("Vertical"));
        yield return new WaitForSeconds(duration);
        speed = defaultspeed;
        speedRun = defaultspeedRun;
        walkPlayer(Input.GetAxis("Vertical"));
    }

    public void ChangeTexture(ClothSetup setup, float duration)
    {
        if (duration == 0)
        {
            InicialCloth(setup.clothType);
        }
        else
        {
            StartCoroutine(ChangeTextureCourotine(setup, duration));
        }
    }

    IEnumerator ChangeTextureCourotine(ClothSetup setup, float duration)
    {
        _clothChanger.ChangeTexture(setup);
        if (setup.Visual != null)
        {
            setup.Visual.SetActive(true);
            setup.Visual.transform.localScale = Vector3.zero; 
            setup.Visual.transform.DOScale(1, 0.5f).SetEase(Ease.InFlash);
        }
        yield return new WaitForSeconds(duration);
        if (setup.Visual != null)
        {
            setup.Visual.transform.DOScale(Vector3.zero, 2f).SetEase(Ease.OutBounce);
        }
        _clothChanger.ResetTexture();
        if (setup.Visual != null)
        {
            yield return new WaitForSeconds(2f);
            setup.Visual.SetActive(false);
        }
    }
}
