using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map)), CanEditMultipleObjects]
public class MapManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Map map = (Map)target;
        if (GUILayout.Button("Set MapData"))
        {
            map.SetMapData();
        }
        if (GUILayout.Button("Save MapData"))
        {
            map.SaveMapData();
        }
        if (GUILayout.Button("Load MapData"))
        {
            map.LoadMapData();
        }
        if (GUILayout.Button("Reset MapData"))
        {
            map.ResetMapData();
        }

        DrawDefaultInspector();
    }
}