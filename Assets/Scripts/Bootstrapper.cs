using UnityEngine;

namespace Command
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private int queueLenght;

        private CommandInvoker commandInvoker;
        private MovePlayerCommand movePlayer;
        //private SpawnPrefabCommand spawnPrefab;

        void Start()
        {
            movePlayer = new MovePlayerCommand(playerTransform);
            //spawnPrefab = new SpawnPrefabCommand(prefab);
            commandInvoker = new CommandInvoker(queueLenght);
            //inputListener.Construct(movePlayer, spawnPrefab, commandInvoker);
            inputListener.Construct(movePlayer, prefab, commandInvoker);
        }

    }
}