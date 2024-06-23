using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    [Space(5)]
    [Header("Objects")]
    public List<GameObject> buttons;
    public GameObject SelectedButton;
    public GameObject buttonPrefab;
    public LevelData levelData;


    public void AddBtnsBuildMenu()
    {
        Debug.Log($"{this.name} - AddBtnsBuildMenu");
        buttonPrefab = Resources.Load<GameObject>("BuildButton");
        levelData = LevelDataManager.Instance.GetLevelData(GameManager.Instance.mapLevel);

        Debug.Log("Start Build Button UI");

        foreach(var blockInventory in BlockInventory.Instance.LevelBlockInventories) {
            if (blockInventory.blockCount != 0) {
                GameObject BuildItem = Instantiate(buttonPrefab, transform);
                buttons.Add(BuildItem);
                BuildItem.GetComponent<BuildButton>().BlockInventory = blockInventory;
            }
        }
    }

    public void SelectBlock(int blockType) {
        Debug.Log($"{blockType} Type Block Selected");
        TransparentBlockManager.Instance.SetSelectedBlockType(blockType);
        BuildManager.Instance.SetBlockToBuild(blockType);
    }

    public void DeselectBlock() {
        Debug.Log($"Block Deseelected");
        TransparentBlockManager.Instance.SetSelectedBlockType(-1);
        BuildManager.Instance.SetBlockToBuild(-1);
    }

    public void BuildSelectedButtonBlock() {
        Debug.Log("Build Block (From Build Menu)");
        // TODO 2024 06 22 FINAL & COUNT LOGIC
    }
}
