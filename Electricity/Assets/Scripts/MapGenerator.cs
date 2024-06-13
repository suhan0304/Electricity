using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public PrefabRepository prefabRepository;

    [Space(10)]
    [Header("Node Prefabs")]
    public GameObject NodePrefab;
    public GameObject StartNodePrefab;
    public GameObject EndNodePrefab;

    private void GetPrefabFromRepository() {
        NodePrefab =  prefabRepository.GetPrefab(Names.Node);
        StartNodePrefab = prefabRepository.GetPrefab(Names.startNode);
        EndNodePrefab = prefabRepository.GetPrefab(Names.endNode);
    }

    public void MapGenerate(Map map) {
        Debug.Log("Map Generation Start...");

        GetPrefabFromRepository();

        if (NodePrefab == null || StartNodePrefab == null || EndNodePrefab == null) {
            Debug.LogWarning("Node Prefab Error");
            return;
        }

        Debug.Log("Map Generation Finish!");
    }
}
