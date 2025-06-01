using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Map
{
    public class PointSelector : MonoBehaviour
    {
        [SerializeField] private Color activateColor;
        [SerializeField] private Color disabledColor;

        public static event Action<PointData> activate;
        public static event Action deactivate;

        private Dictionary<PointData, Image> _pointByData = new();

        private void Start()
        {
            MapCreater.clearMap += Clear;
        }

        private void OnDestroy()
        {
            MapCreater.clearMap -= Clear;
        }

        private void Clear()
        {
            foreach (var point in _pointByData)
            {
                Destroy(point.Value.gameObject);
            }
            _pointByData.Clear();
        }

        public void AddPoint(PointData pointData, GameObject point)
        {
            point.TryGetComponent(out Image pointImage);
            _pointByData.Add(pointData, pointImage);
        }

        public void Select(PointData pointData)
        {
            ActivateButton(pointData);
        }

        private void ActivateButton(PointData pointData)
        {
            var activeButton = _pointByData[pointData];
            foreach (var button in _pointByData)
            {
                if (button.Value == activeButton)
                {
                    button.Value.color = activateColor;
                    continue;
                }
                button.Value.color = disabledColor;
            }

            activate?.Invoke(pointData);
        }

        public void DisableAllButtons()
        {
            foreach (var button in _pointByData)
            {
                button.Value.color = disabledColor;
            }

            deactivate?.Invoke();
        }
    }
}