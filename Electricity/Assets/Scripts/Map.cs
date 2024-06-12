using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Map : MonoBehaviour
{
    public GameObject fieldObject;

    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position
    public List<float[]> nodesPosition = new List<float[]>(); // all Nodes Position
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
                        nodesPosition.Add(new float[3] {child.position.x, child.position.y, child.position.z});
                    }
                }
            }
        }
    } 

    public void SaveMapData() {
        JsonSerialize.SaveMapDataToJson(this);
    }
}
