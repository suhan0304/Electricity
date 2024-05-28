using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    [Header("Height")]
    [SerializeField]
    public float nodeHeight = 0; // to calculate buildBlock Position
    public float blocksTotalHeight = 0; // total of blocks height on node

    [Space(5)]
    [Header("Colors")]
    [SerializeField]
    public Color hoverColor; // color changes when mouse is hovered over

    [Space(5)]
    [Header("Block On Node")]
    [SerializeField]
    public GameObject blockOnNode; // Block Object ( built on node )

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
        if(isBuildable) {
            GameManager.Instance.buildManager.BuildBlockOnNode(this);
            GameManager.Instance.startPoint.checkBuiltBlock();
        }
    }
}
