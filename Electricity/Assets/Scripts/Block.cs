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
        InitializeColliders();
        node = GetComponentInParent<Node>();
        UpdateBlockState();
    }

    /// <summary>
    /// Update Block State (After updating adjacent blocks, it retrieves their states and updates its own state.)
    /// </summary>
    public void UpdateBlockState()
    {
        AdjacentBlocks = GetBlockInColliders();
        foreach (var adjacentBlock in AdjacentBlocks)
        {
            adjacentBlock.AddBlockToAdjacentBlock(this);
        }
    }

    /// <summary>
    /// Check initial Collider Components
    /// </summary>
    private void InitializeColliders() 
    {
        colliders = GetComponents<BoxCollider>();

        if (colliders.Length < 3)
        {
            Debug.LogError("Error 01 - more than 3 BoxColliders are required per block.");
            return;
        }
    }

    /// <summary>
    /// Get Block in Colliders
    /// </summary>
    public List<Block> GetBlockInColliders()
    {
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
