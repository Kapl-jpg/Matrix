using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Map;
using General.Save;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField] private PointSelector pointSelector;

        [SerializeField] private GameObject pointPrefab;
        [SerializeField] private GameObject map;

        [SerializeField] private float horizontalMargin;
        [SerializeField] private float verticalMargin;

        [SerializeField] private List<PointData> points;
        [SerializeField] private List<string> names;
        
        private float _pointWidth;
        private float _pointHeight;

        private float _leftScreenPoint;
        private float _rightScreenPoint;
        private float _upperScreenPoint;
        private float _bottomScreenPoint;

        private List<PointData> _dataByPoint;
        private List<string> _namesByPoint;
        public static event Action ClearMap;

        private void Start()
        {
            GetParameters();
            InstancePoints();
        }

        public void Clear()
        {
            ClearMap?.Invoke();
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
            _namesByPoint = new List<string>();
            _namesByPoint = names;
            _dataByPoint = new List<PointData>();
            _dataByPoint = GenerateShuffledList();

            foreach (var data in _dataByPoint)
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
                
                pointComponent.SetParameters(data,pointSelector);
                pointSelector.AddPoint(data, point);
            }
        }

        private List<PointData> GenerateShuffledList()
        {
            points[Random.Range(0, points.Count)].IsLocked = true;
            
            var randomNames = new System.Random();
            names.OrderBy(x => randomNames.Next()).ToList();
            
            System.Random random = new System.Random();
            return PointsWithData(points).OrderBy(x => random.Next()).ToList();
        }

        private List<PointData> PointsWithData(List<PointData> shuffledPoints)
        {
            for (int i = 0; i < shuffledPoints.Count; i++)
            {
                var pointName = names[i];
                shuffledPoints[i].Name = pointName;
                shuffledPoints[i].Level = Random.Range(1, 1 + SaveNumberMatches.GetNumber(pointName));
            }
            return shuffledPoints;
        }

        private Vector3 PointPosition()
        {
            var halfPointWidth = _pointWidth / 2;
            var halfPointHeight = _pointHeight / 2;

            var x = Random.Range(_leftScreenPoint + horizontalMargin + halfPointWidth, _rightScreenPoint - horizontalMargin - halfPointWidth);
            var y = Random.Range(_bottomScreenPoint + verticalMargin + halfPointHeight, _upperScreenPoint - verticalMargin - halfPointHeight);

            return new Vector3(x, y, 0);
        }
    }
}