using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MapData
{
    public Vector3 startNode; // StartNode의 좌표
    public Vector3 endNode; // EndNode의 좌표
    public List<Vector3> nodePositions; // 모든 노드들의 좌표
    public Dictionary<int, int> blockInventory; // 블록 타입별 보유 개수 (예: {1: 2, 3: 4})

    public MapData(Vector3 start, Vector3 end)
    {
        startNode = start;
        endNode = end;
        nodePositions = new List<Vector3>();
        blockInventory = new Dictionary<int, int>();
    }
}
