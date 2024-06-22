using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    public BlockRepository blockRepository;

    [Serializable]
    public class BlockInventory {
        public BlockRepository.BlockData blockData;
        public int blockCount;

        public BlockInventory(BlockRepository.BlockData data) {
            blockData = data;
            blockCount = 0;
        }
    }
    
    public List<BlockInventory> blockInventories = new List<BlockInventory>();

    private void OnValidate() {
        if (blockRepository == null) {
            Debug.LogWarning($"{this.name}'s BlockRepsoitory is null, Can't make block Inventory");
        }
    }
    public void Initialize() {
        blockInventories.Clear();

        if(blockRepository != null) {
            foreach (var blockData in blockRepository.blockDatas) {
                BlockInventory inventory = new BlockInventory(blockData);
                blockInventories.Add(inventory);
            }
        }
    }
}
