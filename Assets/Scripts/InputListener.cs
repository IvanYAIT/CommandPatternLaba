using UnityEngine;

namespace Command
{
    public class InputListener : MonoBehaviour
    {
        private MovePlayerCommand _movePlayer;
        //private SpawnPrefabCommand _spawnPrefab;
        private Vector3 _mousePosition;
        private CommandInvoker _commandInvoker;
        private GameObject _prefab;

        void Update()
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
                _commandInvoker.Invoke(_movePlayer, _mousePosition);
            else if (Input.GetMouseButtonDown(1))
                _commandInvoker.AddCommandToQueue(new SpawnPrefabCommand(_mousePosition));
            else if (Input.GetMouseButtonDown(2))
                _commandInvoker.Undo();
            else if (Input.GetKeyDown(KeyCode.Return))
                _commandInvoker.InvokeAllIncompletedCommands(_prefab);
        }

        public void Construct(MovePlayerCommand movePlayer, GameObject prefab, CommandInvoker commandInvoker)
        {
            _movePlayer = movePlayer;
            _prefab = prefab;
            //_spawnPrefab = spawnPrefab;
            _commandInvoker = commandInvoker;
        }
    }
}