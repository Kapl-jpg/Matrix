using General.Constants;
using MapStage.Points;
using TMPro;
using UnityEngine;

namespace MapStage.Map
{
    public class MapDescription : Subscriber
    {
        [SerializeField] private GameObject description;
        [SerializeField] private new GameObject name;
        [SerializeField] private GameObject level;
        
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;

        [Event(Names.Map.ENABLE_POINT)]
        private void ShowDescription(PointData pointData)
        {
            descriptionText.text = pointData.description;
            nameText.text = $"Имя: {pointData.Name}";
            levelText.text = $"Уровень: {pointData.Level}";
            
            description.SetActive(true);
            name.SetActive(true);
            level.SetActive(true);
        }

        [Event(Names.Map.DISABLE_POINT)]
        private void HideDescription()
        {
            description.SetActive(false);
            name.SetActive(false);
            level.SetActive(false);
        }
    }
}