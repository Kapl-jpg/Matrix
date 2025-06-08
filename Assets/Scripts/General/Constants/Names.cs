namespace General.Constants
{
    public struct Names
    {
        public const string CLICK = "Click";
        public const string LOAD_NOTEBOOK_SCENE = "LoadNotebookScene";
        public const string LOAD_HOUSE_SCENE = "LoadHouseScene";
        
        public struct Map
        {
            public const string ENABLE_POINT = "EnablePoint";
            public const string DISABLE_POINT = "DisablePoint";
            public const string CLEAR_MAP = "ClearMap";
            public const string REBUILD_MAP = "RebuildMap";
            public const string SELECT_POINT = "SelectPoint";
            public const string SET_POINT_PARAMETERS = "SetPointParameters";
            public const string ADD_POINT = "AddPoint";
            public const string WAIT_NEXT_DAY = "WaitNextDay";
            public const string MARK_NEW_DAY = "MarkNewDay";
            public const string SHOW_LOCK_TEXT = "ShowLockText";
            public const string HIDE_LOCK_TEXT = "HideLockText";
        }
        
        public struct House
        {
            public const string SHOW_ITEM_DESCRIPTION = "ShowItemDescription";
            public const string HIDE_ITEM_DESCRIPTION = "HideItemDescription";
        }
        
        public struct Notebook
        {
            public const string SELECT_NOTEBOOK_ENTRY = "SelectNotebookEntry";
            public const string SELECT_MERGE_ENTRY = "SelectMergeEntry";
            public const string LOCK_ENTRY = "LockEntry";
        }
        
        public struct Scenes
        {
            public const string MAIN_MENU = "MainMenuScene";
            public const string MAP = "MapScene";
            public const string HOUSE = "HouseScene";
            public const string NOTEBOOK = "NotebookScene";
        }
    }
}