using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DataWrapper {
    public Vector3[] infos;
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

        string json = JsonUtility.ToJson(mData, true); // Convert MapData to Json

        Debug.Log(json);
        
        File.WriteAllText(fileName, json);

        Debug.Log("Finish - Save Map Data");
    }
}
