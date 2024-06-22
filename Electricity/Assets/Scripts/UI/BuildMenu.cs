using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject SelectedButton;
    public GameObject buttonPrefab;
    public LevelData levelData;

    public void AddBtnsBuildMenu()
    {
        buttonPrefab = Resources.Load<GameObject>("BuildButton");
        levelData = LevelDataManager.Instance.GetLevelData(GameManager.Instance.mapLevel);

        Debug.Log("Start Build Button UI");

        foreach(var blockInventory in BlockInventory.Instance.LevelBlockInventories) {
            if (blockInventory.blockCount != 0) {
                GameObject BuildItem = Instantiate(buttonPrefab, transform);
                BuildItem.GetComponent<BuildButton>().BlockInventory = blockInventory;
            }
        }
    }

    public void SelectBlock(int blockType) {
        Debug.Log($"{blockType} Type Block Selected");
        TransparentBlockManager.Instance.SetSelectedBlockType(blockType);
        BuildManager.Instance.SetBlockToBuild(blockType);
    }

    public void BuildSelectedButtonBlock() {
        Debug.Log("Build Block (From Build Menu)");
    }
}
