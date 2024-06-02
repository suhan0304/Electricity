using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectStandardBlock()
    {
        Debug.Log("Standard Block Selected");
        buildManager.SetBlockToBuild(buildManager.standardBlockPrefab); // set selected block to Standard block 
    }

    public void SelectOtherBlock()
    {
        Debug.Log("Other Block Selected");
        buildManager.SetBlockToBuild(buildManager.otherBlockPrefab); // set selceted block to Other block;
    }
}
