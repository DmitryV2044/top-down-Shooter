using UnityEngine;
using UnityEditor;

public class NpcConfig<T> : ScriptableObject where T : NPC
{
    [Header("Npc Config")]
    public T Prefab;

    [Range(1f, 30f)]
    public float WalkSpeed = 1;

    [Header("Detectors")]
    public bool RadiusDetector;

    [DrawIf("RadiusDetector", true, ComparisonType.Equals, DisablingType.DontDraw)]
    [Range(1, 100)] public float DetectionRadius = 1;

    [Header("Not Implemented Yet")]
    [ReadOnly] public bool _soundDetector;
}