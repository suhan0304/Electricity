using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Block : MonoBehaviour
{

    [SerializeField]
    Node node; // Node where the block was constructed
    public BlockState currentState; 
    public List<Block> AdjacentBlocks = new List<Block>();  // Blocks adjacent to me

    private BoxCollider[] colliders; // For Check Blocks in Contact

    private void Start()
    {
        // Initialize
        currentState = BlockState.OFF;
        node = GetComponentInParent<Node>();
        InitializeColliders(); 

        // 
        UpdateBlockState();
    }

    public void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        if ( node != null)
            node.OnMouseEnter();
    }

    public void OnMouseExit() // When the mouse leaves the object collider
    {
        if (node != null)
            node.OnMouseExit();
    }

    public void OnMouseDown() //When the mouse click the object collider
    {
        if (node != null)
            // Build a Block
            node.OnMouseDown();
    }

    /// <summary>
    /// Update Block State (After updating adjacent blocks, it retrieves their states and updates its own state.)
    /// </summary>
    public void UpdateBlockState()
    {
        AdjacentBlocks = GetBlockInColliders();
    }

    /// <summary>
    /// Check initial Collider Components
    /// </summary>
    private void InitializeColliders() 
    {
        colliders = GetComponents<BoxCollider>();

        if (colliders.Length != 3)
        {
            Debug.LogError("Error 01 - 3 BoxColliders are required per block.");
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
}
