
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
        float delayTime = 0.1f;
        float StartNodeHeight = 100f;
        float delayTimeMulti = 10f;

        GameObject startNode = Instantiate(StartNodePrefab, 
            new Vector3(map.startNode.x, StartNodeHeight, map.startNode.z) , 
            Quaternion.identity, fieldObject);
        GameObject endNode = Instantiate(EndNodePrefab, 
            new Vector3(map.endNode.x, StartNodeHeight, map.endNode.z) , 
            Quaternion.identity, fieldObject);


        StartCoroutine(SmoothMoveToPosition(startNode.transform, map.startNode, delayTime * delayTimeMulti));
        StartCoroutine(SmoothMoveToPosition(endNode.transform, map.endNode, delayTime * delayTimeMulti));

        GameManager.Instance.endPoint = endNode.transform.Find(Names.endPoint).gameObject;

        // Spawn Nodes to use Couroutine (interval Spawn)
        StartCoroutine(SpawnNodesWithDelay(map, fieldObject, delayTime, StartNodeHeight, delayTimeMulti)); 

        Debug.Log("Map Generation Finish!");
    }    

    /// Coroutines for creating nodes at intervals
    IEnumerator SpawnNodesWithDelay(Map map, Transform fieldObject, float delayTime, float StartHeight, float delayTimeMulti)
    {
        foreach (Vector3 targetVec in map.nodesPosition)
        {
            Vector3 firstVec = new Vector3(targetVec.x, StartHeight, targetVec.z);

            GameObject node = Instantiate(NodePrefab, firstVec, Quaternion.identity, fieldObject);

            // Start the coroutine to move the node smoothly
            StartCoroutine(SmoothMoveToPosition(node.transform, targetVec, delayTime * delayTimeMulti));
        
            yield return new WaitForSeconds(delayTime); 
        }
    }

    /// Smoothly moves the node transform to the end position over the specified duration.
    IEnumerator SmoothMoveToPosition(Transform node, Vector3 endPos, float duration) {
        Vector3 startPos = node.position;
        float elapsedTime = 0;

        while (elapsedTime < duration) {
            float t = elapsedTime / duration;
            float smoothT = Mathf.SmoothStep(0, 1, t);

            node.position = Vector3.Lerp(startPos, endPos, smoothT);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        node.position = endPos;
    }
    }
