using Enums;
using General.Constants;
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
            nameText.text = GetName();
            placeText.text = GetPlaceName();
            eventText.text = GetEventName();
            dayText.text = _entryData.Day.ToString();
        }

        public void SelectEntry()
        {
            EventManager.Publish(Names.Notebook.SELECT_NOTEBOOK_ENTRY,_entryData);
        }

        public void MergeEntry()
        {
            EventManager.Publish(Names.Notebook.SELECT_MERGE_ENTRY, _entryData);
        }

        private string GetName() => _entryData.UnknownField == NotebookFieldType.Name ? "???" : _entryData.Name;
        private string GetPlaceName() => _entryData.UnknownField == NotebookFieldType.Place ? "???" : _entryData.Place;
        private string GetEventName() => _entryData.UnknownField == NotebookFieldType.EventName ? "???" : _entryData.EventName;
        
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