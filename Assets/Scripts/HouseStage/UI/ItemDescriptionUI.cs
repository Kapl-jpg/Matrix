using System.Collections.Generic;
using Enums;
using HouseStage.InteractableObjects;
using Names;
using TMPro;
using UnityEngine;

namespace HouseStage.UI
{
    public class ItemDescriptionUI : Subscriber
    {
        [SerializeField] private GameObject descriptionPanel;
        [SerializeField] private TMP_Text descriptionText;
        
        [SerializeField] private List<ItemDescription> itemDescriptions;
        
        [Event(EventNames.House.ShowItemDescription)]
        private void ShowItemDescription(ItemType itemType)
        {
            descriptionPanel.SetActive(true);
            descriptionText.text = DescriptionByType(itemType);
        }
        
        [Event(EventNames.House.HideItemDescription)]
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