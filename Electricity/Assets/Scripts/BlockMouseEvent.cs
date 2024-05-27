using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlockMouseEvent : MonoBehaviour
{
    [SerializeField]
    public Block block = null;
    public Node node = null;

    private void Start()
    {
        block = GetComponentInParent<Block>();
        node = block.node;
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
}
