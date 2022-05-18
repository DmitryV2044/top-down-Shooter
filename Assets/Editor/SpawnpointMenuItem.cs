using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnpointMenuItem : MonoBehaviour
{
    [MenuItem("GameObject/Spawnpoints/Ninja Spawnpoint", priority = 2)]
    private static void CreateNinjaSpawnPoint()
    {
        CreateSpawnpoint("NinjaSpawnpoint");
    }

    private static void CreateSpawnpoint(string name)
    {
        Object spawnpoint = Instantiate(Resources.Load($"Spawnpoints/{name}"));
        spawnpoint.name = name;
    }
}
