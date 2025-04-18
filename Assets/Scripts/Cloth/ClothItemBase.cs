using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth {
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;
        public float duration =2f;

        public string comparetag = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(comparetag))
            {
                PlayerControl p = other.transform.GetComponent<PlayerControl>();
                if ((p != null))
                {
                    Collect(p); ;
                }
            }
        }

        public virtual void Collect(PlayerControl p)
        {
            var setup = ClothManager.Instance.GetSetupByType(clothType);
            p.ChangeTexture(setup, duration);
            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}
