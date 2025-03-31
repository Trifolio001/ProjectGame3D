using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{

    public UIUpdate uiUpdate;

    public int StarLife = 10;
    public int _currentLife;
    public bool _isDead = false;
    public float timeDestroyed = 0.01f;
    public FlashColor _flashcolor;
    public bool isPlayer = false;

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



    public void OnDamage(int damage, Transform pos, bool recoil, bool constant)
    {        
        if (_isDead) return;
        onDamage?.Invoke(this);
        if (constant)
        {
            _currentLife -= damage;
            if (isPlayer) { EffectManager.Instance.Shake();  }
            UpdateUI();
        }
        else
        {
            if (Referencetime)
            {

                if (isPlayer) { EffectManager.Instance.Shake(); }
                _currentLife -= damage;
                Referencetime = false;
                Invoke(nameof(OperaçãodeTempo), _flashcolor.duration + 0.1f);
                UpdateUI();
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

    void IDamageable.Damage(int damage)
    {
        OnDamage(damage, null, false, true);
    }

    void IDamageable.Damage(int damage, Transform pos)
    {
        OnDamage(damage, null, false, true);
    }

    void IDamageable.Damage(int damage, Transform pos, bool recoil, bool constant)
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
}
