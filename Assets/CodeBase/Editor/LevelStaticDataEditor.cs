using System.Linq;
using CodeBase.Logic.Spawners;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
  [CustomEditor(typeof(LevelStaticData))]
  public class LevelStaticDataEditor : UnityEditor.Editor
  {
    private const string InitialPointTag = "InitialPoint";
    
    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      LevelStaticData levelData = (LevelStaticData) target;

      if (GUILayout.Button("Collect"))
      {
        levelData.LootSpawners = FindObjectsOfType<SpawnMarker>()
          .Select(x => new EnemySpawnerStaticData(x.lootSpawnId, x.transform.position))
          .ToList();

        levelData.LevelKey = SceneManager.GetActiveScene().name;
        
        levelData.InitialHeroPosition =  GameObject.FindWithTag(InitialPointTag).transform.position;
        
      }
      
      EditorUtility.SetDirty(target);
    }
  }
}