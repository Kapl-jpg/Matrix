using System;
using System.Collections.Generic;
using Enums;
using Home.Items;
using Names;
using TMPro;
using UnityEngine;

namespace Home
{
    public class DetectItemDisplay : Subscriber
    {
        [SerializeField] private GameObject descriptionPanel;
        [SerializeField] private TMP_Text descriptionText;
        
        [SerializeField] private List<ItemDescription> itemDescriptions;
        
        [Event(EventNames.ShowItemDescription)]
        private void ShowItemDescription(ItemType itemType)
        {
            descriptionPanel.SetActive(true);
            descriptionText.text = DescriptionByType(itemType);
        }
        
        [Event(EventNames.HideItemDescription)]
        private void HideItemDescription()
        {
            descriptionPanel.SetActive(false);
            descriptionText.text = string.Empty;
        }
        
        private string DescriptionByType(ItemType itemType)
        {
            return itemDescriptions.Find(x => x.itemType == itemType).description;
        }
    }
}