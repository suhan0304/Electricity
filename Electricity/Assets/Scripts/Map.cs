using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    public GameObject fieldObject;

    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position

    public Dictionary<int, int> blockInventory; // blockInventrory<BlockType(num), blockCounts> {1: 2, 3: 4})

    public List<Vector3> nodesPosition; // all Nodes Position

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

    public void SaveMapData() {
        JsonSerialize.SaveMapDataToJson(this);
    }
}
