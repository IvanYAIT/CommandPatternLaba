using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class MovePlayerCommand : ICommand
    {
        private Transform _playerTransform;
        private List<Vector2> _lastPositions;

        public MovePlayerCommand(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            _lastPositions = new List<Vector2>();
        }

        public void Invoke(Vector2 position)
        {
            _lastPositions.Add(_playerTransform.position);
            _playerTransform.position = position;
        }

        public void Undo()
        {
            _playerTransform.position = _lastPositions[_lastPositions.Count - 1];
            _lastPositions.RemoveAt(_lastPositions.Count - 1);
        }
    }
}