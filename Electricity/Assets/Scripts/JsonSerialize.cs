using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class JsonSerialize
{
    public static void SaveMapDataToJson(MapData mapData) {
        string fileName = Path.Combine(Application.dataPath + "/MapData/mapData_Level1.json");

        // file already exist
        if (File.Exists(fileName)) {
            File.Delete(fileName); // delete existing file
        }


    }
}
