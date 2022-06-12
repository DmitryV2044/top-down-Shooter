using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this as T;
    }
}
