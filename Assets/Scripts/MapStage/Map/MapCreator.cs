using System.Collections.Generic;
using System.Linq;
using General.Constants;
using General.Save;
using MapStage.Points;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapStage.Map
{
    public class MapCreator : Subscriber
    {
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

        private List<PointData> _dataByPoint = new();

        private void Start()
        {
            GetScreenParameters();
            InstancePoints();
        }

        private void GetScreenParameters()
        {
            pointPrefab.TryGetComponent(out RectTransform prefabRect);
            _pointWidth = prefabRect.rect.width;
            _pointHeight = prefabRect.rect.height;

            _leftScreenPoint = -(Screen.width / 2);
            _rightScreenPoint = Screen.width / 2;

            _bottomScreenPoint = -(Screen.height / 2);
            _upperScreenPoint = Screen.height / 2;
        }

        [Event(Names.Map.REBUILD_MAP)]
        private void InstancePoints()
        {
            _dataByPoint = GenerateList();

            foreach (var data in _dataByPoint)
            {
                var point = Instantiate(pointPrefab, map.transform, false);
                
                point.TryGetComponent(out RectTransform pointRect);
                pointRect.anchoredPosition = new Vector2(CalculatePointPosition().x, CalculatePointPosition().y);
                SetCorners(pointRect);

                EventManager.Publish($"{point.GetInstanceID()}.{Names.Map.SET_POINT_PARAMETERS}", data);
                EventManager.Publish(Names.Map.ADD_POINT, (data, point));
            }
        }

        private List<PointData> GenerateList()
        {
            var list = new List<PointData>(points);
            
            System.Random random = new System.Random();
            list.OrderBy(x => random.Next()).ToList();
            
            var housesCount = Random.Range(Constants.MIN_POINTS, Constants.MAX_POINTS+1);
            for (var i = 0; i < Constants.MAX_POINTS - housesCount; i++)
            {
                list.RemoveAt(i);
            }
            
            SetLock(list);
            
            var shuffledNames = names.OrderBy(x => random.Next()).ToList();
            names = shuffledNames;
            return PointsWithData(list);
        }

        private List<PointData> PointsWithData(List<PointData> shuffledPoints)
        {
            for (int i = 0; i < shuffledPoints.Count; i++)
            {
                var shuffledPoint = shuffledPoints[i];
                shuffledPoint.Name = names[i];
                shuffledPoint.Level = Random.Range(1, 1 + SaveNumberMatches.GetNumber(names[i]));
                shuffledPoints[i] = shuffledPoint;
            }
            
            return shuffledPoints;
        }

        private void SetLock(List<PointData> list)
        {
            var lockedIndex = Random.Range(0, list.Count);
            var temp = list[lockedIndex];
            temp.IsLocked = true;
            list[lockedIndex] = temp;
        }

        private Vector3 CalculatePointPosition()
        {
            var halfPointWidth = _pointWidth / 2;
            var halfPointHeight = _pointHeight / 2;

            var x = Random.Range(_leftScreenPoint + horizontalMargin + halfPointWidth,
                _rightScreenPoint - horizontalMargin - halfPointWidth);
            var y = Random.Range(_bottomScreenPoint + verticalMargin + halfPointHeight,
                _upperScreenPoint - verticalMargin - halfPointHeight);

            return new Vector3(x, y, 0);
        }

        private void SetCorners(RectTransform rt)
        {
            var parent = rt.parent as RectTransform;
            
            if (!parent) return;

            var newAnchorMin = new Vector2(
                rt.anchorMin.x + rt.offsetMin.x / parent.rect.width,
                rt.anchorMin.y + rt.offsetMin.y / parent.rect.height
            );
            var newAnchorMax = new Vector2(
                rt.anchorMax.x + rt.offsetMax.x / parent.rect.width,
                rt.anchorMax.y + rt.offsetMax.y / parent.rect.height
            );

            rt.anchorMin = newAnchorMin;
            rt.anchorMax = newAnchorMax;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }
    }
}