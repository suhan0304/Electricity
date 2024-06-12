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

    }

    void SetMapData() {
        fieldObject = GameManager.Instance.field;
        if (fieldObject != null) {
            foreach (Transform child in fieldObject.transform) {
                if(child.CompareTag(GameManager.Instance.blo))
            }
        }
    }
}
