using UnityEngine;
using UnityEditor;

public class EditorObjectCreator : MonoBehaviour
{
    internal static void CreateCustomGameObject<T>(string name, MenuCommand menuCommand) where T : MonoBehaviour
    {
        GameObject go = new GameObject(name);
        go.AddComponent<T>();
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
