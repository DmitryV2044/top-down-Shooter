using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUpdater : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMesh;

    private void Awake() => _navMesh = GetComponent<NavMeshSurface>();

    private void OnEnable() => UpdateService.OnTick += Rebake;

    private void Rebake() { } //=> _navMesh.BuildNavMesh();

    private void OnDisable() => UpdateService.OnTick -= Rebake;
}
