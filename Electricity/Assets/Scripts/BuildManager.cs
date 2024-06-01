using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public GameObject standardBlockPrefab;
    public GameObject blockOnNode;

    private void Start()
    {
        blockToBuild = standardBlockPrefab; //For Test
    }

    private GameObject blockToBuild; // blockToBuild GameObject

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
