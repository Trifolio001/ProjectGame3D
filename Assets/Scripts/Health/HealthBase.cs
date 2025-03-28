using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{

    public int StarLife = 10;
    public int _currentLife;
    public bool _isDead = false;
    public float timeDestroyed = 0.01f;
    public FlashColor _flashcolor;

    public Action<HealthBase> onDamageHit;
    public Action<HealthBase> onKillHit;

    public void Awake()
    {
        Init();
    }
    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _isDead = false;
        _currentLife = StarLife;
    }



    public void OnDamage(int damage, Transform pos, bool recoil)
    {
        if (_flashcolor != null)
        {
            _flashcolor.Flash();
        }   
        if (_isDead) return;
        _currentLife -= damage;
        if (!_isDead)
        {

            if (_currentLife <= 0)
            {
                kill();
                _isDead = true;
            }
        }
    }


    protected virtual void kill()
    {
        if (_flashcolor != null)
        {
            OnKill();
        }
        /*if (collider != null)
        {
            collider.enabled = false;
        }
        if (animationBase != null)
            PlayAnimationByTrigger(AnimationType.DEATH);*/
    }


    public void OnKill()
    {
        StartCoroutine(OperaçãodeTempoSumir());
    }


    IEnumerator OperaçãodeTempoSumir()
    {
        yield return new WaitForSeconds(timeDestroyed);
        Destroy(gameObject, 0.001f);
    }

    [NaughtyAttributes.Button]
    private void SwitchDamage()
    {
        OnDamage(1, null, false);
    }
}
