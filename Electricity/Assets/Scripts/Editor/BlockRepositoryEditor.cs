using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlockRepository)), CanEditMultipleObjects]
public class BlockRepositoryEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        BlockRepository repository = (BlockRepository)target;

        if (GUILayout.Button("Update Block Data")) {
            repository.UpdateBlockData();
        }
    }
}