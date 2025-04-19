using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

public class HealthBase : MonoBehaviour, IDamageable
{

    public UIUpdate uiUpdate;

    public float StarLife = 10;
    public float _currentLife;
    public bool _isDead = false;
    public float timeDestroyed = 0.01f;
    public FlashColor _flashcolor;
    public bool isPlayer = false;

    public float damageMultiply = 1;

    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;

    private bool Referencetime = true;


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
        UpdateUI();
    }


   /* public void OnDamage()
    {

    }*/

    public void OnDamage(float damage, Transform pos, bool recoil, bool constant)
    {        
        if (_isDead) return;
        if(damage > 0)
        onDamage?.Invoke(this);
        if (constant)
        {
            _currentLife -= damage * damageMultiply;
            if (isPlayer) { EffectManager.Instance.Shake();  }
            UpdateUI();
        }
        else
        {
            if (Referencetime)
            {
                if ((isPlayer)&&(damage>0)) { EffectManager.Instance.Shake(); }
                _currentLife -= damage * damageMultiply; ;
                Referencetime = false;
                Invoke(nameof(OperaçãodeTempo), _flashcolor.duration + 0.1f);
                UpdateUI();
            }
            if (_currentLife >= StarLife)
            {
                _currentLife = StarLife;
            }
        }
        if (!_isDead)
        {

            if (_currentLife <= 0)
            {
                //kill();
                _isDead = true;
                onKill?.Invoke(this);
            }
        }
    }


    public void OperaçãodeTempo()
    {
        Referencetime = true;
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
        Destroy(gameObject, 4f);
    }

    [NaughtyAttributes.Button]
    private void SwitchDamage()
    {
        OnDamage(1, null, false, true);
    }

    void IDamageable.Damage(float damage)
    {
        OnDamage(damage, null, false, true);
    }

    void IDamageable.Damage(float damage, Transform pos)
    {
        OnDamage(damage, null, false, true);
    }

    void IDamageable.Damage(float damage, Transform pos, bool recoil, bool constant)
    {
        OnDamage(damage, null, false, constant);
    }

    private void UpdateUI()
    {
        if (uiUpdate)
        {
            uiUpdate.UpdateValue((float)_currentLife / StarLife);
        }
    }


    public void ChangeStrong(float DamageM, float duration)
    {
        StartCoroutine(ChangeStrongCourotine(DamageM, duration));
    }

    IEnumerator ChangeStrongCourotine(float DamageM, float duration)
    {
        damageMultiply = DamageM;
        yield return new WaitForSeconds(duration);
        damageMultiply = 1;
    }
}
