using System;
using UnityEngine;

public sealed class UpdateService : MonoBehaviour
{
    [Header("NPC tick rate")]
    [Range(1,60)] public int TickRate = 60;
    private static int _tick;
    private static int _frame;

    public static int CurrentTick => _tick;

    public static Action OnUpdate;
    public static Action OnFixedUpdate;
    public static Action OnLateUpdate;
    public static Action OnTick;

    private void Update() => OnUpdate?.Invoke();

    private void FixedUpdate() {
        OnFixedUpdate?.Invoke();
        _frame++;
        if (60/TickRate == _frame)
        {
            Tick();
            Debug.Log("TICK");
            _tick++;
            _frame = 0;
        }
    }

    private void LateUpdate() => OnLateUpdate?.Invoke();

    private void Tick() => OnTick?.Invoke();

}