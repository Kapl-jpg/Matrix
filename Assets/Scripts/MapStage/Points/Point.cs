using Names;

namespace MapStage.Points
{
    public class Point : Subscriber
    {
        private PointData _data;

        [Event(true,EventNames.Map.SetPointParameters)]
        private void SetPointParameters(PointData data)
        {
            _data = data;
        }

        public void ChosePoint()
        {
            EventManager.Publish(EventNames.Map.SelectPoint, _data);
        }
    }
}