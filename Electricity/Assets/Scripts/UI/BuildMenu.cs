using JetBrains.Annotations;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject buttonPrefab;

    private void Start()
    {
        buildManager = BuildManager.Instance;
        buttonPrefab = Resources.Load<GameObject>("BuildButton");
        
        /*
        foreach (var blockItem in levelData.levels[GameManager.Instance.mapLevel].BlockInventorys) {
            GameObject btnPrefab = Instantiate(buttonPrefab, transform);
            btnPrefab.GetComponent<buildButton>().BlockData = blockItem.blockData;
        }
        */
    }
    /*
    public void SelectBlock(int blockType) {
        Debug.Log($"Select {blockType} Block");
        TransparentBlockManager.Instance.SetSelectedBlockType(blockType);
        buildManager.SetBlockToBuild(levelData.levels[GameManager.Instance.mapLevel].BlockInventorys[blockType].blockData.prefab); 
    }
    */

}
