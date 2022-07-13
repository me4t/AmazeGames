using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LootData", menuName = "Static Data/LootData")]
    public class LootStaticData : ScriptableObject
    {
        public LootSpawnId lootSpawnId;
        public AssetReferenceGameObject PrefabReference;
    }
}