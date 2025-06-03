using Assets.Scripts.Map;
using UnityEngine;

namespace Map
{
    public class Point : MonoBehaviour
    {
        private PointData _data;
        private PointSelector _selector;

        public void SetParameters(PointData data, PointSelector selector)
        {
            _data = data;
            _selector = selector;
        }

        public void ChosePoint()
        {
            _selector.Select(_data);
        }
    }
}