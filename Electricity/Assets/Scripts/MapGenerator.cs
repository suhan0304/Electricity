
using UnityEngine;
using System.Collections;

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

        Instantiate(StartNodePrefab, map.startNode, Quaternion.identity, fieldObject);

        GameObject endNode = Instantiate(EndNodePrefab, map.endNode, Quaternion.identity, fieldObject);

        GameManager.Instance.endPoint = endNode.transform.Find(Names.endPoint).gameObject;

        StartCoroutine(SpawnNodesWithDelay(map, fieldObject, 0.2f));

        Debug.Log("Map Generation Finish!");
    }    

    /// Coroutines for creating nodes at intervals
    IEnumerator SpawnNodesWithDelay(Map map, Transform fieldObject, float delayTime)
    {
        foreach (Vector3 vec in map.nodesPosition)
        {
            Instantiate(NodePrefab, vec, Quaternion.identity, fieldObject);
            yield return new WaitForSeconds(delayTime); // 0.2초 대기
        }
    }
}
