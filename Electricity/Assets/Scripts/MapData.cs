using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MapData
{
    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position
    public List<Vector3> nodePositions; // all Nodes Position
    public Dictionary<int, int> blockInventory; // blockInventrory<BlockType(num), blockCounts> {1: 2, 3: 4})

    public MapData(Map map)
    {
        startNode = map.startNode;
        endNode = map.endNode;
        nodePositions = new List<Vector3>();
        blockInventory = new Dictionary<int, int>();
    }
}
