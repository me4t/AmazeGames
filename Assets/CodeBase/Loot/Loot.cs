using CodeBase.Logic.Spawners;
using UnityEngine;

namespace CodeBase.Loot
{
    public class Loot : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private void Awake()
        {
            TriggerObserver.TriggerEnter += Collect;
        }

        private void Collect(Collider collider)
        {
            if (Utils.IsHero(collider, out var heroMove))
            {
                heroMove.CollectLoot(transform);
                TriggerObserver.TriggerEnter -= Collect;
            }
        }
    }
}