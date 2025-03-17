using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Player {
    public class ControlPlayer : MonoBehaviour
    {
        [Header("setup")]
        public SOPlayerSetup soPlayerSetup;
        //public SOInfoUI ReferenciaItem;

        public bool InPlataform = false;
        public bool down = false;
        public Rigidbody myRigidbody;


        [Header("Detect")]
        public Transform DetectPlataform;
        public LayerMask MaskPlataform; 
        public QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal;

        [Header("Effects")]
        //public AudioRandomPlayAudioClips audiorandom;
        public AudioSource songjump;

        public float _currentTopSpeed;
        public float _currentNowSpeed;


        // Start is called before the first frame update
        void Start()
        {

            down = false;
        }

        void Update()
        {
            controls();
            //InPlataform = PhysicsD.OverlapCircle(DetectPlataform.position, 0.5f, MaskPlataform);
            InPlataform = Physics.CheckSphere(DetectPlataform.position, 0.5f, MaskPlataform, triggerInteraction);

            if (InPlataform)
            {
                /*_curretPlayerLegs.SetBool(soPlayerSetup.boolJump, false);
                _curretPlayerArms.SetBool(soPlayerSetup.boolJump, false);
                if ((particlesystemLand1 != null) && (particlesystemLand2 != null) && (down))
                {
                    particlesystemLand1.Play();
                    particlesystemLand2.Play();
                    tocaaudio();
                    Invoke(nameof(tocaaudio), 0.1f);
                }*/
                down = false;
            }
            else
            {
                /*if (_curretPlayerLegs.GetBool(soPlayerSetup.boolJump) == false)
                {
                    _curretPlayerLegs.SetBool(soPlayerSetup.TrigerJump, true);
                    _curretPlayerArms.SetBool(soPlayerSetup.TrigerJump, true);
                }
                _curretPlayerLegs.SetBool(soPlayerSetup.boolJump, true);
                _curretPlayerArms.SetBool(soPlayerSetup.boolJump, true);*/
            }
            if (myRigidbody.velocity.y <= 0)
            {
                /*_curretPlayerLegs.SetBool(soPlayerSetup.boolJumpDown, true);
                _curretPlayerArms.SetBool(soPlayerSetup.boolJumpDown, true);*/
                //if (_curretPlayerLegs.GetBool(soPlayerSetup.boolJump) == true)
                if(!InPlataform) 
                {
                    down = true;
                }
            }
        }

        private void controls()
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //myRigidbody.rotation = new Vector3(-_CurrentSpeed, myRigidbody.velocity.y);
                //myRigidbody.velocity = new Vector3(+15, myRigidbody.velocity.y);

                myRigidbody.velocity = new Vector3(transform.forward.x * soPlayerSetup.speed, myRigidbody.velocity.y, transform.forward.z * soPlayerSetup.speed);

                /*_curretPlayerLegs.transform.localScale = new Vector3(1, 1, 1);
                _curretPlayerLegs.SetBool(soPlayerSetup.boolWalk, true);
                _curretPlayerArms.SetBool(soPlayerSetup.boolWalk, true);
                velCammov = velCam * 2;
                directioncam = -1;*/
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //myRigidbody.velocity = new Vector3(-15, myRigidbody.velocity.y);
                myRigidbody.velocity = new Vector3(transform.forward.x * -soPlayerSetup.speed, myRigidbody.velocity.y, transform.forward.z * -soPlayerSetup.speed);

                
                //myRigidbody.velocity = new Vector2(_CurrentSpeed, myRigidbody.velocity.y);
                /* _curretPlayerLegs.transform.localScale = new Vector3(-1, 1, 1);
                _curretPlayerLegs.SetBool(soPlayerSetup.boolWalk, true);
                _curretPlayerArms.SetBool(soPlayerSetup.boolWalk, true);
                velCammov = velCam * 2;
                directioncam = 1;*/
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(soPlayerSetup.forceRotate * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-soPlayerSetup.forceRotate * Time.deltaTime);
            }

                if (Input.GetKeyDown(KeyCode.Space))
            {
                if (InPlataform == true)
                {
                    myRigidbody.velocity = Vector3.up * soPlayerSetup.forcejump;
                    if (songjump != null)
                    {
                        songjump.Play();
                    }
                }
            }
        }
    }
}
