using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;
        if (GUILayout.Button("Set MapData"))
        {
            gameManager.SetMapData();
        }
        if (GUILayout.Button("Save MapData"))
        {
            gameManager.SaveMapData();
        }
        if (GUILayout.Button("Load MapData"))
        {
            //gameManager.SetMapData();
        }

        DrawDefaultInspector();
    }
}