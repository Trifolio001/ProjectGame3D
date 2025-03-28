using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    //public Vector3 direction;
    //public SOBullet soBullet;


    public float timeToDestroy = 2f;

    public int damegeAmount = 1;

    public float speed = 50f;

    public bool recoil = true;

    public List<string> tagsToHit;

    void Update()
    {

        //Vector3 direction = new Vector3(-soBullet.velocity, 0, 0);
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    /*private void Start()
    {
        transform.localScale = new Vector3(side, 1, 1);
    }*/

    private void OnTriggerEnter(Collider collision)
    {
        foreach(var t in tagsToHit)
        {
            if(collision.transform.tag == t)
            {
                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    VFXBullet();
                    damageable.Damage(damegeAmount, transform, recoil);
                    
                    
                }
                Destroy(gameObject);
                break;
            }
        }
        
    }


    public void VFXBullet()
    {
        //VFXManeger.Instance.PlayVFXByTipe(VFXManeger.VFXType.BulletEfect, transform.position, -transform.localScale.x);

    }

}
