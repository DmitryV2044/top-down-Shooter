using UnityEditor;
using UnityEngine;

public class SpawnpointMenuItem : MonoBehaviour
{
    [MenuItem("GameObject/Spawnpoints/Ninja Spawnpoint", priority = 2)]
    private static void CreateNinjaSpawnPoint(MenuCommand menuCommand) => CreateCustomGameObject<NinjaSpawnpoint>("Ninja Spawnpoint", menuCommand);

    private static void CreateCustomGameObject<T>(string name, MenuCommand menuCommand) where T : MonoBehaviour
    {
        GameObject go = new GameObject(name);
        go.AddComponent<T>();
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
