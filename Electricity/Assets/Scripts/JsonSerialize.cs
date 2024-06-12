using UnityEngine;
using System.IO;

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

        File.WriteAllText(fileName, json);
    }
}
