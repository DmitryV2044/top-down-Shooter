using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NinjaFactory : NpcFactory<Ninja, NpcConfig<Ninja>>
{
    private Player _target;

    public NinjaFactory(Player target, NpcConfig<Ninja> config, Vector3 spawnPosition) : base(config, spawnPosition) =>_target = target;

    public override Ninja GetCreated()
    {
        Ninja instance = Object.Instantiate(_config.Prefab);
        instance.WalkSpeed = _config.WalkSpeed;
        instance.Agent = instance.gameObject.AddComponent<NavMeshAgent>();
        if (_config.RadiusDetector) instance.EnableRadiusReaction(_target.transform, _config.DetectionRadius);
        return instance;
    }
}
