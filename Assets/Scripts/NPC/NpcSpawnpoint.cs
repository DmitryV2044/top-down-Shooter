using System.Collections;
using UnityEditor;
using UnityEngine;

public class NpcSpawnpoint<T> : EditorScript where T : NPC
{
    private Previewer _previewer;
    [SerializeField] private bool _preview;
    private bool _isPreviewCreated = false;

    private void Awake()
    {
        Undo.undoRedoPerformed += HandleUndoRedo;
        if (Application.isPlaying)
           if (_preview) GetComponent<Previewer>().DeletePreview<T>();
    }

    private void Update()
    {
        if (Application.isPlaying) return;

        if (_previewer == null && _preview && _isPreviewCreated == false) {
            _previewer = GetComponent<Previewer>();
            if (_previewer == null) _previewer = Undo.AddComponent(gameObject, typeof(Previewer)) as Previewer;
            _previewer.CreatePreview<T>();
            _isPreviewCreated = true;
        }

        else if (_previewer != null && !_preview) _previewer.DeletePreview<T>();
    }

    private void HandleUndoRedo()
    {
        if (_previewer == null && _preview == true && _isPreviewCreated == true && transform.childCount > 0)
        {
            NPC[] childs = transform.GetComponentsInChildren<NPC>();
            _preview = false;
            _isPreviewCreated = false;
            for (int i = 0; i < transform.childCount; i++) Undo.DestroyObjectImmediate(childs[i].gameObject);
        }
    }

    public void Spawn(NpcFactory<T,NpcConfig<T>> factory)
    {
        T instance = factory.GetCreated();
        instance.transform.SetPositionAndRotation(transform.position, transform.rotation);
        Destroy(this);
    }

    private void OnDestroy() => Undo.undoRedoPerformed -= HandleUndoRedo;
    
}
