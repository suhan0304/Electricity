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

    private void OnMouseExit() //
    {
        rend.material.color = startColor; // return color to startColor
    }

}
