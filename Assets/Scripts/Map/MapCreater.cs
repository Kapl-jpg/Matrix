using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Map
{
    public class MapCreater : MonoBehaviour
    {
        [SerializeField] private PointSelector pointSelector;

        [SerializeField] private GameObject pointPrefab;
        [SerializeField] private GameObject map;

        [SerializeField] private float horizontalMargin;
        [SerializeField] private float vertiacalMargin;

        [SerializeField] private List<PointData> datas;

        private float _pointWidth;
        private float _pointHeight;

        private float _leftScreenPoint;
        private float _rightScreenPoint;
        private float _upperScreenPoint;
        private float _bottomScreenPoint;

        private List<PointData> _dataByPoint = new();
        public static event Action clearMap;

        private void Start()
        {
            GetParameters();
            InstancePoints();
        }

        public void Clear()
        {
            clearMap?.Invoke();
        }

        public void Rebuild()
        {
            InstancePoints();
        }


        //Переименовать + разделить
        private void GetParameters()
        {
            pointPrefab.TryGetComponent(out RectTransform prefabRect);
            _pointWidth = prefabRect.rect.width;
            _pointHeight = prefabRect.rect.height;

            _leftScreenPoint = -(Screen.width / 2);
            _rightScreenPoint = Screen.width / 2;

            _bottomScreenPoint = -(Screen.height / 2);
            _upperScreenPoint = Screen.height / 2;
        }

        //Улучшить привязку. Сделать привязку через якоря. Убрать костыли с кнопками
        private void InstancePoints()
        {
            _dataByPoint = GenerateShuffledList();

            for (int i = 0; i < _dataByPoint.Count; i++)
            {
                var randomPoint = Screen.width;

                var point = Instantiate(pointPrefab);
                point.transform.SetParent(map.transform);

                point.TryGetComponent(out RectTransform pointRect);

                pointRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,_pointHeight);
                pointRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,_pointWidth);
                pointRect.localScale = Vector3.one;
                pointRect.SetLocalPositionAndRotation(PointPosition(), Quaternion.identity);

                point.TryGetComponent(out Point pointComponent);
                _dataByPoint[i].level = Random.Range(1, Constants.MAX_LEVEL + 1);

                pointComponent.SetParameters(_dataByPoint[i],pointSelector);
                pointSelector.AddPoint(_dataByPoint[i], point);
            }
        }

        private List<PointData> GenerateShuffledList()
        {
            List<PointData> points = datas;

            for (int i = 0; i < Constants.MAX_POINTS - PointsCount(); i++)
            {
                points.RemoveAt(Random.Range(0, points.Count));
            }

            points[Random.Range(0, points.Count)].isLocked = true;

            System.Random random = new System.Random();
            return points.OrderBy(x => random.Next()).ToList();
        }

        private Vector3 PointPosition()
        {
            var halfPointWidth = _pointWidth / 2;
            var halfPointHeight = _pointHeight / 2;

            var x = Random.Range(_leftScreenPoint + horizontalMargin + halfPointWidth, _rightScreenPoint - horizontalMargin - halfPointWidth);
            var y = Random.Range(_bottomScreenPoint + vertiacalMargin + halfPointHeight, _upperScreenPoint - vertiacalMargin - halfPointHeight);

            return new Vector3(x, y, 0);
        }

        private int PointsCount()
        {
            return Random.Range(Constants.MIN_POINTS, Constants.MAX_POINTS + 1);
        }
    }
}