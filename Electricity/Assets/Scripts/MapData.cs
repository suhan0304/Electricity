using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MapData
{
    public int level;
    public Vector3 startNode; // StartNode Position
    public Vector3 endNode; // EndNode Position
    public List<Vector3> nodePositions; // 모든 노드들의 좌표
    public Dictionary<int, int> blockInventory; // 블록 타입별 보유 개수 (예: {1: 2, 3: 4})

    public MapData(Map map)
    {
        startNode = map.startNode;
        endNode = map.endNode;
        nodePositions = new List<Vector3>();
        blockInventory = new Dictionary<int, int>();
    }
}
