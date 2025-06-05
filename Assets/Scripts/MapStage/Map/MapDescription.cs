using MapStage.Points;
using Names;
using TMPro;
using UnityEngine;

namespace MapStage.Map
{
    public class MapDescription : Subscriber
    {
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;

        [Event(EventNames.Map.EnablePoint)]
        private void ShowDescription(PointData pointData)
        {
            nameText.text = $"Имя: {pointData.Name}";
            levelText.text = $"Уровень: {pointData.Level}";
            descriptionText.text = pointData.description;
            
            nameText.gameObject.SetActive(true);
            levelText.gameObject.SetActive(true);
            descriptionText.gameObject.SetActive(true);
        }

        [Event(EventNames.Map.DisablePoint)]
        private void HideDescription()
        {
            nameText.gameObject.SetActive(false);
            levelText.gameObject.SetActive(false);
            descriptionText.gameObject.SetActive(false);
        }
    }
}