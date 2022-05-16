using System;
using UnityEngine;

public sealed class UpdateService : MonoBehaviour
{
    public static Action OnUpdate;
    public static Action OnFixedUpdate;
    public static Action OnLateUpdate;

    private void Update() => OnUpdate?.Invoke();

    private void FixedUpdate() => OnFixedUpdate?.Invoke();

    private void LateUpdate() => OnLateUpdate?.Invoke();
}