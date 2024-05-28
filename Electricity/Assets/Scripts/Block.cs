using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Block : MonoBehaviour
{

    [SerializeField]
    public Node node; // Node where the block was constructed
    public BlockState currentState; 
    public List<Block> AdjacentBlocks = new List<Block>();  // Blocks adjacent to me

    private BoxCollider[] colliders; // For Check Blocks in Contact


    private void Start()
    {
        // Set Block Parameters ( list, state... )
        currentState = BlockState.OFF;
        node = GetComponentInParent<Node>();
        AdjacentBlocks = GetBlockAdjacentBlocks();

        UpdateBlockState();
    }

    public void OnMouseEnter() // When the mouse leaves the object collider
    {
        if (node != null)
        {
            node.OnMouseEnter();
        }
    }

    public void OnMouseExit() // When the mouse leaves the object collider
    {
        if (node != null)
        {
            node.OnMouseExit();
        }
    }

    public void OnMouseDown() //When the mouse click the object collider
    {
        if (node != null)
        {
            // Build a Block
        }
        node.OnMouseDown();
    }



    /// <summary>
    /// Update Block State (After updating adjacent blocks, it retrieves their states and updates its own state.)
    /// </summary>
    public void UpdateBlockState()
    {
        Debug.Log("TODO - UpdateBlockSate!");
    }

    /// <summary>
    /// Get Block in Colliders
    /// </summary>
    public List<Block> GetBlockAdjacentBlocks()
    {
        Vector3[] directions = {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            Vector3.forward,
            Vector3.back
        };

        List<Block> blocksInRaycast = new List<Block>();
        /*
        List<Block> blocksInColliders = new List<Block>();

        foreach (var collider in  colliders)
        {
            Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation);
            foreach (var hitCollider in hitColliders)
            {
                Block hitBlock = hitCollider.GetComponent<Block>();
                if (hitBlock != null && hitBlock != this && !blocksInColliders.Contains(hitBlock)) 
                { 
                    blocksInColliders.Add(hitBlock);
                }
            }
        }

        return blocksInColliders;

        */

    }

    /// <summary>
    /// Add the parameter Block to the AdjacentBlock list.
    /// </summary>
    public void AddBlockToAdjacentBlock(Block block)
    {
        if (block != null && !AdjacentBlocks.Contains(block))
            AdjacentBlocks.Add(block);
    }
}
