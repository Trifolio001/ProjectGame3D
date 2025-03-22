using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAngle : GunShootLimit
{
    public int amountPerShot = 4;
    public float angle = 15f;

    public override void Shoot()
    {
        //int mult = 0;

        float PositionsShot = -((angle * amountPerShot) / 2) + (angle / 2);
        
        for(int i = 0; i < amountPerShot; i++)
        {
            var projectile = Instantiate(prefabProjetil, positionToShoot);

            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * PositionsShot;
            PositionsShot += angle;

            /*if(i%2 == 0)
            {
                mult++;
            }
            var projectile = Instantiate(prefabProjetil, positionToShoot);

            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;*/

            projectile.speed = speed;
            projectile.transform.parent = null; 
        }


    }
}
