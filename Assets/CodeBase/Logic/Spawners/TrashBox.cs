using System.Collections;
using CodeBase.Hero;
using CodeBase.Loot;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    public class TrashBox : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        private Coroutine removeCoroutine;
        private Vector3 position;

        private void Awake()
        {
            position = transform.position;
            TriggerObserver.TriggerEnter += DestroyLoot;
            TriggerObserver.TriggerExit += StopRemoving;
        }

        private void StopRemoving(Collider obj)
        {
            if (removeCoroutine != null) StopCoroutine(removeCoroutine);
        }

        private void OnDestroy()
        {
            TriggerObserver.TriggerExit -= StopRemoving;
            TriggerObserver.TriggerEnter -= DestroyLoot;
        }

        private void DestroyLoot(Collider collider)
        {
            if (Utils.IsHero(collider, out var heroMove)) 
                removeCoroutine = StartCoroutine(RemoveBoxes(heroMove));
        }

        private IEnumerator RemoveBoxes(LootCollector lootCollector)
        {
            while (true)
            {
                lootCollector.RemoveBox(position);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}