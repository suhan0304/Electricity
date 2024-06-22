using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData)), CanEditMultipleObjects]
public class LevelDataEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        LevelData levelData = (LevelData)target;
        if (GUILayout.Button("Update Levels")) {
            levelData.UpdateLevels();
        }
    }
}