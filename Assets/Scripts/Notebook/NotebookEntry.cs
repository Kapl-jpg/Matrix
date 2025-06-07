using General;
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
            nameText.text = _entryData.Name;
            placeText.text = _entryData.Place;
            eventText.text = _entryData.EventName;
            dayText.text = _entryData.Day.ToString();
        }

        public void SelectEntry()
        {
            EventManager.Publish(EventNames.Notebook.SelectNotebookEntry,_entryData);
        }

        public void MergeEntry()
        {
            EventManager.Publish(EventNames.Notebook.SelectMergeEntry, _entryData);
        }
        
        public void ActivateEntry()
        {
            mainImage.color = activeColor;
            mergeButton.SetActive(false);
        }

        public void DeactivateEntry()
        {
            if(_isLocked) return;
            
            mainImage.color = inactiveColor;
            mergeButton.SetActive(true);
        }
        
        public void LockEntry()
        {
            mainImage.color = lockedColor;
            mergeButton.SetActive(false);
            _isLocked = true;
        }

        public void DeactivateFullEntry()
        {
            mainImage.color = inactiveColor;
            mergeButton.SetActive(false);
        }
    }
}