using System.Collections;
using UnityEditor;
using UnityEngine;

public class NpcSpawnpoint<T> : EditorScript where T : NPC
{
    private Previewer _previewer;
    [SerializeField] private bool _preview;

    private void Awake()
    {
        if (Application.isPlaying)
           if (_preview) GetComponent<Previewer>().DeletePreview<T>();
    }


    private void Update()
    {
        if (Application.isPlaying) return;

        if (_previewer == null && _preview) {
            _previewer = GetComponent<Previewer>();
            if (_previewer == null) _previewer = Undo.AddComponent(gameObject, typeof(Previewer)) as Previewer;
            _previewer.CreatePreview<T>();
        }

        else if (_previewer != null && !_preview) _previewer.DeletePreview<T>();
    }


    public void Spawn(NpcFactory<T,NpcConfig<T>> factory)
    {
        T instance = factory.GetCreated();
        instance.transform.SetPositionAndRotation(transform.position, transform.rotation);
        Destroy(this);
    }

}
