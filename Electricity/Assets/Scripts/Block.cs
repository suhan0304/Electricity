using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    Node node; // Node where the block was constructed

    private void Start()
    {
        node = GetComponentInParent<Node>();
    }

    public void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        Debug.Log("!!");
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
}
