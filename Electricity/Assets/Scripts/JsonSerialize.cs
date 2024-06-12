using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;



public class Vector3ListWrapper
{
    public int level;
    public Vector3 startNode;
    public Vector3 endNode;
    public List<Vector3> vector3List;

    public Vector3ListWrapper(Map map, List<Vector3> vector3List)
    {
        level = map.level;
        startNode = map.startNode;
        endNode = map.endNode;
        this.vector3List = vector3List;
    }
}

public class JsonSerialize
{
    public static void SaveMapDataToJson(Map map) {
        string fileName = Path.Combine(Application.dataPath + "/MapData/mapData_Level1.json");

        // file already exist
        if (File.Exists(fileName)) {
            File.Delete(fileName); // delete existing file
        }

        MapData mData = new MapData(map); // set MappData
    
        // Convert MapData to Json
        string json = JsonUtility.ToJson(new Vector3ListWrapper(map, map.nodesPosition), true);

        Debug.LogWarning(json);

        File.WriteAllText(fileName, json);

        Debug.Log("Finish - Save Map Data");
    }

    public static void LoadMapDataToMap(Map map) {
        string fileName = Path.Combine(Application.dataPath + "/MapData/mapData_Level1.json");
        // file already exist
        if (!File.Exists(fileName)) {
            Debug.LogError("No File (MapData)");
            return;
        }

        

    }
}
