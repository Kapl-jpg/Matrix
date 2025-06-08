using System.Collections.Generic;
using General.Constants;
using MapStage.Points;
using UnityEngine;
using UnityEngine.UI;

namespace MapStage.Map
{
    public class MapPointSelector : Subscriber
    {
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        private readonly Dictionary<PointData, Image> _imageByData = new();
 
        [Event(Names.Map.CLEAR_MAP)]
        private void Clear()
        {
            foreach (var image in _imageByData.Values)
            {
                Destroy(image.gameObject);
            }

            _imageByData.Clear();
        }

        [Event(Names.Map.ADD_POINT)]
        private void AddPoint((PointData pointData, GameObject point) parameters)
        {
            parameters.point.TryGetComponent(out Image pointImage);
            _imageByData.Add(parameters.pointData, pointImage);
        }

        [Event(Names.Map.SELECT_POINT)]
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
            
            EventManager.Publish(Names.Map.ENABLE_POINT, pointData);
        }

        public void DisableAllMarkers()
        {
            foreach (var image in _imageByData.Values)
            {
                image.color = disableColor;
            }
            
            EventManager.Publish(Names.Map.DISABLE_POINT);
        }
    }
}