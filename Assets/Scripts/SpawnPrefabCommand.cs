using UnityEngine;

namespace Command
{
    public class SpawnPrefabCommand : ICommand
    {
        private Transform _prefabTransform;

        public SpawnPrefabCommand(Transform prefabTransform)
        {
            _prefabTransform = prefabTransform;
        }

        public void Invoke(Vector2 position)
        {
            GameObject.Instantiate(_prefabTransform, position, new Quaternion());
        }
    }
}