using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    [Header("Height")]
    [SerializeField]
    private float nodeHeight = 0; // to calculate buildBlock Position
    private float blocksTotalHeight = 0; // total of blocks height on node

    [Space(5)]
    [Header("Colors")]
    [SerializeField]
    public Color hoverColor; // color changes when mouse is hovered over

    [Space(5)]
    [Header("Block On Node")]
    [SerializeField]
    private GameObject blockOnNode; // Block Object ( built on node )

    [Space(5)]
    [Header("Node Settings")]
    [SerializeField]
    public bool isBuildable = true;

    // Renderer and Color
    private Renderer rend; // renderer component
    private Color startColor;  // start color


    private void Start()
    {
        nodeHeight = transform.localScale.y / 2; // half of node height - for build
        rend = GetComponent<Renderer>(); // call renderer component
        startColor = rend.material.color; // remember start color
    }

    public void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        if(isBuildable)
            rend.material.color = hoverColor; // change color to hoverColor
    }

    public void OnMouseExit() // When the mouse leaves the object collider
    {
        if(isBuildable)
            rend.material.color = startColor; // return color to startColor
    }

    public void OnMouseDown() //When the mouse click the object collider
    {
        // Build a Block
        if(isBuildable)
            BuildBlockOnNode();
    }


    /// <summary>
    /// Build Block On Node
    /// - The buildManager holds information about the blocks the player has chosen to build.
    /// </summary>
    private void BuildBlockOnNode()
    {
        GameObject blockBuild = BuildManager.instance.GetBlockToBuild();

        float blockHeight = blockBuild.transform.localScale.y;
        blockOnNode = (GameObject)Instantiate(blockBuild, new Vector3(
            transform.position.x,                                                       // Build Position - Vector.x 
            transform.position.y + nodeHeight + blocksTotalHeight +  (blockHeight/2),   // Build Position - Vector.y
            transform.position.z),                                                      // Build Position - Vector.z 
            transform.rotation);

        blockOnNode.transform.SetParent(transform, true); // set Parent

        blocksTotalHeight += blockHeight; // Update blocksTotalHeights ( add block height )

        Debug.Log("Build the Block!");
    }
}
