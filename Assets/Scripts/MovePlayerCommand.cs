using UnityEngine;

namespace Command
{
    public class MovePlayerCommand : ICommand
    {
        private Transform _playerTransform;

        public MovePlayerCommand(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void Invoke(Vector2 position)
        {
            _playerTransform.position = position;
        }
    }
}