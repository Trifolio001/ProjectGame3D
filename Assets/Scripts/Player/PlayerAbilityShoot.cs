using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Items;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIGunUpdate> uiUpdate;


    [Header("Guns")]


    //public List<SlotsGuns> ListSlotsGuns;
    public GameObject guns;
    public int bullets;

    public Transform gunPosition;
    private GunBase _currentGun;
    private LifePack _lifePack;
    private GameObject ObjectBase = null;
    private ItemType refItem;


    protected override void Init()
    {
        ObjectBase = null;
        base.Init();

        inputs.GamePlay.Action1.performed += ctx => StartShoot();
        inputs.GamePlay.Action1.canceled += ctx => CancelShoot();

        //inputs.GamePlay.Slot1.performed += ctx => SlotSelect(1);
        //inputs.GamePlay.Slot2.performed += ctx => SlotSelect(2);
        //inputs.GamePlay.Slot3.performed += ctx => SlotSelect(3);
    }


    public void SlotSelect(ItemSlots items)
    {
        if (ObjectBase != null)
        {
            Item_manager.Instance.UpdateBullet(bullets ,refItem);
            if(_currentGun != null)
                Destroy(_currentGun.gameObject);
            if (_lifePack != null)
                Destroy(_lifePack.gameObject);
            ObjectBase = null; 
            _currentGun = null;
        }
        if (items.refObjects != null)
        {
            refItem = items.itemTipe;
            ObjectBase = items.refObjects;
            bullets = items.bullet;
            CreateGun(bullets);
        }
    }

    private void CreateGun(int bullet)
    {
        Instantiate(ObjectBase, gunPosition);
        foreach (var child in gameObject.GetComponentsInChildren<GunBase>())
        {
            _currentGun = child;
            _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
            _currentGun.StartGun(bullet, this);
        }
        foreach (var child in gameObject.GetComponentsInChildren<LifePack>())
        {
            _lifePack = child;
            _lifePack.transform.localPosition = _lifePack.transform.localEulerAngles = Vector3.zero;            
        }
    }


    private void StartShoot()
    {
        if(_currentGun != null)
        {
            _currentGun.startShoot();
        }
        if (_lifePack != null)
        {
            RecoverLife();
        }
    }

    private void CancelShoot()
    {
        if (_currentGun != null)
        {
            _currentGun.stopShoot();
        }
    }

    private void RecoverLife()
    {
        Item_manager.Instance.RemoveByType(ItemType.LIFE_PACK);
        player.healthBase.ResetLife();
        VFXLifePack();
    }

    /*[System.Serializable]
    public class SlotsGuns
    {
        public GunBase guns;
        public int bullets;
    }*/

    public void VFXLifePack()
    {
        VFXManeger.Instance.PlayVFXByTipe(VFXManeger.VFXType.HEARTPLAYER, transform.position, transform.rotation);
    }

}
