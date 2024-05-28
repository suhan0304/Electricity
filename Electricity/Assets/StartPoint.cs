using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    List<Block> adjacentBlocks = new List<Block>();
    public BlockState startState = BlockState.ON;

    private void Start() {
        adjacentBlocks = GetBlockAdjacentBlocks();
    }

    /// <summary>
    /// Check adjacent block nearby start point when block built
    /// </summary>
    public void checkBuiltBlock() 
    {
        List<Block> checkAdjacentBlocks = GetBlockAdjacentBlocks();
        foreach (Block block in checkAdjacentBlocks) 
        {
            if (adjacentBlocks.Contains(block)) 
                continue;
            adjacentBlocks.Add(block);
            block.ChangeOnState();
        }
    }

    /// <summary>
    /// Get Block use laycast
    /// </summary>
    public List<Block> GetBlockAdjacentBlocks()
    {
        Vector3[] directions = {
            Vector3.left,
            Vector3.right,
            Vector3.forward,
            Vector3.back
        };

        List<Block> blocksInRaycast = new List<Block>();
        LayerMask blockLayer = LayerMask.GetMask("Block");

        float rayDistance = 4f;
        foreach (Vector3 direction in directions) {

            RaycastHit[] hitData = Physics.RaycastAll(transform.position, direction, rayDistance, blockLayer);
            foreach(RaycastHit hit in hitData) {
                Block hitBlock = hit.collider.gameObject.GetComponent<Block>();
                Debug.Log(hit.collider.name);

                blocksInRaycast.Add(hitBlock);
        
            }
        }

        return blocksInRaycast;
    }
}
