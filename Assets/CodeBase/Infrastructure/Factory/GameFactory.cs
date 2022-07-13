using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Logic.Spawners;
using CodeBase.Services.Randomizer;
using CodeBase.Services.StaticData;
using CodeBase.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IRandomService _randomService;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData, IRandomService randomService)
        {
            _assets = assets;
            _staticData = staticData;
            _randomService = randomService;
        }


        public async void SpawnLoot(Vector3 position, LootSpawnId lootId, Transform parent)
        {
            var lootData = _staticData.ForLoot(lootId);
            GameObject prefab = await _assets.Load<GameObject>(lootData.PrefabReference);

            Object.Instantiate(prefab, position, Quaternion.identity, parent);
        }

        public async Task<GameObject> CreateHero(Vector3 at) =>
            await _assets.Instantiate(AssetAddress.HeroPath, at);


        public async Task<GameObject> CreateHud() => 
            await _assets.Instantiate(path: AssetAddress.HudPath);


        public async Task CreateSpawner(Vector3 at, LootSpawnId lootSpawnId)
        {
            var lootData = _staticData.ForSpawners(lootSpawnId);
            GameObject prefab = await _assets.Load<GameObject>(lootData.PrefabReference);

            GameObject spawnerObj = Object.Instantiate(prefab, at, Quaternion.identity);

            var spawner = spawnerObj.GetComponent<BoxSpawner>();
            spawner.Construct(this, _randomService);
            spawner.LootId = lootSpawnId;
        }


        public void Cleanup() => _assets.Cleanup();
    }
}