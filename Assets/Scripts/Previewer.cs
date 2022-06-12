using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Previewer : EditorScript
{
    private NPC _spawnedInstance;
    [HideInInspector] public float DetectionRadius;

    public void CreatePreview<T>(NpcConfig<T> config) where T : NPC
    {   
        _spawnedInstance = GetComponentInChildren<T>();

        if (_spawnedInstance == null)
        {
            _spawnedInstance = Instantiate(config.Prefab, transform);
            _spawnedInstance.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        DetectionRadius = config.DetectionRadius;
    }

    public void DeletePreview<T>() where T : NPC
    {
        if (_spawnedInstance == null)
            _spawnedInstance = GetComponentInChildren<T>();

        if (_spawnedInstance != null)
            Undo.DestroyObjectImmediate(_spawnedInstance.gameObject);

        Undo.DestroyObjectImmediate(this);
    }

    private void OnDrawGizmosSelected()
    {
        if (_spawnedInstance == null) return;
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }

}

