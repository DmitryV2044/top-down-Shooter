using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcFactory<T,C> : IFactory<T> where T : NPC where C : NpcConfig<T>
{
    protected C _config;
    protected Vector3 _spawnPosition;

    public NpcFactory(C config, Vector3 spawnPosition)
    {
        _config = config;
        _spawnPosition = spawnPosition;
    }

    public abstract T GetCreated();
}
