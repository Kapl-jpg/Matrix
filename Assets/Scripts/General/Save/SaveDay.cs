using UnityEngine;

namespace General.Save
{
    public static class SaveDay
    {
        private static int _currentDay = 1;
        public static int CurrentDay => _currentDay;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            _currentDay = 1;
        }

        public static void SetDay(int day)
        {
            _currentDay = day;
        }
    }
}