
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class MapGenerator : MonoBehaviour
{
    public PrefabRepository prefabRepository;

    [Space(10)]
    [Header("Node Prefabs")]
    public GameObject NodePrefab;
    public GameObject StartNodePrefab;
    public GameObject EndNodePrefab;

    public void GetPrefabFromRepository() {
        prefabRepository.InitializeDictionary();
        NodePrefab =  prefabRepository.GetPrefab(Names.Node);
        StartNodePrefab = prefabRepository.GetPrefab(Names.startNode);
        EndNodePrefab = prefabRepository.GetPrefab(Names.endNode);
    }

    /// Generate the map by loading Node Prefab based on MapData.
    public void MapGenerate(Map map, Transform fieldObject) {
        Debug.Log("Map Generation Start...");

        // Initialize MapGenerator's prefab by retrieving Prefab from PrefabRepository
        GetPrefabFromRepository();

        if (NodePrefab == null || StartNodePrefab == null || EndNodePrefab == null) {
            Debug.LogWarning("Node Prefab Error");
            return;
        }

        GameObject startNode = Instantiate(StartNodePrefab, map.startNode, Quaternion.identity, fieldObject);
        GameObject endNode = Instantiate(EndNodePrefab, map.endNode, Quaternion.identity, fieldObject);
        GameManager.Instance.endPoint = endNode.transform.Find(Names.endPoint).gameObject;

        StartCoroutine(SpawnNodesWithDelay(map, fieldObject, 0.2f)); // 0.2초 간격으로 노드 생성

        Debug.Log("Map Generation Finish!");
    }    

    /// Coroutines for creating nodes at intervals
    IEnumerator SpawnNodesWithDelay(Map map, Transform fieldObject, float delayTime)
    {
        float downTime = delayTime * 2f;
        float firstNodeHeight = 100f;
        foreach (Vector3 targetVec in map.nodesPosition)
        {
            Vector3 firstVec = new Vector3(targetVec.x, firstNodeHeight, targetVec.z);

            GameObject node = Instantiate(NodePrefab, firstVec, Quaternion.identity, fieldObject);

            // Start the coroutine to move the node smoothly
            StartCoroutine(SmoothMoveToPosition(node.transform, targetVec, downTime));
        
            yield return new WaitForSeconds(delayTime); 
        }
    }
}
