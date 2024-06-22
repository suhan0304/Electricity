using JetBrains.Annotations;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject buttonPrefab;
    public LevelData levelData;

    private void Start()
    {
        buildManager = BuildManager.Instance;
        buttonPrefab = Resources.Load<GameObject>("BuildButton");
        
        foreach (var blockItem in levelData.levels[GameManager.Instance.mapLevel].BlockInventorys) {
            GameObject btnPrefab = Instantiate(buttonPrefab, transform);
            btnPrefab.GetComponent<buildButton>().BlockData = blockItem.blockData;
        }
    }

    public void SelectBlock(int blockType) {
        Debug.Log($"Select {blockType} Block");
        TransparentBlockManager.Instance.SetSelectedBlockType(blockType);
        buildManager.SetBlockToBuild(levelData.levels[GameManager.Instance.mapLevel].BlockInventorys[blockType].blockData.prefab); 
    }

    /*
    public void SelectStandardBlock()
    {
        Debug.Log("Standard Block Selected");
        TransparentBlockManager.Instance.SetSelectedBlockType(0); // set selected block Type to 0 ( = standard block )
        // TODO - selected Block Type = !!hard cording!! ( Block Ropository, Inventory Manager )
        buildManager.SetBlockToBuild(buildManager.standardBlockPrefab); // set selected block to Standard block 
    }

    public void SelectOtherBlock()
    {
        Debug.Log("Other Block Selected");
        TransparentBlockManager.Instance.SetSelectedBlockType(1);
        // TODO - selected Block Type = !!hard cording!! ( Block Ropository, Inventory Manager )
        buildManager.SetBlockToBuild(buildManager.otherBlockPrefab); // set selceted block to Other block;
    }
    */
}
