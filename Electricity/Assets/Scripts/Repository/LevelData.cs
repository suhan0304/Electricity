using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    [Serializable]
    public class blockInventory
    {
        public int level; 
        public BlockRepository.BlockData blockData;
        public int count;

        public blockInventory(int level) {
            this.level = level;
        }
    }

    public List<blockInventory> blockInventorys = new List<blockInventory>();

    public void Initialize(BlockRepository blockRepository)
    {
        blockInventorys.Clear();
        
        foreach (var blockData in blockRepository.blockDatas)
        {
            // Initialize each block count
            blockInventory blockInventory = new blockInventory(blockInventorys.Count);
            blockInventory.blockData = blockData;
            blockInventory.count = 0; // Initial count is zero
            blockInventorys.Add(blockInventory);
        }
    }
}
