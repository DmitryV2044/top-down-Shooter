using UnityEditor;
using UnityEngine;

public class SpawnpointMenuItem : EditorObjectCreator
{
    private const string InitalPath = "GameObject/Spawnpoints/";

    [MenuItem(InitalPath + "Ninja Spawnpoint", priority = 2)]
    private static void CreateNinjaSpawnPoint(MenuCommand menuCommand) => CreateCustomGameObject<NinjaSpawnpoint>("Ninja Spawnpoint", menuCommand);

}
