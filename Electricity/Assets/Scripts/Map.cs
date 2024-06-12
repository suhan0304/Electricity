using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Map : MonoBehaviour
{
    public GameObject fieldObject;

    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position
    public List<Vector3> nodes; // all Nodes Position
    public Dictionary<int, int> blockInventory; // blockInventrory<BlockType(num), blockCounts> {1: 2, 3: 4})

    public void SetMapData() {
        if(GameManager.Instance.field == null) {
            Debug.LogError("GameManager's Filed Object is Null");
        }
        else {
            fieldObject = GameManager.Instance.field;
        }
        if (fieldObject != null) {
            foreach (Transform child in fieldObject.transform) {
                if(child.CompareTag(GameManager.Instance.NodeTag)) {
                    if(child.name == GameManager.Instance.startNode) {
                        startNode = child.position;
                    }
                    else if(child.name == GameManager.Instance.endNode) {
                        endNode = child.position;
                    }
                    else {
                        nodes.Add(child.position); 
                    }
                }
            }
        }
    } 

    public void SaveMapData() {
        JsonSerialize.SaveMapDataToJson(this);
    }
}
