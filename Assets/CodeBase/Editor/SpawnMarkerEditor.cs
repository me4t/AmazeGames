using CodeBase.Logic.Spawners;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
  [CustomEditor(typeof(SpawnMarker))]
  public class SpawnMarkerEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(SpawnMarker spawner, GizmoType gizmo)
    {
      Gizmos.color = Color.red;
      Gizmos.DrawCube(spawner.transform.position, new Vector3(Constants.LootSpawnerSize,1,Constants.LootSpawnerSize));
    }
  }
}