using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInventory : MonoBehaviour
{
    public static BlockInventory Instance;
    public BuildMenu buildMenu;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }     
        else {
            Debug.LogWarning("Error - Only 1 instance - BlockInventory.");
            Destroy(gameObject);
        }
    }

    public List<LevelData.BlockInventory> LevelBlockInventories = new List<LevelData.BlockInventory>();

    public void Initialize() {
        Debug.Log($"{this.name} - Initialize");
        LevelData levelData = LevelDataManager.Instance.GetLevelData(GameManager.Instance.mapLevel);
        if (levelData != null) {
            foreach (var blockInventory in levelData.blockInventories) {
                LevelData.BlockInventory newInventory = new LevelData.BlockInventory(blockInventory.blockData) {
                    blockCount = blockInventory.blockCount
                };
                LevelBlockInventories.Add(newInventory);
            }
        }
        buildMenu.AddBtnsBuildMenu();
    }

    public void GetBlockFromInventory(int buildBlockType) {
        foreach (var blockInventory in LevelBlockInventories) {
            if (blockInventory.blockData.blockType == buildBlockType) {
                if (blockInventory.blockCount > 0) {
                    blockInventory.blockCount--;
                    buildMenu.BuildSelectedButtonBlock();
                }
            }
        }
    }
}
