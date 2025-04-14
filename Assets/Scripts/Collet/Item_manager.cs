using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ebac.core.Singleton;
using UnityEngine.InputSystem;
using TMPro;

namespace Items
{
    public enum ItemType
    {
        COIN,
        NULL,
        LIFE_PACK,
        GUN1,
        GUN2,
        GUN3
    }

    public class Item_manager : Singleton<Item_manager>
    {

        //public List<Diferencial> itemDiferencialSetup;
        public List<ItemSlots> itemSlot;
        public List<ItemOutSlots> itemOutSlots;
        public List<ItemInSlots> itemInSlots;

        [Header("Guns")]
        //public List<SlotsGuns> ListSlotsGuns;

        public int Slots = 0;
        public ItenLeyoutManager itenLeyoutManager;
        public PlayerControl player;
        public PlayerAbilityShoot playerC;
        protected Inputs inputs;
        private int ContSlots = 0;

        private void Start()
        {
            ContSlots = 0;
            Reset();
            inputs = new Inputs();
            inputs.Enable();

            Init();
        }

        private void Init()
        {
            inputs.GamePlay.Slot1.performed += ctx => SlotSelect(0);
            inputs.GamePlay.Slot2.performed += ctx => SlotSelect(1);
            inputs.GamePlay.Slot3.performed += ctx => SlotSelect(2);
            Slots = 0;
            slotVisualObject(0);
        }

        private void SlotSelect(int n)
        {
            Slots = n;
            slotVisualObject(n);
            itenLeyoutManager.CallSelectSlot(n);
        }

        private void Reset()
        {
            foreach (var i in itemOutSlots)
            {
                i.soValue.value = 0;
            }

            foreach (var i in itemInSlots)
            {
                i.soValue.value = 0;
            }
        }

        public void slotVisualObject(int n)
        {
            ItemSlots a = itemSlot.Find(i => i.itemTipe == itemInSlots[n].itemTipe);
            playerC.SlotSelect(a);
        }

        public ItemInSlots GetItemByType(ItemType itemType, int i)
        {
            return itemInSlots[i];
        }

        public void AddByType(ItemType itemType, int ammount = 1)
        {
            if (ammount <= 0) return;
            //int a = 0;
            var veritemSlot = itemOutSlots.Find(i => i.itemTipe == itemType);
            if (veritemSlot != null)
            {
                veritemSlot.soValue.value += ammount;
            }
            else
            {
                var veriteminSlot = itemInSlots.Find(i => i.itemTipe == itemType);
                if (veriteminSlot != null)
                {
                    veriteminSlot.soValue.value += ammount;
                }
                else
                {
                    Debug.Log("asfdafa " + Slots + " sdsdagsd " + (itemInSlots[Slots].itemTipe));
                    if (itemInSlots[Slots].itemTipe == ItemType.NULL)
                    {
                        itemInSlots[Slots].itemTipe = itemType;
                        itemInSlots[Slots].icon = itemSlot.Find(i => i.itemTipe == itemType).icon;
                        itemInSlots[Slots].soValue.value += ammount;
                    }
                    else
                    {
                        var verSlotEmpy = itemInSlots.Find(i => i.itemTipe == ItemType.NULL);
                        if (verSlotEmpy != null)
                        {

                            verSlotEmpy.itemTipe = itemType;
                            verSlotEmpy.icon = itemSlot.Find(i => i.itemTipe == itemType).icon;
                            verSlotEmpy.soValue.value += ammount;
                        }
                        else
                        {
                            itemInSlots[Slots].itemTipe = itemType;
                            itemInSlots[Slots].icon = itemSlot.Find(i => i.itemTipe == itemType).icon;
                            itemInSlots[Slots].soValue.value += ammount;
                        }
                    }
                }

                slotVisualObject(Slots);
                //itemInSlots.Find(i => i.itemTipe == itemType).soValue.value += ammount;
            }
        }

        public void RemoveByType(ItemType itemType, int ammount = 1)
        {
            if (ammount <= 0) return;

            var item = itemInSlots.Find(i => i.itemTipe == itemType);
            item.soValue.value -= ammount;

            if (item.soValue.value <= 0)
            {
                item.itemTipe = ItemType.NULL;
                item.soValue.value = 0;
                item.icon = itemSlot.Find(i => i.itemTipe == ItemType.NULL).icon;
            }
            slotVisualObject(Slots);
        }

        private void UpdateUi()
        {
            //UIGameManeger.Instance.UpdateTextCoins(coins.Value.ToString());
        }

        public void UpdateBullet(int bullet, ItemType itemType)
        {
            itemSlot.Find(i => i.itemTipe == itemType).bullet = bullet;
        }

    }

    [System.Serializable]
    public class ItemSlots
    {
        public ItemType itemTipe;
        public Sprite icon;
        public GameObject refObjects;
        public bool NotInslot;
        public int bullet = 0;
    }

    [System.Serializable]
    public class ItemOutSlots
    {
        public ItemType itemTipe;
        public Sprite icon;
        public SOValueCoins soValue;
    }

    [System.Serializable]
    public class ItemInSlots
    {
        public ItemType itemTipe;
        public Sprite icon;
        public SOValueCoins soValue;
    }

}
