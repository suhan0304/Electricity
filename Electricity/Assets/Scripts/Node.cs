using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    [Header("Height")]
    [SerializeField]
    public float nodeHeight = 0; // to calculate buildBlock Position
    public float blocksTotalHeight = 0; // total of blocks height on node
    public float transBlockHeight = 0;

    [Space(5)]
    [Header("Colors")]
    [SerializeField]
    public Color hoverColor; // color changes when mouse is hovered over

    [Space(5)]
    [Header("Block On Node")]
    [SerializeField]
    public GameObject blockOnNode; // Block Object ( built on node )
    public GameObject transBlockOnNode; // Transparent Block Object ( before build )

    [Space(5)]
    [Header("Node Settings")]
    [SerializeField]
    public bool isBuildable = true;

    // Renderer and Color
    private Renderer rend; // renderer component
    private Color startColor;  // start color


    private void Awake()
    {
        rend = GetComponent<Renderer>(); // call renderer component
        transBlockOnNode = transform.GetChild(0).gameObject;
        transBlockHeight = transBlockOnNode.transform.position.y;
    }

    private void Start()
    {
        nodeHeight = transform.localScale.y / 2; // half of node height - for build
        startColor = rend.material.color; // remember start color
    }

    public void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        if(isBuildable) 
        {
            transBlockOnNode.SetActive(true);
            rend.material.color = hoverColor; // change color to hoverColor
        }
    }

    public void OnMouseExit() // When the mouse leaves the object collider
    {
        if (isBuildable)
        {
            transBlockOnNode.SetActive(false);
            rend.material.color = startColor; // return color to startColor
        }
    }

    public void OnMouseDown() //When the mouse click the object collider
    {
        // Build a Block
        if(isBuildable)
        {
            GameManager.Instance.buildManager.BuildBlockOnNode(this);
            Vector3 targetPos = transBlockOnNode.transform.position;
            transBlockOnNode.transform.position = new Vector3(targetPos.x, transBlockHeight, targetPos.z);
        }
    }
}
