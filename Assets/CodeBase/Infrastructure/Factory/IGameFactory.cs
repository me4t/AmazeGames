using System.Threading.Tasks;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    Task CreateSpawner(Vector3 at, LootSpawnId lootSpawnId);
    Task<GameObject> CreateHero(Vector3 at);
    Task<GameObject> CreateHud();
    void SpawnLoot(Vector3 position, LootSpawnId lootId, Transform boxSpawner);
    void Cleanup();
  }
}