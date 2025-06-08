using System.Collections.Generic;
using Enums;
using General;
using General.Constants;
using HouseStage.InteractableObjects;
using TMPro;
using UnityEngine;

namespace HouseStage.UI
{
    public class ItemDescriptionUI : Subscriber
    {
        [SerializeField] private GameObject descriptionPanel;
        [SerializeField] private TMP_Text descriptionText;
        
        [SerializeField] private List<ItemDescriptionData> itemDescriptions;
        
        [Event(Names.House.SHOW_ITEM_DESCRIPTION)]
        private void ShowItemDescription(ItemType itemType)
        {
            descriptionPanel.SetActive(true);
            descriptionText.text = DescriptionByType(itemType);
        }
        
        [Event(Names.House.HIDE_ITEM_DESCRIPTION)]
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