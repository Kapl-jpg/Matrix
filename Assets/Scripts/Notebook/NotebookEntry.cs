using System;
using Names;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Notebook
{
    public class NotebookEntry : MonoBehaviour
    {
        [SerializeField] private Button mainButton;
        [SerializeField] private GameObject mergeButton;

        [SerializeField] private Image mainImage;
        [SerializeField] private Color inactiveColor;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color lockedColor;
        
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text placeText;
        [SerializeField] private TMP_Text eventText;
        [SerializeField] private TMP_Text dayText;

        private EntryData _entryData;
        private bool _isLocked;
        
        public void SetData(EntryData entryData)
        {
            _entryData = entryData;
            SetText();
        }

        private void SetText()
        {
            nameText.text = _entryData.name;
            placeText.text = _entryData.place;
            eventText.text = _entryData.@event;
            dayText.text = _entryData.Day.ToString();
        }

        public void ChoseEntry()
        {
            EventManager.Publish(EventNames.ChoseNotebookEntry,_entryData);
        }

        public void MergeEntry()
        {
            EventManager.Publish(EventNames.ChoseMergeEntry, _entryData);
        }
        
        public void ActivateButton()
        {
            if(_isLocked) return;
            
            mainImage.color = activeColor;
            mergeButton.SetActive(false);
        }

        public void DeactivateButton()
        {
            if(_isLocked) return;
            
            mainImage.color = inactiveColor;
            mergeButton.SetActive(true);
        }
        
        public void LockButton()
        {
            mainImage.color = lockedColor;
            mainButton.interactable = false;
            mergeButton.SetActive(false);
            _isLocked = true;
        }
    }
}