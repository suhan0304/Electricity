using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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


    [SerializeField]
    public BuildManager buildManager;


    private void Awake()
    {
        rend = GetComponent<Renderer>(); // call renderer component
        transBlockOnNode = transform.GetChild(0).gameObject;
        transBlockHeight = transBlockOnNode.transform.position.y;

    }

    private void Start()
    {
        buildManager = BuildManager.Instance;
        nodeHeight = transform.localScale.y / 2; // half of node height - for build
        startColor = rend.material.color; // remember start color
    }

    public void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        if (buildManager.GetBlockToBuild() == null || !isBuildable)
            return;


        if (GameManager.Instance.gameState == GameState.PLAY)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            //StartCoroutine(transparentBlockNodeControl());
            rend.material.color = hoverColor; // change color to hoverColor
        }
    }

    IEnumerator transparentBlockNodeControl()
    {
        transBlockOnNode.SetActive(true);
        while (transBlockOnNode.activeSelf && GameManager.Instance.gameState == GameState.PLAY)
        {
            yield return null;
        }
        transBlockOnNode.SetActive(false);
    }

    public void OnMouseExit() // When the mouse leaves the object collider
    {
        transBlockOnNode.SetActive(false);
        if (GameManager.Instance.gameState == GameState.PLAY)
        {
            rend.material.color = startColor; // return color to startColor
        }
    }

    public void OnMouseDown() //When the mouse click the object collider
    {
        if (buildManager.GetBlockToBuild() == null || !isBuildable)
            return;

        // Build a Block
        if (GameManager.Instance.gameState == GameState.PLAY)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            BuildManager.Instance.BuildBlockOnNode(this);
            Vector3 targetPos = transBlockOnNode.transform.position;
            transBlockOnNode.transform.position = new Vector3(targetPos.x, transBlockHeight, targetPos.z);
        }
    }
}
