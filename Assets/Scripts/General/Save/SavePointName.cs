using System.Collections.Generic;
using UnityEngine;

namespace General.Save
{
    public class SavePointName
    {
        private static string _pointName;
        public static string PointName => _pointName;
        
        public static void SetName(string name)
        {
            _pointName = name;
        }
    }
}