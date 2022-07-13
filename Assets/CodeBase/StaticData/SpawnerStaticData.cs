using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Spawner", menuName = "Static Data/SpawnerData")]
    public class SpawnerStaticData : ScriptableObject
    {
        public LootSpawnId lootSpawnId;
        public AssetReferenceGameObject PrefabReference;
    }
}