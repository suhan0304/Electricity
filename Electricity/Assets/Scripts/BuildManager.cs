using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Blocks Prefab")]
    public GameObject standardBlockPrefab;
    public GameObject otherBlockPrefab;

    public GameObject blockOnNode;
    
    public static BuildManager Instance; // for singleton pattern

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Error - Only 1 instance - BuildManager.");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        blockToBuild = standardBlockPrefab; //For Test
    }

    private GameObject blockToBuild; // blockToBuild GameObject

    /// <summary>
    /// Getter, Setter Block To Build
    /// </summary>
    public GameObject GetBlockToBuild()
    {
        return blockToBuild;
    }
    public void SetBlockToBuild(GameObject blockToBuild)
    {
        this.blockToBuild = blockToBuild;
    }

    /// <summary>
    /// Build Block On Node
    /// - The buildManager holds information about the blocks the player has chosen to build.
    /// </summary>
    public void BuildBlockOnNode(Node node)
    {
        float blockHeight = blockToBuild.transform.localScale.y;
        Vector3 buildPosition = node.transform.position + new Vector3(0,node.nodeHeight + node.blocksTotalHeight + (blockHeight/2),0);
        node.blockOnNode = (GameObject)Instantiate(blockToBuild, buildPosition, node.transform.rotation, node.transform.parent);


        node.blocksTotalHeight += blockHeight; // Update blocksTotalHeights ( add block height )
        node.transBlockHeight += blockHeight; // Update TransBlockHeight ( add block height )

        //Debug.Log("Build the Block!"); //For DebugTest
    }
}
