using UnityEngine;
using System.Collections.Generic;
using System;

public class Map : MonoBehaviour
{    
    public GameObject fieldObject;

    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position

    public Dictionary<int, int> blockInventory; // blockInventrory<BlockType(num), blockCounts> {1: 2, 3: 4})

    public List<Vector3> nodesPosition; // all Nodes Position

    public MapGenerator mapGenerator;

    public void SetMapData() {
        nodesPosition = new List<Vector3>();
        if (fieldObject != null) {
            foreach (Transform child in fieldObject.transform) {
                if(child.CompareTag(Tags.NodeTag)) {
                    if(child.name == Names.startNode) {
                        startNode = child.position;
                    }
                    else if(child.name == Names.endNode) {
                        endNode = child.position;
                    }
                    else {
                        nodesPosition.Add(child.position);
                    }
                }
            }
        }
        Debug.Log("Finish - Set Map Data");
    } 

    /// Save Map Data to Json format file
    public void SaveMapData() {
        JsonSerialize.SaveMapDataToJson(this);
    }

    /// Load Map Data from Json format file
    public void LoadMapData() {
        JsonSerialize.LoadMapDataToMap(this);
    }

    /// Reset Map Data
    public void ResetMapData() {
        level = 0;
        startNode = Vector3.zero; 
        endNode = Vector3.zero;
        nodesPosition.Clear();
        //blockInventory.Clear();
    }

        public void GenerateMapFromMapData() {
            if (mapGenerator == null) {
                transform.GetComponent<MapGenerator>();
            }
            mapGenerator.MapGenerate(this);
        }
}
