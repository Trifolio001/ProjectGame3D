using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Items
{
    public class ItensLayout : MonoBehaviour
    {
        public ItemInSlots _currentSetup;

        public Image IconSelect;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        private float updateVisual = 0;
         

        public void UpdateUISelect(Sprite image)
        {
            IconSelect.sprite = image;
        }

        public void Load(ItemInSlots setup)
        {
            updateVisual = 0;
            _currentSetup = setup;
            UpdateUI();
        }


        private void UpdateUI()
        {
            uiIcon.sprite = _currentSetup.icon;
        }

        private void Update()
        {
            if (updateVisual != _currentSetup.soValue.value)
            {
                UpdateUI();
                uiValue.text = _currentSetup.soValue.value.ToString();
                updateVisual = _currentSetup.soValue.value;
            }
        }
    }
}
