using System;
using UnityEngine;

namespace CodeBase.StaticData
{
  [Serializable]
  public class EnemySpawnerStaticData
  {
    public LootSpawnId lootSpawnId;
    public Vector3 Position;

    public EnemySpawnerStaticData(LootSpawnId lootSpawnId, Vector3 position)
    {
      this.lootSpawnId = lootSpawnId;
      Position = position;
    }
  }
}