using Assets.Scripts.Map;
using TMPro;
using UnityEngine;

namespace Map
{
    public class MapDescription : MonoBehaviour
    {
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;

        private void Start()
        {
            PointSelector.activate += ShowDescription;
            PointSelector.deactivate += HideDescription;
        }

        private void OnDestroy()
        {
            PointSelector.activate -= ShowDescription;
            PointSelector.deactivate -= HideDescription;
        }

        private void ShowDescription(PointData pointData)
        {
            var description = pointData.description;
            nameText.text = $"Имя: {pointData.Name}";
            levelText.text = $"Уровень: {pointData.Level}";
            nameText.gameObject.SetActive(true);
            levelText.gameObject.SetActive(true);
            descriptionText.gameObject.SetActive(true);
            descriptionText.text = description;
        }

        private void HideDescription()
        {
            descriptionText.text = string.Empty;
            nameText.text = string.Empty;
            levelText.text = string.Empty;
            descriptionText.gameObject.SetActive(false);
        }
    }
}