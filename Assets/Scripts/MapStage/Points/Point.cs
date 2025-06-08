using General.Constants;

namespace MapStage.Points
{
    public class Point : Subscriber
    {
        private PointData _data;

        [Event(true,Names.Map.SET_POINT_PARAMETERS)]
        private void SetPointParameters(PointData data)
        {
            _data = data;
        }

        public void ChosePoint()
        {
            EventManager.Publish(Names.Map.SELECT_POINT, _data);
        }
    }
}