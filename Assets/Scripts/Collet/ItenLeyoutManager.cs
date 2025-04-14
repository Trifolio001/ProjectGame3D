using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class ItenLeyoutManager : MonoBehaviour
    {
        public ItensLayout prefabLeyout;
        public Transform container;

        public List<ItensLayout> itenLayout;
        public Sprite Select;
        public Sprite NotSelect;
        //private int refitemSelect;

        private void Start()
        {
            CreateItens(); 
            CallSelectSlot(0);
        }

        public void CallSelectSlot(int num)
        {
            itenLayout[0].UpdateUISelect(NotSelect);
            itenLayout[1].UpdateUISelect(NotSelect);
            itenLayout[2].UpdateUISelect(NotSelect); 
            itenLayout[num].UpdateUISelect(Select);
        }

        private void CreateItens()
        {
            int slot = 0;
            foreach(var setup in Item_manager.Instance.itemInSlots)
            {
                var item = Instantiate(prefabLeyout, container);
                item.Load(Item_manager.Instance.GetItemByType(ItemType.NULL, slot));
                itenLayout.Add(item);
                slot++;
            }
        }
    } 
}
