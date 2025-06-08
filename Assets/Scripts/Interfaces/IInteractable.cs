using Enums;

namespace Interfaces
{
    public interface IInteractable
    {
        ItemType Type { get; }
        void Interact();
    }
}