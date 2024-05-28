using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Block))]
public class BlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Block block = (Block)target;
        if (GUILayout.Button("Change Block State to ON"))
        {
            block.ChangeOnState();
        }
    }
}