using System.Collections;
using UnityEditor;
using UnityEngine;

public class NpcSpawnpoint<T> : EditorScript where T : NPC
{
    private Previewer _previewer;
    [SerializeField] private bool _preview;
    private bool _isPreviewCreated = false;
    private NpcConfig<T> _config;

    private void Awake()
    {
        Undo.undoRedoPerformed += HandleUndoRedo;
    }

    private void Update()
    {
        if (Application.isPlaying) return;

        if (_previewer == null && _preview && _isPreviewCreated == false)
        {
            NpcConfig<T>[] configs = Resources.LoadAll<NpcConfig<T>>("Prefabs/Enemies/Configs");
            _config = configs[0];
            _previewer = GetComponent<Previewer>();
            if (_previewer == null) _previewer = Undo.AddComponent(gameObject, typeof(Previewer)) as Previewer;
            _previewer.CreatePreview(_config);
            _isPreviewCreated = true;
        }

        else if (_previewer != null && !_preview)
        {
            _previewer.DeletePreview<T>();
            _isPreviewCreated = false;
        }

        if (_previewer == null) return;

        _previewer.DetectionRadius = _config.DetectionRadius;
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
        if (_preview) GetComponent<Previewer>().DeletePreview<T>();
        T instance = factory.GetCreated();
        instance.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }

    private void OnDestroy() => Undo.undoRedoPerformed -= HandleUndoRedo;
    
}
