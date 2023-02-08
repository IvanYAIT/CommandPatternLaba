using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class SpawnPrefabCommand : ICommand
    {
        private GameObject _prefab;
        private List<GameObject> _spawnedPrefabs;
        private Vector2 _position;

        public SpawnPrefabCommand(GameObject prefab, Vector2 position)
        {
            _prefab = prefab;
            _spawnedPrefabs = new List<GameObject>();
            _position = position;
        }

        public void Invoke()
        {
            GameObject spawnedPrefab = GameObject.Instantiate(_prefab, _position, Quaternion.identity);
            _spawnedPrefabs.Add(spawnedPrefab);
        }

        public void Invoke(Vector2 position)
        {
            GameObject spawnedPrefab =  GameObject.Instantiate(_prefab, position, Quaternion.identity);
            _spawnedPrefabs.Add(spawnedPrefab);
        }

        public void Undo()
        {
            GameObject deletedPrefab = _spawnedPrefabs[_spawnedPrefabs.Count-1];
            _spawnedPrefabs.RemoveAt(_spawnedPrefabs.Count - 1);
            GameObject.Destroy(deletedPrefab);
        }
            
    }
}