using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    [Serializable]
    public class BlockCount {
        public BlockRepository.blockData blockData;
        public int count;
    }

    [Serializable]
    public class Level {
        public int levelNumber;

        public List<BlockCount> blockCounts = new List<BlockCount>();

        public void Initialize(BlockRepository blockRepository) {
            var oldBlockCounts = new Dictionary<string, int>();
            foreach (var blockCount in blockCounts) {
                if (blockCount.blockData != null) {
                    oldBlockCounts[blockCount.blockData.name] = blockCount.count;
                }
            }

            blockCounts.Clear();
            foreach (var blockData in blockRepository.blockDatas) {
                int count = 0;
                if (oldBlockCounts.TryGetValue(blockData.name, out var existingCount)) {
                    count = existingCount;
                }
                blockCounts.Add(new BlockCount { blockData = blockData, count = count });
            }
        }
    }

    public BlockRepository blockRepository;
    public List<Level> levels = new List<Level>();

    private void OnValidate() {
        //InitializeLevels();
    }

    public void InitializeLevels() {
        if (blockRepository == null) {
            Debug.LogWarning("BlockRepository is not assigned!");
            return;
        }
        
        foreach (var level in levels) {
            level.Initialize(blockRepository);
        }
    }    
    
    public void UpdateLevels() {
        InitializeLevels();
    }
}