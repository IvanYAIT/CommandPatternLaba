using UnityEngine;

namespace Command
{
    public interface ICommand
    {
        void Invoke(Vector2 position);
        void Undo();
    }
}