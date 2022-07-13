using System.Collections;
using CodeBase.Infrastructure.Factory;
using CodeBase.Services.Randomizer;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public class BoxSpawner : MonoBehaviour
    {
        public BoxCollider Collider;
        public LootSpawnId LootId;
        public int DelayTime;
        private IRandomService _randomService;
        private IGameFactory _gameFactory;
        private float sizeX;
        private float sizeZ;
        private Vector3 _position;

        public void Construct(GameFactory gameFactory, IRandomService randomService)
        {
            _randomService = randomService;
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _position = transform.position;
            Vector3 size = Collider.size;
            sizeX = size.x;
            sizeZ = size.z;
        }

        private void Start()
        {
            StartCoroutine(SpawnBox());
        }

        private IEnumerator SpawnBox()
        {
            while (true)
            {
                Vector3 position = GetRandomPosition();
                _gameFactory.SpawnLoot(position, LootId, transform);
                yield return new WaitForSeconds(DelayTime);
            }
        }

        private Vector3 GetRandomPosition() =>
            new Vector3(_randomService.Next(_position.x, _position.x + sizeX / 2), 0.5f,
                _randomService.Next(_position.z, _position.z + sizeZ / 2));
    }
}