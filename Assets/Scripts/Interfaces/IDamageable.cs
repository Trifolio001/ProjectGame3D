using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damage);


    void Damage(int damage, Transform pos);


    void Damage(int damage, Transform pos, bool recoil, bool constant);
}
