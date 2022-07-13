using CodeBase.StaticData;

namespace CodeBase.Services.StaticData
{
  public interface IStaticDataService : IService
  {
    void Load();
    SpawnerStaticData ForSpawners(LootSpawnId typeId);
    LevelStaticData ForLevel(string sceneKey);
    LootStaticData ForLoot(LootSpawnId typeId);
  }
}