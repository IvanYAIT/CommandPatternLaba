using UnityEngine;

namespace Command
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Transform prefabTransform;
        [SerializeField] private Transform playerTransform;

        private MovePlayerCommand movePlayer;
        private SpawnPrefabCommand spawnPrefab;

        void Start()
        {
            movePlayer = new MovePlayerCommand(playerTransform);
            spawnPrefab = new SpawnPrefabCommand(prefabTransform);
            inputListener.Construct(movePlayer, spawnPrefab);
        }

    }
}