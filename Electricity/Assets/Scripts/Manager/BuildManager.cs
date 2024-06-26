using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Prefab Repository")]
    public PrefabRepository prefabRepository;
    public BlockRepository blockRepository;

    [Space(5)]
    [Header("Blocks Prefabs")]
    public GameObject standardBlockPrefab;
    public GameObject otherBlockPrefab;
    public GameObject blockToBuild; // blockToBuild GameObject

    [Space(5)]
    [Header("Block On Node")]
    public GameObject blockOnNode;
    
    [Space(5)]
    [Header("For Build")]
    public BuildMenu buildMenu;

    public static BuildManager Instance; // for singleton pattern

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Error - Only 1 instance - BuildManager.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if (prefabRepository == null) {
            Debug.Log("PrefabRepository is not assigned in BuildManager");
            return;
        }

        blockToBuild = null;
    }

    /// <summary>
    /// Getter, Setter Block To Build
    /// </summary>
    public GameObject GetBlockToBuild()
    {
        return blockToBuild;
    }

    public void SetBlockToBuild(int blockType)
    {
        if (blockType == -1) {
            blockToBuild = null;
            return;
        }
        blockToBuild = blockRepository.GetPrefabToType(blockType);
    }

    /// <summary>
    /// Build Block On Node
    /// - The buildManager holds information about the blocks the player has chosen to build.
    /// </summary>
    public void BuildBlockOnNode(Node node)
    {
        float blockHeight = blockToBuild.transform.localScale.y;
        Vector3 buildPosition = node.transform.position + new Vector3(0,node.nodeHeight + node.blocksTotalHeight + (blockHeight/2),0);
        node.blockOnNode = Instantiate(blockToBuild, buildPosition, node.transform.rotation, node.transform.parent);

        node.blocksTotalHeight += blockHeight; // Update blocksTotalHeights ( add block height )

        buildMenu.BuildSelectedButtonBlock();

        //Debug.Log("Build the Block!"); //For DebugTest
    }
}
