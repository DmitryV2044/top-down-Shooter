using UnityEngine;

public class NpcSpawnpoint<T> : MonoBehaviour where T : NPC
{
    public void Spawn(NpcFactory<T,NpcConfig<T>> factory)
    {
        T instance = factory.GetCreated();
        instance.transform.SetPositionAndRotation(transform.position, transform.rotation);
        Destroy(this);
    }
}
