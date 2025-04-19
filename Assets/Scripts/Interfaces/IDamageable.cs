using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(float damage);


    void Damage(float damage, Transform pos);


    void Damage(float damage, Transform pos, bool recoil, bool constant);

}
