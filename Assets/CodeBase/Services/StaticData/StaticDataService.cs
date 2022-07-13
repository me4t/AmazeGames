using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string SpawnerDataPath = "Static Data/Spawners";
        private const string LootDataPath = "Static Data/Loot";
        private const string LevelsDataPath = "Static Data/Levels";

        private Dictionary<LootSpawnId, LootStaticData> _loot;
        private Dictionary<LootSpawnId, SpawnerStaticData> _spawners;
        private Dictionary<string, LevelStaticData> _levels;


        public void Load()
        {
            _loot = Resources
                .LoadAll<LootStaticData>(LootDataPath)
                .ToDictionary(x => x.lootSpawnId, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
            _spawners = Resources
                .LoadAll<SpawnerStaticData>(SpawnerDataPath)
                .ToDictionary(x => x.lootSpawnId, x => x);
        }

        public SpawnerStaticData ForSpawners(LootSpawnId typeId) =>
            _spawners.TryGetValue(typeId, out SpawnerStaticData staticData)
                ? staticData
                : null;

        public LootStaticData ForLoot(LootSpawnId typeId) =>
            _loot.TryGetValue(typeId, out LootStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}