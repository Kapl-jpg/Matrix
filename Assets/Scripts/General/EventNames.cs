namespace Names
{
    public struct EventNames
    {
        public const string Click = "Click";
        public const string LoadNotebookScene = "LoadNotebookScene";
        public const string LoadHouseScene = "LoadHouseScene";
        
        public struct Map
        {
            public const string EnablePoint = "EnablePoint";
            public const string DisablePoint = "DisablePoint";
            public const string ClearMap = "ClearMap";
            public const string RebuildMap = "RebuildMap";
            public const string SelectPoint = "SelectPoint";
            public const string SetPointParameters = "SetPointParameters";
            public const string AddPoint = "AddPoint";
            public const string WaitNextDay = "WaitNextDay";
            public const string MarkNewDay = "MarkNewDay";
            public const string ShowLockText = "ShowLockText";
            public const string HideLockText = "HideLockText";
        }
        
        public struct House
        {
            public const string ShowItemDescription = "ShowItemDescription";
            public const string HideItemDescription = "HideItemDescription";
        }
        
        public struct Notebook
        {
            public const string SelectNotebookEntry = "SelectNotebookEntry";
            public const string SelectMergeEntry = "SelectMergeEntry";
            public const string LockEntry = "LockEntry";
        }
    }
}