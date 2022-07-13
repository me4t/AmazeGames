using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public static class Utils
    {
        public static bool IsHero(Collider collider, out LootCollector heroMove) =>
            collider.gameObject.TryGetComponent(out heroMove);
    }
}