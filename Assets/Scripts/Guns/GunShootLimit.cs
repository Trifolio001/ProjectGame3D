using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GunShootLimit : GunBase
{
    public List<UIGunUpdate> uiGunUpdate;

    public float maxsshot = 5f;
    public float timetoRechange = 1f;

    private int _currentShots;
    private bool recharging = false;
    private PlayerAbilityShoot playershot;
    private int referenceSlot;


    private void Awake()
    {
        GetAllUIs();
    }

    protected override IEnumerator ShootCoroutine()
    {
        //if (_recharging) yield break;

        while (!recharging)
        {
            if(_currentShots < maxsshot)
            {
                Shoot();
                _currentShots++;
                playershot.ListSlotsGuns[referenceSlot].bullets = _currentShots;
                CheckReCharge(); 
                UpdateUi();
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    }

    private void CheckReCharge()
    {
        if (_currentShots >= maxsshot)
        {
            startRechange();
        }
    }

    public void startRechange()
    {
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        stopShoot();
        recharging = true;
        float time = 0;
        while(time < timetoRechange)
        {
            time += Time.deltaTime;
            uiGunUpdate.ForEach(i => i.UpdateValue(time/timetoRechange));
            yield return new WaitForEndOfFrame();
        }
        _currentShots = 0; 
        playershot.ListSlotsGuns[referenceSlot].bullets = 0;
        recharging = false;
    }

    public override void StartGun(int bullet, PlayerAbilityShoot reference, int posGun)
    {
        _currentShots = bullet;
        playershot = reference;
        referenceSlot = posGun;
        CheckReCharge();
        ShootCoroutine(); 
        UpdateUi();
    }

    private void UpdateUi()
    {
        uiGunUpdate.ForEach(i => i.UpdateValue(maxsshot, _currentShots));
    }

    private void GetAllUIs()
    {
        uiGunUpdate = GameObject.FindObjectsOfType<UIGunUpdate>().ToList();
    }
}
