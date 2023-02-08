using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class InputListener : MonoBehaviour
    {
        private MovePlayerCommand _movePlayer;
        private SpawnPrefabCommand _spawnPrefab;
        private Vector3 _mousePosition;

        void Update()
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
                CommandInvoker.Invoke(_movePlayer, _mousePosition);
            else if (Input.GetMouseButtonDown(1))
                CommandInvoker.Invoke(_spawnPrefab, _mousePosition);
        }

        public void Construct(MovePlayerCommand movePlayer, SpawnPrefabCommand spawnPrefab)
        {
            _movePlayer = movePlayer;
            _spawnPrefab = spawnPrefab;
        }
    }
}