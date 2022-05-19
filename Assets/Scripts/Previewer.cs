using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Previewer : EditorScript
{
    private NPC _spawnedInstance;

    public void CreatePreview<T>() where T : NPC
    {   
        NpcConfig<T>[] configs = Resources.LoadAll<NpcConfig<T>>("Prefabs/Enemies/Configs");
        _spawnedInstance = GetComponentInChildren<T>();

        if (_spawnedInstance == null)
            _spawnedInstance = Instantiate(configs[0].Prefab, transform);
    }

    public void DeletePreview<T>() where T : NPC
    {
        if (_spawnedInstance == null)
            _spawnedInstance = GetComponentInChildren<T>();

        if (_spawnedInstance != null)
            DestroyImmediate(_spawnedInstance.gameObject);

        DestroyImmediate(this);
    }
}
