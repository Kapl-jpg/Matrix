using System.Collections.Generic;
using General;
using MapStage.Points;
using Names;
using UnityEngine;
using UnityEngine.UI;

namespace MapStage.Map
{
    public class MapPointSelector : Subscriber
    {
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        private readonly Dictionary<PointData, Image> _imageByData = new();
 
        [Event(EventNames.Map.ClearMap)]
        private void Clear()
        {
            foreach (var image in _imageByData.Values)
            {
                Destroy(image.gameObject);
            }

            _imageByData.Clear();
        }

        [Event(EventNames.Map.AddPoint)]
        private void AddPoint((PointData pointData, GameObject point) parameters)
        {
            parameters.point.TryGetComponent(out Image pointImage);
            _imageByData.Add(parameters.pointData, pointImage);
        }

        [Event(EventNames.Map.SelectPoint)]
        private void ActivateButton(PointData pointData)
        {
            foreach (var image in _imageByData.Values)
            {
                if (image == _imageByData[pointData])
                {
                    image.color = enableColor;
                    continue;
                }

                image.color = disableColor;
            }
            
            EventManager.Publish(EventNames.Map.EnablePoint, pointData);
        }

        public void DisableAllMarkers()
        {
            foreach (var image in _imageByData.Values)
            {
                image.color = disableColor;
            }
            
            EventManager.Publish(EventNames.Map.DisablePoint);
        }
    }
}