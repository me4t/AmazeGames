using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Hero
{
    public class LootCollector : MonoBehaviour
    {
        public Transform LootHolder;
        private const float JumpPower = 1.5f;
        private const float Duration = 0.25f;

        private Stack<Transform> lootStack = new Stack<Transform>();


        public void CollectLoot(Transform loot)
        {
            Vector3 interval = new Vector3(0, lootStack.Count * Constants.BoxSize);

            TossUpLoot(loot, interval + LootHolder.position)
                .OnComplete(() => SetInBag(loot, interval));
            lootStack.Push(loot);
        }

        private void SetInBag(Transform loot, Vector3 interval)
        {
            loot.SetParent(LootHolder, true);
            loot.localPosition = interval;
            loot.rotation = LootHolder.rotation;
        }

        public void RemoveBox(Vector3 tossPosition)
        {
            if (lootStack.Count <=  0) return;

            Transform loot = lootStack.Pop();
            TossUpLoot(loot, tossPosition)
                .OnComplete(() => Destroy(loot.gameObject));
        }

        private Sequence TossUpLoot(Transform itemCtr, Vector3 placeForToss) => 
            itemCtr.DOJump(placeForToss  , JumpPower, 1, Duration);
    }
}