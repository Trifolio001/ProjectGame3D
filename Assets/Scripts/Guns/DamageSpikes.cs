using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpikes : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        PlayerControl p = collision.transform.GetComponent<PlayerControl>();

        if (p != null)
        {
            p.Damage(1);
        }
    }
}
