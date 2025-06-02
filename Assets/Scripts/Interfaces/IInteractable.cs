using Enums;

namespace Interfaces
{
    public interface IInteractable
    {
        ItemType Type { get; set; }
        void Interact();
    }
}