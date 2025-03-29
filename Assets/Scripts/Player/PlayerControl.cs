using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //, IDamageable
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
    public float durationStopDamage = 0.2f;
    private float _currentTopSpeed;
    private float _currentNowSpeed;
    private bool ReferencetimeDamage = false;
    public HealthBase healthBase;
    public List<FlashColor> flashcolor;
    public float timeRevavel = 3f;

    private bool kill = false;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();

        healthBase.onDamage += Damage;
        healthBase.onKill += OnKill;
    }


    public void OnKill(HealthBase h)
    {
        if (!kill)
        {
            characterController.enabled = false;
            animator.SetTrigger("Death");
            kill = true;
            Invoke(nameof(Revive), timeRevavel);
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


            var isWalking = inputAxisVertical != 0;
            if (isWalking)
            {
                if (characterController.isGrounded)
                    AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.RUN);
                animator.SetBool("run", true);
                if (Input.GetKey(keyRun))
                {
                    _currentTopSpeed = speed * speedRun;
                    animator.speed = speedRun;
                }
                else
                {
                    _currentTopSpeed = speed;
                    animator.speed = 1;
                }

            }
            else
            {
                animator.SetBool("run", false);
                if (characterController.isGrounded)
                    AnimatorManagerPlayer.Instance.stateMachines.Switchstate(AnimatorManagerPlayer.AnimationType.IDLE);
                _currentTopSpeed = 0;
            }

            if ((aceleration <= 0) && _currentTopSpeed == 0)
            {
                _currentNowSpeed = 0;
            }
            else if (_currentTopSpeed > _currentNowSpeed)
            {
                _currentNowSpeed += aceleration * Time.deltaTime;
            } else if ((_currentTopSpeed < _currentNowSpeed))
            {
                _currentNowSpeed -= aceleration * Time.deltaTime;
            }
            var speedVector = transform.forward * inputAxisVertical * _currentNowSpeed;
            speedVector.y = vSpeed;
            characterController.Move(speedVector * Time.deltaTime);
        }

    private void Revive()
    {
        kill = false;
        healthBase.ResetLife();
        animator.SetTrigger("Revival");
        Respaw();
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
    
}
