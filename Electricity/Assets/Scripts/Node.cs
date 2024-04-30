using UnityEngine;

public class Node : MonoBehaviour
{
    
    public Color hoverColor; // color changes when mouse is hovered over

    private Renderer rend; // renderer component
    private Color startColor;  // start color


    private void Start()
    {
        rend = GetComponent<Renderer>(); // call renderer component
        startColor = rend.material.color; // remember start color
    }

    private void OnMouseEnter() // When the mouse passes or enters an object collider
    {
        rend.material.color = hoverColor; // change color to hoverColor
    }

    private void OnMouseExit() // When the mouse leaves the object collider
    {
        rend.material.color = startColor; // return color to startColor
    }

    private void OnMouseDown() //When the mouse click the object collider
    {
        if(chooseBlock != null)
        {
            Debug.Log("Can't build there - TODO : Display on screen.");
            return;
        }

        // Build a Block
        GameObject blockBuild = BuildManager.GetBlockToBuild();

        block = (GameObject)Instantiate(blockBuild, transform.position + positionOffset, transform.rotation);

    }
}
