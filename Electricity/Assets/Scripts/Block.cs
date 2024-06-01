using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    public Node node; // Node where the block was constructed
    public BlockState currentState; 
    public List<Block> AdjacentBlocks = new List<Block>();  // Blocks adjacent to me

    [Space(5)]
    [Header("Pillar")]
    [SerializeField]
    public GameObject pillar;
    public Renderer pillarRenderer;
    public Material pillarMaterial;

    [Space(5)]
    [Header("Animation")]
    public Animator anim;

    private GameObject endPoint = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        node = transform.parent.GetChild(0).GetComponentInParent<Node>();
    }

    private void Start()
    {
        // Set Block Parameters ( list, state... )
        currentState = BlockState.OFF;

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
    /// Get Block use laycast
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
            Ray ray = new Ray(transform.position, direction);

            if (direction == Vector3.up || direction == Vector3.down) 
                rayDistance = 1f;
            else {
                rayDistance = 4f;
            }

            RaycastHit[] hitData = Physics.RaycastAll(ray, rayDistance, blockLayer);
            foreach(RaycastHit hit in hitData)
            {
                if (hit.collider.CompareTag(GameManager.Instance.startTag))
                {
                    ChangeOnState(); // Block State On - Adjacent StartPoint
                }
                if (hit.collider.CompareTag(GameManager.Instance.endTag))
                {
                    endPoint = hit.collider.gameObject; // if end-Poin is adjacent me : initialization endPoint
                }
                else {
                    Block hitBlock = hit.collider.gameObject.GetComponent<Block>();
                    //Debug.Log(hit.collider.name); // For Debug Test

                    blocksInRaycast.Add(hitBlock);
                }
            }
        }

        return blocksInRaycast;
    }

    /// <summary>
    /// Add me(block) where adjacent block's list
    /// </summary>
    public void UpdateAdjacentBlockList() 
    {
        foreach (Block block in AdjacentBlocks) {
            if (block != null)
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
            if (block == null)
                continue;

            if (block.currentState == BlockState.ON) {
                ChangeOnState(); 
                continue; // There is no need to check other blocks anymore.
            }
        }
    }

    /// <summary>
    /// Block State change to ON ( befor : OFF )
    /// If the endpoint is adjacent to me, it is necessary to clear the stage
    /// Need to notify adjacent blocks that I have changed to the On state.
    /// </summary>
    public void ChangeOnState() {
        float delayTime = 1f;

        currentState = BlockState.ON;
        anim.SetTrigger("StateOn");

        // if endPoint is not null = endPoint is adjacent me.
        // When I change to the On state, EndPoint also changes to the On state and clears the stage
        if (endPoint != null)  {
            GameManager.Instance.Clear();
        }

        StartCoroutine(ChangeAdjacentBlockStateON(delayTime));
    }

    IEnumerator ChangeAdjacentBlockStateON(float delayTime) 
    {
        yield return new WaitForSeconds(delayTime);

        foreach (Block block in AdjacentBlocks) {
            if (block == null) continue;

            if (block.currentState == BlockState.OFF) {
                block.ChangeOnState();
            }
        }
    }
}
