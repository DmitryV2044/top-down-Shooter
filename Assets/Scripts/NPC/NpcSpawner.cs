using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private NinjaConfig _ninjaConfig;

    private NinjaSpawnpoint[] _ninjaSpawnpoints;

    void Start()
    {
        Player player = FindObjectOfType<Player>();

        if(player == null)
        {
            Debug.LogError("There is no active player on the scene!");
            return;
        }

        _ninjaSpawnpoints = FindObjectsOfType<NinjaSpawnpoint>();


        NinjaFactory ninjaFactory = new NinjaFactory(player, _ninjaConfig, Vector3.zero);

        for(int i = 0; i < _ninjaSpawnpoints.Length; i++)
        {
            _ninjaSpawnpoints[i].Spawn(ninjaFactory);
        }
    }

}
