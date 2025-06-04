namespace General.Save
{
    public static class SavePointName
    {
        private static string _pointName = "Антон";
        public static string GetName => _pointName;
        
        public static void SetName(string name)
        {
            _pointName = name;
        }
    }
}