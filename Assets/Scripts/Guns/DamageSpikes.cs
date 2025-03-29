using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpikes : MonoBehaviour
{

    public List<string> tagsToHit;

    private void OnTriggerStay(Collider collision)
    {
        foreach (var t in tagsToHit)
        {
            IDamageable p = collision.transform.GetComponent<IDamageable>();

            if (p != null)
            {
                p.Damage(3, null, false, false);
            }
        }
    }
}
