using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class MapDiscription : MonoBehaviour
    {
        [SerializeField] private TMP_Text discriptionText;

        private void Start()
        {
            PointSelector.activate += SetDiscription;
            PointSelector.deactivate += HideDiscription;
        }

        private void OnDestroy()
        {
            PointSelector.activate -= SetDiscription;
            PointSelector.deactivate -= HideDiscription;
        }

        public void SetDiscription(PointData pointData)
        {
            var discription = pointData.discription;
            discriptionText.gameObject.SetActive(true);
            discriptionText.text = discription;
        }

        public void HideDiscription()
        {
            discriptionText.text = string.Empty;
            discriptionText.gameObject.SetActive(false);
        }
    }
}