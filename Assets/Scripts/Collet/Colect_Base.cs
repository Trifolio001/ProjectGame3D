using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Colect_Base : MonoBehaviour
    {
        public ItemType itemType;
        public string compareTag = "Player";

        public ParticleSystem particlesystem;
        public float timeToHide = 2;
        public GameObject graphicItem;

        private bool capture = false;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake()
        {
            capture = false;
            /* if (particlesystem != null)
             {
                 particlesystem.transform.SetParent(null);
             }*/
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        protected virtual void Collect()
        {
            if (graphicItem != null)
            {
                graphicItem.SetActive(false);
            }

            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        protected virtual void OnCollect()
        {
            if (!capture)
            {
                Item_manager.Instance.AddByType(itemType); 

                if (particlesystem != null)
                {
                    particlesystem.Play();
                }

                if (audioSource != null)
                {
                    audioSource.Play();
                }

                capture = true;
            }
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

    }
}

