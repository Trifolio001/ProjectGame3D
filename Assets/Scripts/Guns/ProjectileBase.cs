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
        var enimy = collision.transform.GetComponent<IDamageable>();

        //var enimy = collision.transform.GetComponent<Enimy.EnemyBase>();

        if(enimy != null)
        {
            VFXBullet();
            enimy.Damage(damegeAmount, transform);
            Destroy(gameObject);
        }
    }


    public void VFXBullet()
    {
        //VFXManeger.Instance.PlayVFXByTipe(VFXManeger.VFXType.BulletEfect, transform.position, -transform.localScale.x);

    }

}
