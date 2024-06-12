using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonSerialize
{
    public static void SaveMapDataToJson(Map map) {
        string fileName = Path.Combine(Application.dataPath + "/MapData/mapData_Level1.json");

        // file already exist
        if (File.Exists(fileName)) {
            File.Delete(fileName); // delete existing file
        }
        
        string json = JsonConvert.SerializeObject(map); // Convert MapData to Json


        Debug.Log(json);

        File.WriteAllText(fileName, json);

        Debug.Log("Finish - Save Map Data");
    }
}
