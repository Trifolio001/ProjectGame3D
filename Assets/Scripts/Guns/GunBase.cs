using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjetil;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public float speed = 50f;
    //public bool DesactivateChoot = false;
    //public bool recharge = false;

    //public Transform PlayerSideReference;

    private Coroutine _currentCoroutine;


    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    
    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjetil);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;
        //projectile.side = PlayerSideReference.transform.localScale.x;
    }

    public virtual void StartGun(int bullet, PlayerAbilityShoot reference)
    {

    }

    public void startShoot()
    {        
        stopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void stopShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }


}
