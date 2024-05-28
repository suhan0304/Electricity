using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.VersionControl.Asset;

public class Block : MonoBehaviour
{

    [SerializeField]
    public Node node; // Node where the block was constructed
    public BlockState currentState; 
    public List<Block> AdjacentBlocks = new List<Block>();  // Blocks adjacent to me

    private BoxCollider[] colliders; // For Check Blocks in Contact

    [SerializeField]
    public Material OnMaterial = null;
    public Material OffMaterial = null;

    private void Start()
    {
        // Set Block Parameters ( list, state... )
        currentState = BlockState.OFF;
        StartCoroutine(ChangePillarMaterial(currentState, 0f));
        node = GetComponentInParent<Node>();
        AdjacentBlocks = GetBlockAdjacentBlocks();
        UpdateAdjacentBlockList();

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
            node.OnMouseDown();
        }
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
        LayerMask blockLayer = LayerMask.GetMask("Block");

        float rayDistance = 0f;
        
        foreach (Vector3 direction in directions) {
            if (direction == Vector3.up || direction == Vector3.down) 
                rayDistance = 1f;
            else 
                rayDistance = 4f;

            RaycastHit[] hitData = Physics.RaycastAll(transform.position, direction, rayDistance, blockLayer);
            foreach(RaycastHit hit in hitData) {
                Block hitBlock = hit.collider.gameObject.GetComponent<Block>();
                Debug.Log(hit.collider.name);

                blocksInRaycast.Add(hitBlock);
        
            }
        }

        return blocksInRaycast;
    }

    /// <summary>
    /// Add me(block) where adjacent block's list
    /// </summary>
    /// <param name="adjBlocks"></param>
    public void UpdateAdjacentBlockList() 
    {
        foreach (Block block in AdjacentBlocks) {
            block.AddBlockToAdjacentBlock(this);
        }
    }

    /// <summary>
    /// Add the parameter Block to the AdjacentBlock list.
    /// </summary>
    public void AddBlockToAdjacentBlock(Block block) 
    {
        if (block != null && !AdjacentBlocks.Contains(block))
            AdjacentBlocks.Add(block);
    }

    /// <summary>
    /// Update Block State (After updating adjacent blocks, it retrieves their states and updates its own state.)
    /// </summary>
    public void UpdateBlockState()
    {
        foreach (Block block in AdjacentBlocks) 
        {
            if (block.currentState == BlockState.ON) {
                ChangeOnState(); // 
                continue; // There is no need to check other blocks anymore.
            }
        }
    }

    /// <summary>
    /// Block State change to ON ( befor : OFF )
    /// Need to notify adjacent blocks that I have changed to the On state.
    /// </summary>
    public void ChangeOnState() {
        float delayTime = 2f;

        currentState = BlockState.ON;
        StartCoroutine(ChangePillarMaterial(BlockState.ON, delayTime));

        foreach (Block block in AdjacentBlocks) {
            if (block.currentState == BlockState.OFF) {
                block.ChangeOnState();
            }
        }
    }

    IEnumerator ChangePillarMaterial(BlockState st, float delayTime) 
    {
        yield return new WaitForSeconds(delayTime);

        Transform pillar = transform.Find("Pillar");
        Debug.Log("Change Pillar Material to OnMaterial");
        Renderer renderer = pillar.GetComponent<Renderer>();

        if (st == BlockState.ON) 
        {
            renderer.material = OnMaterial;
        }
        else if (st == BlockState.OFF)
        {
            renderer.material = OffMaterial;
        }
    }
}
