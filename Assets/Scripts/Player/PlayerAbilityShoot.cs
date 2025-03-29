using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIGunUpdate> uiUpdate;


    [Header("Guns")]
    public List<SlotsGuns> ListSlotsGuns;

    public Transform gunPosition;
    private GunBase _currentGun;
    private GunBase gunBase = null;


    protected override void Init()
    {
        gunBase = null;
        base.Init();

        inputs.GamePlay.Shoot1.performed += ctx => StartShoot();
        inputs.GamePlay.Shoot1.canceled += ctx => CancelShoot();

        inputs.GamePlay.Gun1.performed += ctx => GunSelect(1);
        inputs.GamePlay.Gun2.performed += ctx => GunSelect(2);
        inputs.GamePlay.Gun3.performed += ctx => GunSelect(3);
    }



    private void GunSelect(int n)
    {
        if (gunBase != null)
        {
            Destroy(_currentGun.gameObject);
        }
        if (ListSlotsGuns[n-1].guns != null)
        {
            gunBase = ListSlotsGuns[n - 1].guns;
            CreateGun(ListSlotsGuns[n - 1].bullets, (n - 1));
        }
    }

    private void CreateGun(int bullet, int num)
    {
        _currentGun = Instantiate(gunBase, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        _currentGun.StartGun(bullet, this, num);
    }


    private void StartShoot()
    {
        if(gunBase != null)
        {
            _currentGun.startShoot();
        }
    }

    private void CancelShoot()
    {
        if (gunBase != null)
        {
            _currentGun.stopShoot();
        }
    }

    [System.Serializable]
    public class SlotsGuns
    {
        public GunBase guns;
        public int bullets;
    }


}
