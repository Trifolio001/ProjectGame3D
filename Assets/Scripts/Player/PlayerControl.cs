using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
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


    private float _currentTopSpeed;
    private float _currentNowSpeed;


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
                _currentTopSpeed = speed*speedRun;
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
        else  if (_currentTopSpeed > _currentNowSpeed)
        {
            _currentNowSpeed += aceleration * Time.deltaTime;
        }else if ((_currentTopSpeed < _currentNowSpeed))
        {
            _currentNowSpeed -= aceleration * Time.deltaTime;
        }
        var speedVector = transform.forward * inputAxisVertical * _currentNowSpeed;
        speedVector.y = vSpeed;
        characterController.Move(speedVector * Time.deltaTime);
    }
}
