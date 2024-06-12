using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Map : MonoBehaviour
{
    public GameObject fieldObject;

    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position
    public List<Vector3> nodePositions; // all Nodes Position
    public Dictionary<int, int> blockInventory; // blockInventrory<BlockType(num), blockCounts> {1: 2, 3: 4})

    void Start() {
        SetMapData();
    }

    void SetMapData() {
        fieldObject = GameManager.Instance.field;
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
                        nodePositions.Add(child.position); 
                    }
                }
            }
        }
    }
}
