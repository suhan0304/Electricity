using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;
        if (GUILayout.Button("Nothing"))
        {
        }

        DrawDefaultInspector();
    }
}