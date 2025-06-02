using System;
using Enums;

namespace Home.Items
{
    [Serializable]
    public class ItemDescription
    {
        public ItemType itemType;
        public string description;
    }
}